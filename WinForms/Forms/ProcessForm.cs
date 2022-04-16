using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class ProcessForm : Form
    {
        private List<Process> processes;    // list of started processes
        private bool isStart;               // bool var that toggled when proc start
        private int ticks;                  // ticks for timer
        public ProcessForm()
        {
            ticks = 0;
            isStart = false;
            processes = new();
            InitializeComponent();
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
        }

        private void buttonNotepadStart_Click(object sender, EventArgs e)
        {
            // if any proc didn't start
            if (!isStart)
            {
                processes.Add(Process.Start("notepad.exe"));  // starting proc
                isStart = true;                               // toggle var to true
            }
            else MessageBox.Show("Process already started");
        }

        private void buttonNotepadStop_Click(object sender, EventArgs e)
        {
            // if any proc started
            if (isStart)
            {
                // stopping all processes
                foreach (var proc in processes)
                {
                    proc.Kill();
                    proc.Dispose();
                }
                isStart = false;  // toggling var to false
            }


        }
        private void buttonNotepadLog_Click(object sender, EventArgs e)
        {
            // if any proc didn't start
            if (!isStart)
            {
                processes.Add(Process.Start("notepad.exe", /*starting proc notepad*/
                    Application.StartupPath + "log.txt")); // and opening log.txt in \bin
                isStart = true;
            }
            else MessageBox.Show("Process already started");
        }

        private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stopping all processes when form closing
            foreach (var proc in processes)
            {
                proc.Kill();
                proc.Dispose();
            }
            isStart = false;
            timerRefresher.Stop();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            // foreach(var process in processes.OrderBy(p => p.ProcessName))
            // {
            //     // creating object-node of "tree"
            //     TreeNode node = new TreeNode();
            //     // configuring node
            //     node.Text = process.ProcessName;
            // 
            //     // adding node to tree
            //     treeViewProcesses.Nodes.Add(node);
            // }
            timerRefresher.Start();
            foreach (var grp in processes.GroupBy(p => p.ProcessName,
                (n, g) => new { Name = n, Processes = g.ToList() }).OrderBy(grp => grp.Name))
            {
                TreeNode node = new TreeNode();
                node.Text = $"{grp.Name} | {grp.Processes.Count}";

                foreach (var proc in grp.Processes)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Text = $"Proc #{proc.Id} | Prior \"{proc.BasePriority}\" | ({proc.Threads.Count})";
                    foreach (ProcessThread thread in proc.Threads)
                    {
                        subNode.Nodes.Add(new TreeNode($"Thread #{thread.Id} | Prior \"{proc.BasePriority}\""));
                    }
                    subNode.Tag = proc;
                    node.Nodes.Add(subNode);
                }
                node.BackColor = Color.LightGreen;
                treeViewProcesses.Nodes.Add(node);
            }
        }

        private void treeViewProcesses_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (MessageBox.Show("Kill?", "Confirm", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    ((Process)e.Node.Tag)?.Kill();
                }
            }
        }

        private void timerRefresher_Tick(object sender, EventArgs e)
        {
            // show timer
            ticks++;
            int intHours = ticks / 3600;
            int intMinutes = (ticks / 3600) / 60;
            int intSec = ticks % 60;
            String hours = intHours.ToString("00");
            String min = intMinutes.ToString("00");
            String sec = intSec.ToString("00");
            labelTimer.Text = $"{hours}:{min}:{sec}";
            
            // get all processes
            Process[] processes = Process.GetProcesses();

            // checking each processor
            for (int i = 0; i < processes.Length; i++)
            {
                TreeNodeCollection nodes = treeViewProcesses.Nodes;  // collection of nodes in threeView
                bool isContain = false;                              // bool var for contain

                for (int j = 0; j < nodes.Count; j++)
                {
                    // Does such a node already exist 
                    if (nodes[j].Text.Contains(processes[i].ProcessName))
                    {
                        isContain = true;
                    }
                }

                // if node doesn't exist - creating new node
                if (!isContain)
                {
                    TreeNode newNode = new TreeNode(processes[i].ProcessName);
                    newNode.BackColor = Color.Yellow;
                    treeViewProcesses.Nodes.Add(newNode);

                }
            }
        }

        private void buttonBrowserStart_Click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                processes.Add(Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"));  // starting proc
                isStart = true;                               // toggle var to true
            }
            else MessageBox.Show("Process already started");
        }

        private void buttonBrowserStop_Click(object sender, EventArgs e)
        {
            // stopping all processes
            foreach (var proc in processes)
            {
                proc.Kill();
                proc.Dispose();
            }
            isStart = false;  // toggling var to false
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            processes.Add(Process.Start(
                    @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                                                       "https://mystat.itstep.org/"));
        }

        private void linkLabelOdItStep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            processes.Add(Process.Start(
                    @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                                                       "https://od.itstep.org/"));
        }

        private void linkLabelItStep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            processes.Add(Process.Start(
                    @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                                                       "https://itstep.org/"));
        }
    }
}
