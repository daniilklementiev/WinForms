namespace WinForms
{
    partial class HashForm
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
            this.buttonMd5 = new System.Windows.Forms.Button();
            this.textBoxMd5 = new System.Windows.Forms.TextBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonSha1 = new System.Windows.Forms.Button();
            this.textBoxSha1 = new System.Windows.Forms.TextBox();
            this.buttonSha256 = new System.Windows.Forms.Button();
            this.textBoxSha256 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonMd5
            // 
            this.buttonMd5.Location = new System.Drawing.Point(12, 192);
            this.buttonMd5.Name = "buttonMd5";
            this.buttonMd5.Size = new System.Drawing.Size(150, 46);
            this.buttonMd5.TabIndex = 0;
            this.buttonMd5.Text = "MD5";
            this.buttonMd5.UseVisualStyleBackColor = true;
            this.buttonMd5.Click += new System.EventHandler(this.buttonMd5_Click);
            // 
            // textBoxMd5
            // 
            this.textBoxMd5.Font = new System.Drawing.Font("Courier New", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxMd5.Location = new System.Drawing.Point(198, 192);
            this.textBoxMd5.Multiline = true;
            this.textBoxMd5.Name = "textBoxMd5";
            this.textBoxMd5.ReadOnly = true;
            this.textBoxMd5.Size = new System.Drawing.Size(846, 46);
            this.textBoxMd5.TabIndex = 1;
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 2);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(1032, 158);
            this.textBoxSource.TabIndex = 2;
            this.textBoxSource.Text = "Hello, World!";
            // 
            // buttonSha1
            // 
            this.buttonSha1.Location = new System.Drawing.Point(12, 258);
            this.buttonSha1.Name = "buttonSha1";
            this.buttonSha1.Size = new System.Drawing.Size(150, 46);
            this.buttonSha1.TabIndex = 0;
            this.buttonSha1.Text = "Sha1";
            this.buttonSha1.UseVisualStyleBackColor = true;
            this.buttonSha1.Click += new System.EventHandler(this.buttonSha1_Click);
            // 
            // textBoxSha1
            // 
            this.textBoxSha1.Font = new System.Drawing.Font("Courier New", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSha1.Location = new System.Drawing.Point(198, 258);
            this.textBoxSha1.Multiline = true;
            this.textBoxSha1.Name = "textBoxSha1";
            this.textBoxSha1.ReadOnly = true;
            this.textBoxSha1.Size = new System.Drawing.Size(846, 84);
            this.textBoxSha1.TabIndex = 1;
            // 
            // buttonSha256
            // 
            this.buttonSha256.Location = new System.Drawing.Point(12, 374);
            this.buttonSha256.Name = "buttonSha256";
            this.buttonSha256.Size = new System.Drawing.Size(150, 46);
            this.buttonSha256.TabIndex = 0;
            this.buttonSha256.Text = "Sha256";
            this.buttonSha256.UseVisualStyleBackColor = true;
            this.buttonSha256.Click += new System.EventHandler(this.buttonSha256_Click);
            // 
            // textBoxSha256
            // 
            this.textBoxSha256.Font = new System.Drawing.Font("Courier New", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSha256.Location = new System.Drawing.Point(198, 374);
            this.textBoxSha256.Multiline = true;
            this.textBoxSha256.Name = "textBoxSha256";
            this.textBoxSha256.ReadOnly = true;
            this.textBoxSha256.Size = new System.Drawing.Size(846, 126);
            this.textBoxSha256.TabIndex = 1;
            // 
            // HashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 626);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.textBoxSha256);
            this.Controls.Add(this.buttonSha256);
            this.Controls.Add(this.textBoxSha1);
            this.Controls.Add(this.buttonSha1);
            this.Controls.Add(this.textBoxMd5);
            this.Controls.Add(this.buttonMd5);
            this.Name = "HashForm";
            this.Text = "HashForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMd5;
        private System.Windows.Forms.TextBox textBoxMd5;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonSha1;
        private System.Windows.Forms.TextBox textBoxSha1;
        private System.Windows.Forms.Button buttonSha256;
        private System.Windows.Forms.TextBox textBoxSha256;
    }
}