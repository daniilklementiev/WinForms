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

        Brush clearBrush, ballBrush;
        Pen clearPen, ballPen;
        Ball ball;
        static int formHeight;
        static int formWidth;
        public GDIForm()
        {
            InitializeComponent();
            clearBrush = new SolidBrush(this.BackColor);
            clearPen = new Pen(this.BackColor, 3);
            ballPen = new Pen(Color.Tomato, 3);
            ballBrush = new SolidBrush(Color.Tomato);
            ball = new Ball
            {
                X = this.Width / 2,
                Y = this.Height / 2,
                W = 20,
                H = 20,
                Vx = -2,
                Vy = -2
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
        private void GDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TimeKillEvent(timerId);
            timer1.Stop();
        }
        private void GDIForm_Paint(object sender, PaintEventArgs e)
        {
            formHeight = this.ClientSize.Height;
            formWidth = this.ClientSize.Width;
            e.Graphics.DrawEllipse(clearPen, ball.X, ball.Y, ball.W, ball.H);
            // e.Graphics.FillEllipse(clearBrush, ball.X, ball.Y, ball.W, ball.H);
            ball.Track();
            e.Graphics.DrawEllipse(ballPen, ball.X, ball.Y, ball.W, ball.H);
            // e.Graphics.FillEllipse(ballBrush, ball.Y, ball.Y, ball.W, ball.H);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }


        class Ball
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }
            public int Vx { get; set; }
            public int Vy { get; set; }

            public void Track()
            {
                X += Vx;
                Y += Vy;
                if (X < 0)
                {
                    X = 0;
                    Vx = -Vx;
                }
                else if (X + W > GDIForm.formWidth)
                {
                    X = GDIForm.formWidth - W;
                    Vx = -Vx;
                }
                if (Y < 0)
                {
                    Y = 0;
                    Vy = -Vy;
                }
                else if (Y + H > GDIForm.formHeight)
                {
                    Y = GDIForm.formHeight - H;
                    Vy = -Vy;
                }
            }  
        }
    }
}

/* GDI - Graphic Device Interface
 * Набор универсальных методов для отображения графических элементов (рисования)
 * 
 *
 *
 */
