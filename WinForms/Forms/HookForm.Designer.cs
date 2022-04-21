namespace WinForms.Forms
{
    partial class HookForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxReplaces = new System.Windows.Forms.GroupBox();
            this.buttonAddReplace = new System.Windows.Forms.Button();
            this.textBoxSourceKey = new System.Windows.Forms.TextBox();
            this.textBoxTargetKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxReplaces = new System.Windows.Forms.ListBox();
            this.richTextBoxKb = new System.Windows.Forms.RichTextBox();
            this.buttonKbStop = new System.Windows.Forms.Button();
            this.buttonKbStart = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxMs = new System.Windows.Forms.ListBox();
            this.buttonMsStop = new System.Windows.Forms.Button();
            this.buttonMsStart = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxReplaces.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1290, 616);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxReplaces);
            this.tabPage1.Controls.Add(this.richTextBoxKb);
            this.tabPage1.Controls.Add(this.buttonKbStop);
            this.tabPage1.Controls.Add(this.buttonKbStart);
            this.tabPage1.Location = new System.Drawing.Point(8, 43);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1274, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Keyboard (disactive)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxReplaces
            // 
            this.groupBoxReplaces.Controls.Add(this.buttonAddReplace);
            this.groupBoxReplaces.Controls.Add(this.textBoxSourceKey);
            this.groupBoxReplaces.Controls.Add(this.textBoxTargetKey);
            this.groupBoxReplaces.Controls.Add(this.label1);
            this.groupBoxReplaces.Controls.Add(this.listBoxReplaces);
            this.groupBoxReplaces.Location = new System.Drawing.Point(689, 54);
            this.groupBoxReplaces.Name = "groupBoxReplaces";
            this.groupBoxReplaces.Size = new System.Drawing.Size(410, 358);
            this.groupBoxReplaces.TabIndex = 3;
            this.groupBoxReplaces.TabStop = false;
            this.groupBoxReplaces.Text = "Replaces";
            // 
            // buttonAddReplace
            // 
            this.buttonAddReplace.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddReplace.Location = new System.Drawing.Point(144, 290);
            this.buttonAddReplace.Name = "buttonAddReplace";
            this.buttonAddReplace.Size = new System.Drawing.Size(128, 45);
            this.buttonAddReplace.TabIndex = 3;
            this.buttonAddReplace.Text = "+";
            this.buttonAddReplace.UseVisualStyleBackColor = true;
            // 
            // textBoxSourceKey
            // 
            this.textBoxSourceKey.Location = new System.Drawing.Point(12, 243);
            this.textBoxSourceKey.Multiline = true;
            this.textBoxSourceKey.Name = "textBoxSourceKey";
            this.textBoxSourceKey.Size = new System.Drawing.Size(148, 41);
            this.textBoxSourceKey.TabIndex = 2;
            this.textBoxSourceKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSourceKey_KeyDown);
            // 
            // textBoxTargetKey
            // 
            this.textBoxTargetKey.Location = new System.Drawing.Point(256, 243);
            this.textBoxTargetKey.Multiline = true;
            this.textBoxTargetKey.Name = "textBoxTargetKey";
            this.textBoxTargetKey.Size = new System.Drawing.Size(148, 41);
            this.textBoxTargetKey.TabIndex = 2;
            this.textBoxTargetKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSourceKey_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "---->";
            // 
            // listBoxReplaces
            // 
            this.listBoxReplaces.FormattingEnabled = true;
            this.listBoxReplaces.ItemHeight = 29;
            this.listBoxReplaces.Location = new System.Drawing.Point(12, 34);
            this.listBoxReplaces.Name = "listBoxReplaces";
            this.listBoxReplaces.Size = new System.Drawing.Size(384, 178);
            this.listBoxReplaces.TabIndex = 0;
            // 
            // richTextBoxKb
            // 
            this.richTextBoxKb.Location = new System.Drawing.Point(211, 54);
            this.richTextBoxKb.Name = "richTextBoxKb";
            this.richTextBoxKb.ReadOnly = true;
            this.richTextBoxKb.Size = new System.Drawing.Size(448, 358);
            this.richTextBoxKb.TabIndex = 2;
            this.richTextBoxKb.Text = "";
            // 
            // buttonKbStop
            // 
            this.buttonKbStop.Location = new System.Drawing.Point(31, 124);
            this.buttonKbStop.Name = "buttonKbStop";
            this.buttonKbStop.Size = new System.Drawing.Size(150, 46);
            this.buttonKbStop.TabIndex = 1;
            this.buttonKbStop.Text = "Stop";
            this.buttonKbStop.UseVisualStyleBackColor = true;
            this.buttonKbStop.Click += new System.EventHandler(this.buttonKbStop_Click);
            // 
            // buttonKbStart
            // 
            this.buttonKbStart.Location = new System.Drawing.Point(31, 48);
            this.buttonKbStart.Name = "buttonKbStart";
            this.buttonKbStart.Size = new System.Drawing.Size(150, 46);
            this.buttonKbStart.TabIndex = 0;
            this.buttonKbStart.Text = "Start";
            this.buttonKbStart.UseVisualStyleBackColor = true;
            this.buttonKbStart.Click += new System.EventHandler(this.buttonKbStart_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.listBoxMs);
            this.tabPage2.Controls.Add(this.buttonMsStop);
            this.tabPage2.Controls.Add(this.buttonMsStart);
            this.tabPage2.Location = new System.Drawing.Point(8, 43);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1274, 565);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mouse (disactive)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(20, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(458, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxMs
            // 
            this.listBoxMs.FormattingEnabled = true;
            this.listBoxMs.ItemHeight = 29;
            this.listBoxMs.Location = new System.Drawing.Point(516, 20);
            this.listBoxMs.Name = "listBoxMs";
            this.listBoxMs.Size = new System.Drawing.Size(678, 497);
            this.listBoxMs.TabIndex = 2;
            // 
            // buttonMsStop
            // 
            this.buttonMsStop.Location = new System.Drawing.Point(20, 96);
            this.buttonMsStop.Name = "buttonMsStop";
            this.buttonMsStop.Size = new System.Drawing.Size(150, 46);
            this.buttonMsStop.TabIndex = 1;
            this.buttonMsStop.Text = "Stop";
            this.buttonMsStop.UseVisualStyleBackColor = true;
            this.buttonMsStop.Click += new System.EventHandler(this.buttonMsStop_Click);
            // 
            // buttonMsStart
            // 
            this.buttonMsStart.Location = new System.Drawing.Point(20, 20);
            this.buttonMsStart.Name = "buttonMsStart";
            this.buttonMsStart.Size = new System.Drawing.Size(150, 46);
            this.buttonMsStart.TabIndex = 0;
            this.buttonMsStart.Text = "Start";
            this.buttonMsStart.UseVisualStyleBackColor = true;
            this.buttonMsStart.Click += new System.EventHandler(this.buttonMsStart_Click);
            // 
            // HookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 756);
            this.Controls.Add(this.tabControl1);
            this.Name = "HookForm";
            this.Text = "HookForm";
            this.Load += new System.EventHandler(this.HookForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxReplaces.ResumeLayout(false);
            this.groupBoxReplaces.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBoxKb;
        private System.Windows.Forms.Button buttonKbStop;
        private System.Windows.Forms.Button buttonKbStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxMs;
        private System.Windows.Forms.Button buttonMsStop;
        private System.Windows.Forms.Button buttonMsStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxReplaces;
        private System.Windows.Forms.Button buttonAddReplace;
        private System.Windows.Forms.TextBox textBoxSourceKey;
        private System.Windows.Forms.TextBox textBoxTargetKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxReplaces;
    }
}