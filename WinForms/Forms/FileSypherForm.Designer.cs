namespace WinForms.Forms
{
    partial class FileSypherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeSampleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSourceFileName = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCipher = new System.Windows.Forms.Button();
            this.panelTarget = new System.Windows.Forms.Panel();
            this.buttonSelectTarget = new System.Windows.Forms.Button();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1112, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeSampleMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // makeSampleMenuItem
            // 
            this.makeSampleMenuItem.Name = "makeSampleMenuItem";
            this.makeSampleMenuItem.Size = new System.Drawing.Size(289, 44);
            this.makeSampleMenuItem.Text = "Make sample";
            this.makeSampleMenuItem.Click += new System.EventHandler(this.makeSampleMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(289, 44);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a file";
            // 
            // textBoxSourceFileName
            // 
            this.textBoxSourceFileName.Location = new System.Drawing.Point(212, 100);
            this.textBoxSourceFileName.Name = "textBoxSourceFileName";
            this.textBoxSourceFileName.Size = new System.Drawing.Size(200, 39);
            this.textBoxSourceFileName.TabIndex = 2;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(428, 100);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(64, 38);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(212, 161);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(200, 39);
            this.textBoxPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter a password";
            // 
            // buttonCipher
            // 
            this.buttonCipher.Location = new System.Drawing.Point(26, 206);
            this.buttonCipher.Name = "buttonCipher";
            this.buttonCipher.Size = new System.Drawing.Size(144, 38);
            this.buttonCipher.TabIndex = 3;
            this.buttonCipher.Text = "Cipher";
            this.buttonCipher.UseVisualStyleBackColor = true;
            this.buttonCipher.Click += new System.EventHandler(this.buttonCipher_Click);
            // 
            // panelTarget
            // 
            this.panelTarget.Controls.Add(this.buttonSelectTarget);
            this.panelTarget.Controls.Add(this.textBoxTarget);
            this.panelTarget.Controls.Add(this.label3);
            this.panelTarget.Location = new System.Drawing.Point(599, 43);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Size = new System.Drawing.Size(400, 116);
            this.panelTarget.TabIndex = 4;
            // 
            // buttonSelectTarget
            // 
            this.buttonSelectTarget.Location = new System.Drawing.Point(303, 50);
            this.buttonSelectTarget.Name = "buttonSelectTarget";
            this.buttonSelectTarget.Size = new System.Drawing.Size(58, 42);
            this.buttonSelectTarget.TabIndex = 2;
            this.buttonSelectTarget.Text = "...";
            this.buttonSelectTarget.UseVisualStyleBackColor = true;
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(97, 50);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(200, 39);
            this.textBoxTarget.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Target";
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.Location = new System.Drawing.Point(418, 161);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(74, 39);
            this.buttonShowPassword.TabIndex = 5;
            this.buttonShowPassword.Text = "👁";
            this.buttonShowPassword.UseVisualStyleBackColor = true;
            this.buttonShowPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShowPassword_MouseDown);
            this.buttonShowPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShowPassword_MouseUp);
            // 
            // FileSypherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 724);
            this.Controls.Add(this.buttonShowPassword);
            this.Controls.Add(this.panelTarget);
            this.Controls.Add(this.buttonCipher);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSourceFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileSypherForm";
            this.Text = "FileSypherForm";
            this.Load += new System.EventHandler(this.FileSypherForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTarget.ResumeLayout(false);
            this.panelTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSourceFileName;
        private System.Windows.Forms.Button buttonSelectFile;
        private WinForms.Controls.RoundButton rButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCipher;
        private System.Windows.Forms.ToolStripMenuItem makeSampleMenuItem;
        private System.Windows.Forms.Panel panelTarget;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSelectTarget;
        private System.Windows.Forms.Button buttonShowPassword;
    }
}