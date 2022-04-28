using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using Microsoft.Practices.Unity;

namespace WinForms.Forms
{
    public partial class Portal : Form
    {
        private readonly NLog.Logger _logger;
        public Portal(NLog.Logger logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private void Intro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Show();
        }

        private void Calculator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Calculator(_logger).ShowDialog();
            this.Show();
        }

        private void Progress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();            
            Program.Container.Resolve<Forms.ProgressForm>().ShowDialog();
            this.Show();
        }

        private void linkLabel2048_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();            
            Program.Container.Resolve<Forms.Game2048>().ShowDialog();
            this.Show();
        }

        private void linkGdi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.Container.Resolve<Forms.GDIForm>().ShowDialog();
            this.Show();
        }

        private void linkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.Container.Resolve<Forms.ProcessForm>().ShowDialog();
            this.Show();
        }

        private void linkLabelPatterns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.Container.Resolve<Forms.MvPatternsForm>().ShowDialog();
            this.Show();
        }

        private void linkLabelHooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.Container.Resolve<Forms.HookForm>().ShowDialog();
            this.Show();
        }

        private void linkLabelAsync1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();     // hide - visible = false
            Program.Container.Resolve<Forms.FileSypherForm>().ShowDialog();
            this.Show();    // visible = true
        }

        private void linkLabel2Async_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Program.Container.Resolve<Forms.FractalForm>().ShowDialog();
            this.Show();    
        }
    }
}
