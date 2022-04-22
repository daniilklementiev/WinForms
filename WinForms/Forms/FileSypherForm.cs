using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class FileSypherForm : Form
    {

        private const String SAMPLE_FILENAME = "sample.txt";
        private const String SAMPLE_CONTENT  = "Hello World!";
        private char PASSWORD_CHAR;

        private CipherData cipherData;
        
        public FileSypherForm()
        {
            cipherData = new CipherData();
            InitializeComponent();
        }
        
        private void FileSypherForm_Load(object sender, EventArgs e)
        {
            panelTarget.Visible = false;
            PASSWORD_CHAR = textBoxPassword.PasswordChar;   // Design priority
            if (PASSWORD_CHAR == '\0')                      // if no design sym use default
            {
                PASSWORD_CHAR = '*';
                textBoxPassword.PasswordChar = PASSWORD_CHAR;
            }
        }

        /// <summary>
        /// Creates file "sample.txt" in application startup folder and writes "Hello World!" to it.
        /// </summary>
        private void makeSampleMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(SAMPLE_FILENAME, SAMPLE_CONTENT);
        }

        /// <summary>
        /// Selects file (name) for encryption - source file
        /// using fileOpenDialog resource
        /// </summary>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "sample.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fullPath = openFileDialog1.FileName;
                String Name = Path.GetFileNameWithoutExtension(fullPath);
                String nameExt = Path.GetFileName(fullPath);
                String dir = Path.GetDirectoryName(fullPath) ?? String.Empty;
                
                textBoxSourceFileName.Text = nameExt;
                panelTarget.Visible = true;
                // TODO: Form target file name: source name + ".enc" 
                textBoxTarget.Text = Name + ".enc";

                cipherData.SourceFile = fullPath;
                cipherData.TargetFile = Path.Combine(dir, textBoxTarget.Text);

            }
            else
            {
                textBoxSourceFileName.Text = String.Empty;
                panelTarget.Visible = false;
            }
        }

        private void buttonCipher_Click(object sender, EventArgs e)
        {
            // show mb source file -> target file
            if (textBoxSourceFileName.Text == String.Empty)
            {
                MessageBox.Show("Select source file first!");
                return;
            }
            else
            {
                MessageBox.Show($"{cipherData.SourceFile}\r\n \t\t|\r\n\t\tV \r\n{cipherData.TargetFile}");
            }
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            PASSWORD_CHAR = textBoxPassword.PasswordChar == '\0' ? PASSWORD_CHAR = '*' : PASSWORD_CHAR = '\0';
            textBoxPassword.PasswordChar = PASSWORD_CHAR;
        }
    }

    class CipherData
    {
        public String SourceFile { get; set; } = String.Empty;
        public String TargetFile { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
    }
}
