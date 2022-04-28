namespace WinForms.Forms
{
    partial class Portal
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
            this.Intro = new System.Windows.Forms.LinkLabel();
            this.Calculator = new System.Windows.Forms.LinkLabel();
            this.progressLink = new System.Windows.Forms.LinkLabel();
            this.linkLabel2048 = new System.Windows.Forms.LinkLabel();
            this.linkGdi = new System.Windows.Forms.LinkLabel();
            this.linkProcess = new System.Windows.Forms.LinkLabel();
            this.linkLabelPatterns = new System.Windows.Forms.LinkLabel();
            this.linkLabelHooks = new System.Windows.Forms.LinkLabel();
            this.linkLabelAsync1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2Async = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Intro
            // 
            this.Intro.AutoSize = true;
            this.Intro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intro.Location = new System.Drawing.Point(22, 87);
            this.Intro.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Intro.Name = "Intro";
            this.Intro.Size = new System.Drawing.Size(104, 48);
            this.Intro.TabIndex = 0;
            this.Intro.TabStop = true;
            this.Intro.Text = "Intro";
            this.Intro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Intro_LinkClicked);
            // 
            // Calculator
            // 
            this.Calculator.AutoSize = true;
            this.Calculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Calculator.Location = new System.Drawing.Point(22, 174);
            this.Calculator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Calculator.Name = "Calculator";
            this.Calculator.Size = new System.Drawing.Size(209, 48);
            this.Calculator.TabIndex = 0;
            this.Calculator.TabStop = true;
            this.Calculator.Text = "Calculator";
            this.Calculator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Calculator_LinkClicked);
            // 
            // progressLink
            // 
            this.progressLink.AutoSize = true;
            this.progressLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressLink.Location = new System.Drawing.Point(22, 256);
            this.progressLink.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.progressLink.Name = "progressLink";
            this.progressLink.Size = new System.Drawing.Size(187, 48);
            this.progressLink.TabIndex = 0;
            this.progressLink.TabStop = true;
            this.progressLink.Text = "Progress";
            this.progressLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Progress_LinkClicked);
            // 
            // linkLabel2048
            // 
            this.linkLabel2048.AutoSize = true;
            this.linkLabel2048.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel2048.Location = new System.Drawing.Point(22, 330);
            this.linkLabel2048.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel2048.Name = "linkLabel2048";
            this.linkLabel2048.Size = new System.Drawing.Size(688, 48);
            this.linkLabel2048.TabIndex = 0;
            this.linkLabel2048.TabStop = true;
            this.linkLabel2048.Text = "Cобытия и взаимодействия (2048)";
            this.linkLabel2048.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2048_LinkClicked);
            // 
            // linkGdi
            // 
            this.linkGdi.AutoSize = true;
            this.linkGdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkGdi.Location = new System.Drawing.Point(22, 402);
            this.linkGdi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkGdi.Name = "linkGdi";
            this.linkGdi.Size = new System.Drawing.Size(689, 48);
            this.linkGdi.TabIndex = 0;
            this.linkGdi.TabStop = true;
            this.linkGdi.Text = "Графические возможности (GDI+)";
            this.linkGdi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGdi_LinkClicked);
            // 
            // linkProcess
            // 
            this.linkProcess.AutoSize = true;
            this.linkProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkProcess.Location = new System.Drawing.Point(21, 472);
            this.linkProcess.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkProcess.Name = "linkProcess";
            this.linkProcess.Size = new System.Drawing.Size(215, 48);
            this.linkProcess.TabIndex = 0;
            this.linkProcess.TabStop = true;
            this.linkProcess.Text = "Процессы";
            this.linkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProcess_LinkClicked);
            // 
            // linkLabelPatterns
            // 
            this.linkLabelPatterns.AutoSize = true;
            this.linkLabelPatterns.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelPatterns.Location = new System.Drawing.Point(15, 532);
            this.linkLabelPatterns.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabelPatterns.Name = "linkLabelPatterns";
            this.linkLabelPatterns.Size = new System.Drawing.Size(536, 48);
            this.linkLabelPatterns.TabIndex = 0;
            this.linkLabelPatterns.TabStop = true;
            this.linkLabelPatterns.Text = "Паттерны проектирования";
            this.linkLabelPatterns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPatterns_LinkClicked);
            // 
            // linkLabelHooks
            // 
            this.linkLabelHooks.AutoSize = true;
            this.linkLabelHooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelHooks.Location = new System.Drawing.Point(15, 598);
            this.linkLabelHooks.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabelHooks.Name = "linkLabelHooks";
            this.linkLabelHooks.Size = new System.Drawing.Size(563, 48);
            this.linkLabelHooks.TabIndex = 0;
            this.linkLabelHooks.TabStop = true;
            this.linkLabelHooks.Text = "Унаследованный код (Хуки)";
            this.linkLabelHooks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHooks_LinkClicked);
            // 
            // linkLabelAsync1
            // 
            this.linkLabelAsync1.AutoSize = true;
            this.linkLabelAsync1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelAsync1.Location = new System.Drawing.Point(15, 664);
            this.linkLabelAsync1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabelAsync1.Name = "linkLabelAsync1";
            this.linkLabelAsync1.Size = new System.Drawing.Size(937, 48);
            this.linkLabelAsync1.TabIndex = 0;
            this.linkLabelAsync1.TabStop = true;
            this.linkLabelAsync1.Text = "Асинхронное программирование 1 (Шифратор)";
            this.linkLabelAsync1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAsync1_LinkClicked);
            // 
            // linkLabel2Async
            // 
            this.linkLabel2Async.AutoSize = true;
            this.linkLabel2Async.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel2Async.Location = new System.Drawing.Point(15, 732);
            this.linkLabel2Async.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel2Async.Name = "linkLabel2Async";
            this.linkLabel2Async.Size = new System.Drawing.Size(931, 48);
            this.linkLabel2Async.TabIndex = 0;
            this.linkLabel2Async.TabStop = true;
            this.linkLabel2Async.Text = "Асинхронное программирование 2 (Фракталы)";
            this.linkLabel2Async.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2Async_LinkClicked);
            // 
            // Portal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 960);
            this.Controls.Add(this.linkLabel2Async);
            this.Controls.Add(this.linkLabelAsync1);
            this.Controls.Add(this.linkLabelHooks);
            this.Controls.Add(this.linkLabelPatterns);
            this.Controls.Add(this.linkProcess);
            this.Controls.Add(this.linkGdi);
            this.Controls.Add(this.linkLabel2048);
            this.Controls.Add(this.progressLink);
            this.Controls.Add(this.Calculator);
            this.Controls.Add(this.Intro);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Portal";
            this.Text = "Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel Intro;
        private System.Windows.Forms.LinkLabel Calculator;
        private System.Windows.Forms.LinkLabel progressLink;
        private System.Windows.Forms.LinkLabel linkLabel2048;
        private System.Windows.Forms.LinkLabel linkGdi;
        private System.Windows.Forms.LinkLabel linkProcess;
        private System.Windows.Forms.LinkLabel linkLabelPatterns;
        private System.Windows.Forms.LinkLabel linkLabelHooks;
        private System.Windows.Forms.LinkLabel linkLabelAsync1;
        private System.Windows.Forms.LinkLabel linkLabel2Async;
    }
}