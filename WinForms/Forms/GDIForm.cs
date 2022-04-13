using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class GDIForm : Form
    {
        #region Multimedia Timer
        // https://docs.microsoft.com/en-us/previous-versions/ff728861(v=vs.85)
        delegate void TimerCallback(UInt32 uTimerID, UInt32 uMsg, ref UInt32 dwUser, UInt32 dw1, UInt32 dw2);

        // https://docs.microsoft.com/en-us/previous-versions/dd757634(v=vs.85)
        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        static extern UInt32 TimeSetEvent(UInt32 uDelay, UInt32 uResolution, TimerCallback lpTimeProc, ref UInt32 dwUser, UInt32 eventType);
        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeKillEvent")]
        static extern void TimeKillEvent(UInt32 uTimerId);
        const int TIME_ONESHOT = 0;
        const int TIME_PERIODIC = 1;
        private uint uDelay, uResolution;
        private UInt32 timerId;
        UInt32 dwUser = 0;
        void Timer_Tick(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2)
        {
                Invoke((Action)IncLabel);
                timerId = TimeSetEvent(uDelay, uResolution, Timer_Tick, ref dwUser, TIME_ONESHOT);
        }


        void IncLabel()
        {
            if(!this.IsDisposed) this.Text = (int.Parse(this.Text) + 1).ToString();
        }

        #endregion

        Ball ball;
        static int formHeight;
        static int formWidth;
        public GDIForm()
        {
            InitializeComponent();
            ball = new Ball
            {
                X = this.Width / 2,
                Y = this.Height / 2,
                W = 20,
                H = 20,
                Vx = -2,
                Vy = -2,
                clearBrush = new SolidBrush(this.BackColor),
                clearPen = new Pen(this.BackColor, 3),
                ballPen = new Pen(Color.Tomato, 3),
                ballBrush = new SolidBrush(Color.Tomato)
            };  
        }
        private void GDIForm_Load(object sender, EventArgs e)
        {
            
            /*this.Text = "1";
            uDelay = 10;
            uResolution = 10;
            timerId = TimeSetEvent(uDelay, uResolution, Timer_Tick, ref dwUser, TIME_ONESHOT);*/
            timer1.Start();
        }

        /// <summary>
        /// Method for closing form
        /// </summary>
        private void GDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TimeKillEvent(timerId);
            timer1.Stop();
        }

        /// <summary>
        /// Method for paint form
        /// </summary>
        private void GDIForm_Paint(object sender, PaintEventArgs e)
        {
            formHeight = this.ClientSize.Height;
            formWidth = this.ClientSize.Width;
            e.Graphics.DrawEllipse(ball.clearPen, ball.X, ball.Y, ball.W, ball.H);
            // e.Graphics.FillEllipse(clearBrush, ball.X, ball.Y, ball.W, ball.H);
            ball.Track();
            e.Graphics.DrawEllipse(ball.ballPen, ball.X, ball.Y, ball.W, ball.H);
            // e.Graphics.FillEllipse(ballBrush, ball.Y, ball.Y, ball.W, ball.H);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        // сlass for flying ball
        class Ball
        {
            public int X { get; set; }              // x position of ball
            public int Y { get; set; }              // y position of ball
            public int W { get; set; }              // width of ball
            public int H { get; set; }              // height of ball
            public int Vx { get; set; }             // speed by x
            public int Vy { get; set; }             // speed by y
            public Brush clearBrush { get; set; }   // brush to clear track
            public Brush ballBrush { get; set; }    // brush for paint ball
            public Pen clearPen { get; set; }       // pen to clear track
            public Pen ballPen { get; set; }        // pen for paint ball
            public Ball() // ctor
            {
                X = 2;
                Y = 2;
                W = 2;
                H = 2;
                clearBrush = new SolidBrush(Form.DefaultBackColor);
                ballBrush = new SolidBrush(Color.Black);
                clearPen = new Pen(Form.DefaultBackColor);
                ballPen = new Pen(Color.Black);
            }
            public void Track() // track func (move)
            {
                X += Vx;
                Y += Vy;
                if (X < 0) // right frame
                {
                    X = 0;
                    Vx = -Vx;
                }
                else if (X + W > GDIForm.formWidth) // left frame
                {
                    X = GDIForm.formWidth - W;
                    Vx = -Vx;
                }
                if (Y < 0) // up frame
                {
                    Y = 0;
                    Vy = -Vy;
                }
                else if (Y + H > GDIForm.formHeight) // bottom frame
                {
                    Y = GDIForm.formHeight - H;
                    Vy = -Vy;
                }
            }  
        }
    }
}

