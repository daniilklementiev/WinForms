namespace WinForms.Forms
{
    partial class Game2048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game2048));
            this.panelGameField = new System.Windows.Forms.Panel();
            this.cell33 = new System.Windows.Forms.Label();
            this.cell23 = new System.Windows.Forms.Label();
            this.cell13 = new System.Windows.Forms.Label();
            this.cell03 = new System.Windows.Forms.Label();
            this.cell31 = new System.Windows.Forms.Label();
            this.cell21 = new System.Windows.Forms.Label();
            this.cell11 = new System.Windows.Forms.Label();
            this.cell32 = new System.Windows.Forms.Label();
            this.cell22 = new System.Windows.Forms.Label();
            this.cell12 = new System.Windows.Forms.Label();
            this.cell01 = new System.Windows.Forms.Label();
            this.cell30 = new System.Windows.Forms.Label();
            this.cell20 = new System.Windows.Forms.Label();
            this.cell10 = new System.Windows.Forms.Label();
            this.cell02 = new System.Windows.Forms.Label();
            this.cell00 = new System.Windows.Forms.Label();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.panelSensor = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerAnim = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelGameField.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGameField
            // 
            this.panelGameField.Controls.Add(this.cell33);
            this.panelGameField.Controls.Add(this.cell23);
            this.panelGameField.Controls.Add(this.cell13);
            this.panelGameField.Controls.Add(this.cell03);
            this.panelGameField.Controls.Add(this.cell31);
            this.panelGameField.Controls.Add(this.cell21);
            this.panelGameField.Controls.Add(this.cell11);
            this.panelGameField.Controls.Add(this.cell32);
            this.panelGameField.Controls.Add(this.cell22);
            this.panelGameField.Controls.Add(this.cell12);
            this.panelGameField.Controls.Add(this.cell01);
            this.panelGameField.Controls.Add(this.cell30);
            this.panelGameField.Controls.Add(this.cell20);
            this.panelGameField.Controls.Add(this.cell10);
            this.panelGameField.Controls.Add(this.cell02);
            this.panelGameField.Controls.Add(this.cell00);
            this.panelGameField.Location = new System.Drawing.Point(25, 250);
            this.panelGameField.Name = "panelGameField";
            this.panelGameField.Size = new System.Drawing.Size(700, 700);
            this.panelGameField.TabIndex = 0;
            // 
            // cell33
            // 
            this.cell33.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell33.Location = new System.Drawing.Point(540, 530);
            this.cell33.Name = "cell33";
            this.cell33.Size = new System.Drawing.Size(150, 150);
            this.cell33.TabIndex = 3;
            this.cell33.Text = "0";
            this.cell33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell23
            // 
            this.cell23.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell23.Location = new System.Drawing.Point(540, 360);
            this.cell23.Name = "cell23";
            this.cell23.Size = new System.Drawing.Size(150, 150);
            this.cell23.TabIndex = 3;
            this.cell23.Text = "512";
            this.cell23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell13
            // 
            this.cell13.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell13.Location = new System.Drawing.Point(540, 190);
            this.cell13.Name = "cell13";
            this.cell13.Size = new System.Drawing.Size(150, 150);
            this.cell13.TabIndex = 3;
            this.cell13.Text = "32";
            this.cell13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell03
            // 
            this.cell03.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell03.Location = new System.Drawing.Point(540, 20);
            this.cell03.Name = "cell03";
            this.cell03.Size = new System.Drawing.Size(150, 150);
            this.cell03.TabIndex = 3;
            this.cell03.Text = "4";
            this.cell03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell31
            // 
            this.cell31.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell31.Location = new System.Drawing.Point(200, 530);
            this.cell31.Name = "cell31";
            this.cell31.Size = new System.Drawing.Size(150, 150);
            this.cell31.TabIndex = 2;
            this.cell31.Text = "2048";
            this.cell31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell21
            // 
            this.cell21.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell21.Location = new System.Drawing.Point(200, 360);
            this.cell21.Name = "cell21";
            this.cell21.Size = new System.Drawing.Size(150, 150);
            this.cell21.TabIndex = 2;
            this.cell21.Text = "128";
            this.cell21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell11
            // 
            this.cell11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell11.Location = new System.Drawing.Point(200, 190);
            this.cell11.Name = "cell11";
            this.cell11.Size = new System.Drawing.Size(150, 150);
            this.cell11.TabIndex = 2;
            this.cell11.Text = "8";
            this.cell11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell32
            // 
            this.cell32.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell32.Location = new System.Drawing.Point(370, 530);
            this.cell32.Name = "cell32";
            this.cell32.Size = new System.Drawing.Size(150, 150);
            this.cell32.TabIndex = 1;
            this.cell32.Text = "4096";
            this.cell32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell22
            // 
            this.cell22.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell22.Location = new System.Drawing.Point(370, 360);
            this.cell22.Name = "cell22";
            this.cell22.Size = new System.Drawing.Size(150, 150);
            this.cell22.TabIndex = 1;
            this.cell22.Text = "256";
            this.cell22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell12
            // 
            this.cell12.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell12.Location = new System.Drawing.Point(370, 190);
            this.cell12.Name = "cell12";
            this.cell12.Size = new System.Drawing.Size(150, 150);
            this.cell12.TabIndex = 1;
            this.cell12.Text = "16";
            this.cell12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell01
            // 
            this.cell01.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell01.Location = new System.Drawing.Point(200, 20);
            this.cell01.Name = "cell01";
            this.cell01.Size = new System.Drawing.Size(150, 150);
            this.cell01.TabIndex = 2;
            this.cell01.Text = "0";
            this.cell01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell30
            // 
            this.cell30.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell30.Location = new System.Drawing.Point(25, 530);
            this.cell30.Name = "cell30";
            this.cell30.Size = new System.Drawing.Size(150, 150);
            this.cell30.TabIndex = 0;
            this.cell30.Text = "1024";
            this.cell30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell20
            // 
            this.cell20.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell20.Location = new System.Drawing.Point(25, 360);
            this.cell20.Name = "cell20";
            this.cell20.Size = new System.Drawing.Size(150, 150);
            this.cell20.TabIndex = 0;
            this.cell20.Text = "64";
            this.cell20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell10
            // 
            this.cell10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell10.Location = new System.Drawing.Point(25, 190);
            this.cell10.Name = "cell10";
            this.cell10.Size = new System.Drawing.Size(150, 150);
            this.cell10.TabIndex = 0;
            this.cell10.Text = "0";
            this.cell10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell02
            // 
            this.cell02.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell02.Location = new System.Drawing.Point(370, 20);
            this.cell02.Name = "cell02";
            this.cell02.Size = new System.Drawing.Size(150, 150);
            this.cell02.TabIndex = 1;
            this.cell02.Text = "2";
            this.cell02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cell00
            // 
            this.cell00.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cell00.Location = new System.Drawing.Point(25, 20);
            this.cell00.Name = "cell00";
            this.cell00.Size = new System.Drawing.Size(150, 150);
            this.cell00.TabIndex = 0;
            this.cell00.Text = "0";
            this.cell00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.pictureBox1);
            this.panelDisplay.Controls.Add(this.labelTime);
            this.panelDisplay.Location = new System.Drawing.Point(25, 24);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(492, 200);
            this.panelDisplay.TabIndex = 1;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(3, 160);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(125, 40);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "00:00:00";
            // 
            // panelSensor
            // 
            this.panelSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSensor.Location = new System.Drawing.Point(533, 24);
            this.panelSensor.Name = "panelSensor";
            this.panelSensor.Size = new System.Drawing.Size(215, 200);
            this.panelSensor.TabIndex = 6;
            this.panelSensor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSensor_MouseDown);
            this.panelSensor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSensor_MouseUp);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 50;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerAnim
            // 
            this.timerAnim.Tick += new System.EventHandler(this.timerAnim_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinForms.Properties.Resources.picture2048;
            this.pictureBox1.Location = new System.Drawing.Point(-57, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Game2048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 1002);
            this.Controls.Add(this.panelSensor);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.panelGameField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game2048";
            this.Text = "Game2048";
            this.Load += new System.EventHandler(this.Game2048_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game2048_KeyDown);
            this.panelGameField.ResumeLayout(false);
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGameField;
        private System.Windows.Forms.Label cell03;
        private System.Windows.Forms.Label cell01;
        private System.Windows.Forms.Label cell02;
        private System.Windows.Forms.Label cell00;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Label cell33;
        private System.Windows.Forms.Label cell23;
        private System.Windows.Forms.Label cell13;
        private System.Windows.Forms.Label cell31;
        private System.Windows.Forms.Label cell21;
        private System.Windows.Forms.Label cell11;
        private System.Windows.Forms.Label cell32;
        private System.Windows.Forms.Label cell22;
        private System.Windows.Forms.Label cell12;
        private System.Windows.Forms.Label cell30;
        private System.Windows.Forms.Label cell20;
        private System.Windows.Forms.Label cell10;
        private System.Windows.Forms.Panel panelSensor;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerAnim;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}