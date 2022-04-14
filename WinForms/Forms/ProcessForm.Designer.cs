namespace WinForms.Forms
{
    partial class ProcessForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonNotepadLog = new System.Windows.Forms.Button();
            this.buttonNotepadStop = new System.Windows.Forms.Button();
            this.buttonNotepadStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дочерние процессы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonNotepadLog);
            this.groupBox2.Controls.Add(this.buttonNotepadStop);
            this.groupBox2.Controls.Add(this.buttonNotepadStart);
            this.groupBox2.Location = new System.Drawing.Point(97, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 183);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Блокнот";
            // 
            // buttonNotepadLog
            // 
            this.buttonNotepadLog.Location = new System.Drawing.Point(21, 130);
            this.buttonNotepadLog.Name = "buttonNotepadLog";
            this.buttonNotepadLog.Size = new System.Drawing.Size(126, 40);
            this.buttonNotepadLog.TabIndex = 1;
            this.buttonNotepadLog.Text = "Журнал";
            this.buttonNotepadLog.UseVisualStyleBackColor = true;
            this.buttonNotepadLog.Click += new System.EventHandler(this.buttonNotepadLog_Click);
            // 
            // buttonNotepadStop
            // 
            this.buttonNotepadStop.Location = new System.Drawing.Point(21, 84);
            this.buttonNotepadStop.Name = "buttonNotepadStop";
            this.buttonNotepadStop.Size = new System.Drawing.Size(126, 40);
            this.buttonNotepadStop.TabIndex = 1;
            this.buttonNotepadStop.Text = "Стоп";
            this.buttonNotepadStop.UseVisualStyleBackColor = true;
            this.buttonNotepadStop.Click += new System.EventHandler(this.buttonNotepadStop_Click);
            // 
            // buttonNotepadStart
            // 
            this.buttonNotepadStart.Location = new System.Drawing.Point(21, 38);
            this.buttonNotepadStart.Name = "buttonNotepadStart";
            this.buttonNotepadStart.Size = new System.Drawing.Size(126, 40);
            this.buttonNotepadStart.TabIndex = 1;
            this.buttonNotepadStart.Text = "Пуск";
            this.buttonNotepadStart.UseVisualStyleBackColor = true;
            this.buttonNotepadStart.Click += new System.EventHandler(this.buttonNotepadStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 0;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProcessForm";
            this.Text = "ProcessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonNotepadStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonNotepadLog;
        private System.Windows.Forms.Button buttonNotepadStop;
    }
}