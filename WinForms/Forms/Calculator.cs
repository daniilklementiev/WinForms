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

namespace WinForms.Forms
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        public static bool BlockOperator { get; set; }

        static Calculator()
        {
            BlockOperator = true;
        }

        private void Calculator_Load(object sender, EventArgs e)
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
            richTextBox.Clear();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            History.Text = String.Empty;
        }
    }
}
