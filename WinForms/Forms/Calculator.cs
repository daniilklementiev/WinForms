using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WinForms.Forms
{
    public partial class Calculator : Form
    {
        private static Logger logger;
        private Operations operation; // Saved operation after push button
        public Calculator()
        {
            InitializeComponent();
            operation = Operations.None;
            logger = LogManager.GetCurrentClassLogger();
        }
        public static bool BlockOperator { get; set; }

        static Calculator()
        {
            BlockOperator = true;
            logger = LogManager.GetCurrentClassLogger();
        }
        
        private void Calculator_Load(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null)
            {
                // Exception: invalid sender. Log'em it
                logger.Error("Invalid sender");
                return;
            }

            if (clickedButton == buttonAdd) operation = Operations.Add;
            else if (clickedButton == buttonSub) operation = Operations.Sub;
            else if (clickedButton == buttonDiv) operation = Operations.Div;
            else if (clickedButton == buttonMul) operation = Operations.Mul;
            else
            {
                // Exception: invalid button. Log'em it
                logger.Error("Invalid button clicked");
                return;
            }
        }
        private void buttonOperatin_Click(object sender, EventArgs e)
        {

        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            var answer = new DataTable().Compute(richTextBox.Text.Replace('x', '*').Replace('÷', '/'), null);
            History.Text = richTextBox.Text;
            richTextBox.Text = answer.ToString();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            var clicked = sender as Button;
            if (clicked == null)
            {
                return;
            }

            if (clicked.Text.Equals("+/-"))
            {
                if (richTextBox.Text.StartsWith("-"))
                {
                    richTextBox.Text=richTextBox.Text.Substring(1);
                }
                else
                {
                    richTextBox.Text = "-" + richTextBox.Text;
                }
            }
            else
            {
                richTextBox.Text += clicked.Text;
            }

        }

        private void buttonDigit_Click(object sender, EventArgs e)
        {
            var clicked = sender as Button;
            if (clicked == null)
            {
                return;
            }

            if (richTextBox.Text.Equals("0"))
            {
                richTextBox.Text = "";
            }

            richTextBox.Text += clicked.Text;
        }

        private void buttonClearLast_Click(object sender, EventArgs e)
        {
            int lenght = richTextBox.Text.Length - 1;
            string text = richTextBox.Text;
            richTextBox.Clear();
            for (int i = 0; i < lenght; i++)
            {
                richTextBox.Text = richTextBox.Text + text[i];
            }

        }

        private void buttonClearDisp_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "0";
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "0";
            History.Text = String.Empty;
        }
    }

    enum Operations
    {
        None,
        Add,
        Sub,
        Mul,
        Div
    }
}
