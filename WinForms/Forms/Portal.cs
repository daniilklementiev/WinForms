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
            new Form1().ShowDialog();
        }

        private void Calculator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Calculator(_logger).ShowDialog();
        }

        private void Progress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Container.Resolve<Forms.ProgressForm>().ShowDialog();
        }

        private void linkLabel2048_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Container.Resolve<Forms.Game2048>().ShowDialog();
        }

        private void linkGdi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Container.Resolve<Forms.GDIForm>().ShowDialog();
        }

        private void linkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Container.Resolve<Forms.ProcessForm>().ShowDialog();
        }
    }
}
