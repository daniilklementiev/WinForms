namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.ButtonDemo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text = new System.Windows.Forms.Label();
            this.Notifications = new System.Windows.Forms.CheckBox();
            this.GetNotifications = new System.Windows.Forms.Label();
            this.ListBoxDemo = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Input = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Print", 25.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(38, -9);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1433, 122);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Знамоство с элементами управления";
            // 
            // ButtonDemo
            // 
            this.ButtonDemo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonDemo.Location = new System.Drawing.Point(256, 187);
            this.ButtonDemo.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonDemo.Name = "ButtonDemo";
            this.ButtonDemo.Size = new System.Drawing.Size(139, 49);
            this.ButtonDemo.TabIndex = 1;
            this.ButtonDemo.Text = "Нажать";
            this.ButtonDemo.UseVisualStyleBackColor = true;
            this.ButtonDemo.Click += new System.EventHandler(this.ButtonDemo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кнопка(Button):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Метка (label)";
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.text.Location = new System.Drawing.Point(212, 258);
            this.text.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(237, 37);
            this.text.TabIndex = 4;
            this.text.Text = "Текст(textbox)";
            // 
            // Notifications
            // 
            this.Notifications.AutoSize = true;
            this.Notifications.Location = new System.Drawing.Point(132, 315);
            this.Notifications.Margin = new System.Windows.Forms.Padding(6);
            this.Notifications.Name = "Notifications";
            this.Notifications.Size = new System.Drawing.Size(138, 36);
            this.Notifications.TabIndex = 5;
            this.Notifications.Text = "Чекбокс";
            this.Notifications.UseVisualStyleBackColor = true;
            this.Notifications.CheckedChanged += new System.EventHandler(this.Notifications_CheckedChanged);
            // 
            // GetNotifications
            // 
            this.GetNotifications.AutoSize = true;
            this.GetNotifications.Location = new System.Drawing.Point(22, 316);
            this.GetNotifications.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GetNotifications.Name = "GetNotifications";
            this.GetNotifications.Size = new System.Drawing.Size(83, 32);
            this.GetNotifications.TabIndex = 6;
            this.GetNotifications.Text = "Метка";
            // 
            // ListBoxDemo
            // 
            this.ListBoxDemo.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListBoxDemo.FormattingEnabled = true;
            this.ListBoxDemo.ItemHeight = 42;
            this.ListBoxDemo.Location = new System.Drawing.Point(774, 94);
            this.ListBoxDemo.Margin = new System.Windows.Forms.Padding(6);
            this.ListBoxDemo.Name = "ListBoxDemo";
            this.ListBoxDemo.Size = new System.Drawing.Size(686, 802);
            this.ListBoxDemo.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 367);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 39);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Input
            // 
            this.Input.AutoSize = true;
            this.Input.Location = new System.Drawing.Point(22, 367);
            this.Input.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(70, 32);
            this.Input.TabIndex = 9;
            this.Input.Text = "Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 960);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ListBoxDemo);
            this.Controls.Add(this.GetNotifications);
            this.Controls.Add(this.Notifications);
            this.Controls.Add(this.text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonDemo);
            this.Controls.Add(this.labelTitle);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button ButtonDemo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.CheckBox Notifications;
        private System.Windows.Forms.Label GetNotifications;
        private System.Windows.Forms.ListBox ListBoxDemo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Input;
    }
}
