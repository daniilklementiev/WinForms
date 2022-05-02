using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class HashForm : Form
    {
        public HashForm()
        {
            InitializeComponent();
        }

        private void buttonMd5_Click(object sender, EventArgs e)
        {
            textBoxMd5.Text = MyLibrary.Hash.Md5(textBoxSource.Text);
        }

        private void buttonSha1_Click(object sender, EventArgs e)
        {
            textBoxSha1.Text = MyLibrary.Hash.Sha1(textBoxSource.Text);
        }

        private void buttonSha256_Click(object sender, EventArgs e)
        {
            textBoxSha256.Text = MyLibrary.Hash.Sha256(textBoxSource.Text);
        }
    }
}
