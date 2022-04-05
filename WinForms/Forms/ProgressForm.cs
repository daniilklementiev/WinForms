using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WinForms.Forms
{
    public partial class ProgressForm : Form
    {
        private readonly NLog.Logger _logger;
        private readonly Random      _random;
        private          float       _progressTime;
        public ProgressForm(NLog.Logger logger, Random random)
        {
            _logger = logger;
            _random = random;
            InitializeComponent();
        }
        private void ProgressForm_Load(object sender, EventArgs e)
        {
            listBoxStyle.Items.Add(new BarStyle { Title = "Thin", Height = 15 });
            listBoxStyle.Items.Add(new BarStyle { Title = "Norm", Height = 23 });
            listBoxStyle.Items.Add(new BarStyle { Title = "Tall", Height = 46 });
            listBoxStyle.SelectedIndex = 1;

            comboBoxTime.Items.Add("1");
            comboBoxTime.Items.Add("2");
            comboBoxTime.Items.Add("3");
            comboBoxTime.SelectedIndex = 0; // "1" - default index
            _progressTime = 1;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            // progressBar1.Value = 50;
        }
        private void listBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStyle.SelectedItem == null) return;
            // MessageBox.Show(listBoxStyle.SelectedItem.ToString());
            progressBar1.Height = ((BarStyle)listBoxStyle.SelectedItem).Height;


        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                progressBar1.Value = i;
                timeEllapsedLabel.Text = sw.Elapsed.ToString();
                Thread.Sleep(((int)_progressTime)*10);
            }
            sw.Stop();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxTime.SelectedIndex == -1) return;
            if (comboBoxTime.Text == String.Empty) return;
            _progressTime = Convert.ToSingle(comboBoxTime.Text);
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            String content = String.Empty;
            if (comboBoxTime.Text.Contains("."))
                content = comboBoxTime.Text.Replace('.', ',');
            else content = comboBoxTime.Text;

            try
            {
                float res = Convert.ToSingle(content);
                if (res < 10 && res > 0)
                    comboBoxTime.Items.Add(content);
                else MessageBox.Show("Инвалид инпут! Введите дробное число от 0 до 10");
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                MessageBox.Show("Инвалид инпут! Введите дробное число от 0 до 10");
            }  
        }
    }
    class BarStyle
    {
        public String? Title { get; set; }
        public int Height { get; set; }
        public override string ToString()
        {
            return Title ?? "--";
        }
    }
}
