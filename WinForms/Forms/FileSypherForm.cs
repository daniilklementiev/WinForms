using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class FileSypherForm : Form
    {

        private const String SAMPLE_FILENAME = "sample.txt";
        private const String SAMPLE_CONTENT  = "Hello World!";
        private char PASSWORD_CHAR;
        private bool cancel;

        private CipherData cipherData;
        private CancellationTokenSource cancellationTokenSource;
        
        private int progressValue; // exchange variable - to show from other thread
        
        public FileSypherForm()
        {
            InitializeComponent();
            cipherData = new CipherData();
            cancellationTokenSource = null!;
            cancel = false;
        }
        
        private void FileSypherForm_Load(object sender, EventArgs e)
        {
            panelProgress.Visible = false;
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
            
            // Check if source file exists
            if (textBoxSourceFileName.Text == String.Empty)
            {
                MessageBox.Show("Select source file first!");
                return;
            }
            else if(textBoxPassword.Text == String.Empty)
            {
                MessageBox.Show("Input password!");
                return;
            }
            else
            {
                cipherData.Password = textBoxPassword.Text; // get password
                cancellationTokenSource = new CancellationTokenSource();
                progressValue = 0;
                panelProgress.Visible = true;                
                new Thread(Cipher).Start(new ThreadData
                {
                    CipherData = cipherData,
                    cts = cancellationTokenSource.Token
                });                

            }
        }
        private void Cipher(object? data)
        {
            
            if (data is null || data is not ThreadData) return;
            ThreadData td = (ThreadData)data;
            if (td.CipherData is null) return;
            // open source file for reading
            try
            {
                // Source file size
                long fileSize = new FileInfo(td.CipherData.SourceFile).Length;
                
                // open source file for reading
                using (StreamReader sr = new StreamReader(td.CipherData.SourceFile))
                {
                    // open target file for writing
                    using (StreamWriter sw = new StreamWriter(td.CipherData.TargetFile))
                    {
                        int cnt = 0;
                        while(!sr.EndOfStream)
                        {
                            char symT = (char)sr.Read(); // read symbol from source file
                            char symP = td.CipherData.Password[cnt % td.CipherData.Password.Length]; // get password symbol
                            char symCipher = (char)(symT ^ symP); // cipher symbol 
                            // write to target file
                            sw.Write(symCipher);
                            cnt++;
                            
                            // display progress
                            progressValue = (int)((cnt * 100) / fileSize); // calculate value
                            Invoke( (Action) UpdateProgress);
                            Thread.Sleep(300);
                            if (cancel)
                            {
                                if (DialogResult.Yes == MessageBox.Show("Sure?", "Ciphering stopped", MessageBoxButtons.YesNo))
                                {
                                    throw new OperationCanceledException();
                                }
                                cancel = false;
                            }
                        }
                        
                    }
                }
                // Ciphering finished successfully
                var res = MessageBox.Show("Open in notepad?","Ciphering finished successfully", MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    Process.Start("notepad.exe", td.CipherData.TargetFile);
                }
            }
            catch(IOException ex) // IO problem - file reading/writing
            {
                MessageBox.Show(ex.Message);
            }
            catch(OperationCanceledException) // Cancellation
            {
                cancel = false;
            }
            finally
            {
                // Ciphering finished with any state 
                Invoke((Action)HidePanelProgress);
                Invoke((Action)ClearBoxes);
            }
           
        }
        
        /// <summary>
        /// Set ProgressBar to progressValue - from any thread
        /// </summary>
        private void UpdateProgress()
        {
            lock (progressBarCiphering)
            {
                progressBarCiphering.Value = progressValue;
            }
        }

        private void ClearBoxes()
        {
            lock(textBoxPassword)
            {
                textBoxPassword.Text = String.Empty;
            }
            lock (textBoxSourceFileName) 
            {
                textBoxSourceFileName.Text = String.Empty;
            }
            lock (textBoxTarget)
            {
                textBoxTarget.Text = String.Empty;
            }
        }

        /// <summary>
        /// Cross thread method to set panel invisible
        /// </summary>
        private void HidePanelProgress()
        {
            lock (progressBarCiphering)
            {
                if (panelProgress.Visible) panelProgress.Visible = false;
            }
        }


        private void buttonShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            
            PASSWORD_CHAR = textBoxPassword.PasswordChar == PASSWORD_CHAR ? PASSWORD_CHAR = '\0' : PASSWORD_CHAR = '*';
            textBoxPassword.PasswordChar = PASSWORD_CHAR;
            buttonShowPassword.Text = "🐵";
        }

        private void buttonShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            PASSWORD_CHAR = textBoxPassword.PasswordChar == '\0' ? PASSWORD_CHAR = '*' : PASSWORD_CHAR = '\0';
            textBoxPassword.PasswordChar = PASSWORD_CHAR;
            buttonShowPassword.Text = "🙈";
        }

        private void buttonCancelProgress_Click(object sender, EventArgs e)
        {
            cancel = true;
            cancellationTokenSource.Cancel();
        }
    }

    // data to pass in cipher thread
    class ThreadData
    {
        public CipherData? CipherData { get; set; }
        public CancellationToken cts { get; set; }
    }

    class CipherData
    {
        public String SourceFile { get; set; } = String.Empty;
        public String TargetFile { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        
        
    }
}
