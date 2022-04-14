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
        public ProcessForm()
        {
            isStart = false;
            processes = new();
            InitializeComponent();
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
        }
    }
}
