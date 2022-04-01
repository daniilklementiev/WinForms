﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
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
    }
}
