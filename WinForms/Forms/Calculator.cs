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
        private readonly Logger _logger;
        private Operations operation; // Saved operation after push button
        private int firstArg; // Saved value after operation button
        private bool remember;
        private bool equalFlag;
        public Calculator(NLog.Logger logger)
        {
            InitializeComponent();
            operation = Operations.None;
            _logger = logger; // привязка логгера
            remember = false;
            equalFlag = false;
        }
        public static bool BlockOperator { get; set; }

        static Calculator()
        {
            BlockOperator = true;
        }


        private void buttonOperation_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null)
            {
                // Exception: invalid sender. Log'em it
                _logger.Error("Invalid sender" + sender);
                return;
            }
            // Если вместо = нажимается другая операция - обновляется история
            if (!History.Text.Contains("="))
            {
                if (History.Text.Contains("+"))
                {
                    operation = Operations.Add;
                    buttonEquals_Click(sender, e);
                }
                else if (History.Text.Contains("-"))
                {
                    operation = Operations.Sub;
                    buttonEquals_Click(sender, e);
                }
                else if (History.Text.Contains("÷"))
                {
                    operation = Operations.Div;
                    buttonEquals_Click(sender, e);
                }
                else if (History.Text.Contains("x"))
                {
                    operation = Operations.Mul;
                    buttonEquals_Click(sender, e);
                }
            }

            if (clickedButton == buttonAdd) { operation = Operations.Add; remember = true; }
            else if (clickedButton == buttonSub) { operation = Operations.Sub; remember = true; }
            else if (clickedButton == buttonDiv) { operation = Operations.Div; remember = true; }
            else if (clickedButton == buttonMul) { operation = Operations.Mul; remember = true; }
            else
            {
                // Exception: invalid button. Log'em it
                _logger.Error("Invalid button clicked {0}", sender.ToString());
                return;
            }

            // Update Top label
            History.Text = richTextBox.Text + " " + clickedButton.Text;
            // Remember first argument
            firstArg = Convert.ToInt32(richTextBox.Text);
            // Clear display to enter next number
            richTextBox.Text = firstArg.ToString();
            
        }

        /** Event handler for '=' button
         */
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            /*var answer = new DataTable().Compute(richTextBox.Text.Replace('x', '*').Replace('÷', '/'), null);
            History.Text = richTextBox.Text;
            richTextBox.Text = answer.ToString();*/
            int secondArg = Convert.ToInt32(richTextBox.Text);
            float res = 0;
            

            switch (operation)
            {
                case Operations.None:
                    MessageBox.Show("No operation");
                    return;
                case Operations.Add:
                    res = firstArg + secondArg;
                    break;
                case Operations.Sub:
                    res = firstArg - secondArg;
                    break;
                case Operations.Mul:
                    res = firstArg * secondArg;
                    break;
                case Operations.Div: 
                    res = (float)firstArg / secondArg;
                    break;
            }
            // Обновляем историю
            History.Text += " " + secondArg + " =";
            // Показываем результат
            richTextBox.Text = res.ToString();
            // Изменяем флаг на true для того, чтобы после нажатия следующей кнопки очищался дисплей и история
            equalFlag = true;
            // Очищаем операцию
            operation = Operations.None;
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
                    richTextBox.Text = richTextBox.Text.Substring(1);
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
            if (equalFlag == true)
            {
                richTextBox.Text = "0";
                History.Text = String.Empty;
                equalFlag = false;
            }
            if(remember == true)
            {
                richTextBox.Text = "";
                remember = false;
            }
            if (richTextBox.Text.Equals("0"))
            {
                richTextBox.Text = "";
            }
            if (!remember)
            {
                richTextBox.Text += clicked.Text;
            }
            else
            {
                richTextBox.Text = clicked.Text;
                remember = false;
            }

            //richTextBox.Text += clicked.Text;
        }

        private void buttonClearLast_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text.Length > 1)
            {
                richTextBox.Text = richTextBox.Text.Substring(0, (richTextBox.Text.Length - 1));
            }
            else
            {
                richTextBox.Text = "0";
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

        private void Calculator_Load(object sender, EventArgs e)
        {
            History.Text = String.Empty;
            foreach(var cont in Controls)
            {
                var b = cont as Button;
                if (b != null)
                {
                    b.Click += (sender, e) => this.ActiveControl = null;
                }
            }
        }
    }

    enum Operations // перечисление кнопок операций
    {
        None,
        Add,
        Sub,
        Mul,
        Div
    }
}
