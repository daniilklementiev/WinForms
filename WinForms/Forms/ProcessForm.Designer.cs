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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabelOdItStep = new System.Windows.Forms.LinkLabel();
            this.linkLabelItStep = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonBrowserStop = new System.Windows.Forms.Button();
            this.buttonBrowserStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonNotepadLog = new System.Windows.Forms.Button();
            this.buttonNotepadStop = new System.Windows.Forms.Button();
            this.buttonNotepadStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.treeViewProcesses = new System.Windows.Forms.TreeView();
            this.timerRefresher = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelOdItStep);
            this.groupBox1.Controls.Add(this.linkLabelItStep);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 640);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дочерние процессы";
            // 
            // linkLabelOdItStep
            // 
            this.linkLabelOdItStep.AutoSize = true;
            this.linkLabelOdItStep.LinkVisited = true;
            this.linkLabelOdItStep.Location = new System.Drawing.Point(53, 534);
            this.linkLabelOdItStep.Name = "linkLabelOdItStep";
            this.linkLabelOdItStep.Size = new System.Drawing.Size(224, 32);
            this.linkLabelOdItStep.TabIndex = 1;
            this.linkLabelOdItStep.TabStop = true;
            this.linkLabelOdItStep.Text = "https://od.itstep.org";
            this.linkLabelOdItStep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOdItStep_LinkClicked);
            // 
            // linkLabelItStep
            // 
            this.linkLabelItStep.AutoSize = true;
            this.linkLabelItStep.LinkVisited = true;
            this.linkLabelItStep.Location = new System.Drawing.Point(53, 490);
            this.linkLabelItStep.Name = "linkLabelItStep";
            this.linkLabelItStep.Size = new System.Drawing.Size(191, 32);
            this.linkLabelItStep.TabIndex = 1;
            this.linkLabelItStep.TabStop = true;
            this.linkLabelItStep.Text = "https://itstep.org";
            this.linkLabelItStep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelItStep_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkVisited = true;
            this.linkLabel1.Location = new System.Drawing.Point(53, 446);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(276, 32);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://mystat.itstep.org/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonBrowserStop);
            this.groupBox4.Controls.Add(this.buttonBrowserStart);
            this.groupBox4.Location = new System.Drawing.Point(97, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 183);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Браузер";
            // 
            // buttonBrowserStop
            // 
            this.buttonBrowserStop.Location = new System.Drawing.Point(21, 84);
            this.buttonBrowserStop.Name = "buttonBrowserStop";
            this.buttonBrowserStop.Size = new System.Drawing.Size(126, 40);
            this.buttonBrowserStop.TabIndex = 1;
            this.buttonBrowserStop.Text = "Стоп";
            this.buttonBrowserStop.UseVisualStyleBackColor = true;
            this.buttonBrowserStop.Click += new System.EventHandler(this.buttonBrowserStop_Click);
            // 
            // buttonBrowserStart
            // 
            this.buttonBrowserStart.Location = new System.Drawing.Point(21, 38);
            this.buttonBrowserStart.Name = "buttonBrowserStart";
            this.buttonBrowserStart.Size = new System.Drawing.Size(126, 40);
            this.buttonBrowserStart.TabIndex = 1;
            this.buttonBrowserStart.Text = "Пуск";
            this.buttonBrowserStart.UseVisualStyleBackColor = true;
            this.buttonBrowserStart.Click += new System.EventHandler(this.buttonBrowserStart_Click);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelTimer);
            this.groupBox3.Controls.Add(this.buttonRefresh);
            this.groupBox3.Controls.Add(this.treeViewProcesses);
            this.groupBox3.Location = new System.Drawing.Point(458, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(860, 628);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Системные процессы";
            // 
            // labelTimer
            // 
            this.labelTimer.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimer.Location = new System.Drawing.Point(19, 156);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(156, 64);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "00:00:00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(59, 64);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 46);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // treeViewProcesses
            // 
            this.treeViewProcesses.Location = new System.Drawing.Point(247, 38);
            this.treeViewProcesses.Name = "treeViewProcesses";
            this.treeViewProcesses.Size = new System.Drawing.Size(588, 560);
            this.treeViewProcesses.TabIndex = 0;
            this.treeViewProcesses.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProcesses_NodeMouseClick);
            // 
            // timerRefresher
            // 
            this.timerRefresher.Tick += new System.EventHandler(this.timerRefresher_Tick);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 638);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProcessForm";
            this.Text = "ProcessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeViewProcesses;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Timer timerRefresher;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonBrowserStop;
        private System.Windows.Forms.Button buttonBrowserStart;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabelOdItStep;
        private System.Windows.Forms.LinkLabel linkLabelItStep;
    }
}