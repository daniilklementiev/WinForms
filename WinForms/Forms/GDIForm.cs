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
        const int TIME_ONESHOT = 0;                     // timer start once
        const int TIME_PERIODIC = 1;                    // timer start periodic
        private uint uDelay, uResolution;               // delay, the error
        private UInt32 timerId;                         // id for timer
        private UInt32 dwUser = 0;
        private TimerCallback timerCallback = null!;    // delegate for timer
        private GCHandle timerHandle;                   // gc handle for timer
        private int ticks;                              // counter of ticks

        // processing timer tick
        void Timer_Tick(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)IncLabel);
                }
            }
            catch { }
        }

        // painting timer label
        void IncLabel()
        {
            if (!this.IsDisposed)
            {
                // if balls 0 - lose
                if(ballsCount == 0)
                {
                    StopMmTimer();
                    timer1.Stop();
                    MessageBox.Show("Game over", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ticks++;
                int h = ticks / 3600;
                int m = (ticks / 3600) / 60;
                int s = ticks % 60;
                // spawn balls for every 8 second
                if(s % 8 == 0)
                {
                    ballsCount++;
                    balls.Add(new Ball
                    {
                        X = _random.Next(this.Width),
                        Y = _random.Next(this.Height),
                        W = 20,
                        H = 20,
                        Vx = _random.Next(10) - 5,
                        Vy = _random.Next(10) - 5,
                        clearBrush = new SolidBrush(this.BackColor),
                        clearPen = new Pen(this.BackColor, 3),
                        ballPen = new Pen(Color.FromArgb(_random.Next(156), _random.Next(156), _random.Next(156)), 3),
                        ballBrush = new SolidBrush(Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256)))
                    });
                    labelBalls.Text = ballsCount.ToString();
                }
                String hours = h.ToString("00");
                String min = m.ToString("00");
                String sec = s.ToString("00");
                labelClock.Text = $"{hours}:{min}:{sec}";
                // labelClock.Text = (int.Parse(this.Text) + 1).ToString();
            }
        }

        // start multimedia timer
        void StartMmTimer()
        {
            this.Text = "1";
            uDelay = 1000;                                  // delay for 1 sec 
            uResolution = 10;                               // the error
            timerCallback = new TimerCallback(Timer_Tick);  // delegate for timer
            timerHandle = GCHandle.Alloc(timerCallback);    // garbage collector handle for timer

            timerId = TimeSetEvent(uDelay, uResolution, timerCallback, ref dwUser, TIME_PERIODIC);
        }

        // stop multimedia timer
        void StopMmTimer()
        {
            TimeKillEvent(timerId);
            timerHandle.Free();
        }

        #endregion

        private readonly Random _random;    // variable for random
        private List<Ball> balls = new();   // list of balls
        private static int formHeight;      // form height
        private static int formWidth;       // form width
        private static GDIForm? parent;     // parent window object
        private RocketMoveDirections rocketMove = RocketMoveDirections.None;
        private Rocket rocket;              // object for rocket
        private Brush clearBrush;           // brush for cleaning
        private int missed;                 // missed balls count
        private int score;                  // score by pushed balls
        private int ballsCount;             // how many balls on form
        public GDIForm(Random random)
        {
            this._random = random;
            InitializeComponent();
            ballsCount = 0;
            clearBrush = new SolidBrush(this.BackColor);
            parent = this;
            // cycle for adding 3 balls
            for (int i = 0; i < 3; i++)
            {
                ballsCount++;
                balls.Add(new Ball
                {
                    X = _random.Next(this.Width),
                    Y = _random.Next(this.Height),
                    W = 20,
                    H = 20,
                    Vx = _random.Next(10) - 5,
                    Vy = _random.Next(10) - 5,
                    clearBrush = new SolidBrush(this.BackColor),
                    clearPen = new Pen(this.BackColor, 3),
                    ballPen = new Pen(Color.FromArgb(_random.Next(156), _random.Next(156), _random.Next(156)), 3),
                    ballBrush = new SolidBrush(Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256)))
                });
            }
            // creating rocket
            rocket = new Rocket
            {
                X = this.Width / 2,
                W = 100,
                H = 15,
                Brush = new SolidBrush(Color.Tomato)
            };
            // count of balls
            labelBalls.Text = ballsCount.ToString();
        }
        private void GDIForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            StartMmTimer();
        }

        /// <summary>
        /// Method for closing form
        /// </summary>
        private void GDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            StopMmTimer();
        }

        /// <summary>
        /// Method for paint form
        /// </summary>
        private void GDIForm_Paint(object sender, PaintEventArgs e)
        {
            formHeight = this.ClientSize.Height;
            formWidth = this.ClientSize.Width;
            foreach (var ball in balls)
            {
                e.Graphics.DrawEllipse(ball.clearPen, ball.X, ball.Y, ball.W, ball.H);
                ball.Track();
                e.Graphics.DrawEllipse(ball.ballPen, ball.X, ball.Y, ball.W, ball.H);
            }

            // Rocket
            // if key hold then move
            switch (rocketMove)
            {
                case RocketMoveDirections.Left:
                    e.Graphics.FillRectangle(clearBrush,
                       rocket.X,
                       this.ClientSize.Height - rocket.H,
                       rocket.W,
                       rocket.H);
                    rocket.V = -10;
                    rocket.Track();
                    break;
                case RocketMoveDirections.Right:
                    e.Graphics.FillRectangle(clearBrush,
                       rocket.X,
                       this.ClientSize.Height - rocket.H,
                       rocket.W,
                       rocket.H);
                    rocket.V = 10;
                    rocket.Track();
                    break;
                case RocketMoveDirections.None:
                    break;
            }
            e.Graphics.FillRectangle(rocket.Brush,
                rocket.X,this.ClientSize.Height - rocket.H,
                rocket.W,rocket.H);

            // Rocket ball collision
            Ball toRemove = null!;
            foreach (var ball in balls)
            {
                if(ball.Y >= this.ClientSize.Height)
                {
                    toRemove = ball;
                    
                }
                else if(ball.Y + ball.H >= this.ClientSize.Height - rocket.H
                    && ball.Y + ball.H <= this.ClientSize.Height)
                {
                    if(ball.X + ball.W / 2 >= rocket.X && ball.X + ball.W / 2 <= 
                        rocket.X + rocket.W)
                    {
                        // Back
                        score++;
                        labelScore.Text = score.ToString();
                        ball.Vy = -ball.Vy;
                        ball.Y = this.ClientSize.Height - rocket.H - ball.H;
                    }
                    
                }
            }
            // removing ball
            if (toRemove != null)
            {
                ballsCount--;
                balls.Remove(toRemove);
                missed++;
                labelMissed.Text = missed.ToString();
                labelBalls.Text = ballsCount.ToString();
            }

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
                else if (X + W >= GDIForm.formWidth) // left frame
                {
                    X = GDIForm.formWidth - W;
                    Vx = -Vx;
                }
                if (Y < 0) // up frame
                {
                    Y = 0;
                    Vy = -Vy;
                }
               /* else if (Y + H >= GDIForm.formHeight) // bottom frame
                {
                    Y = GDIForm.formHeight - H;
                    Vy = -Vy;
                }*/
            }
        }

        // class for rocket
        class Rocket
        {
            public int X { get; set; }          // X position
            public int W { get; set; }          // width
            public int H { get; set; }          // height
            public int V { get; set; }          // speed
            public Brush Brush { get; set; }    // brush for painting

            // method for moving
            public void Track()
            {
                X += V;
                if (X < 0) // right frame
                {
                    X = 0;
                    V = -V;
                }
                if (X + W >= GDIForm.formWidth) // left frame
                {
                    X = GDIForm.formWidth - W;
                    V = -V;
                }
            }
        }

        private void GDIForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                rocketMove = RocketMoveDirections.Left;
            }
            if (e.KeyCode == Keys.D)
            {
                rocketMove = RocketMoveDirections.Right;
            }
        }

        private void GDIForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && rocketMove == RocketMoveDirections.Left)
            {
                rocketMove = RocketMoveDirections.None;
            }
            if (e.KeyCode == Keys.D && rocketMove == RocketMoveDirections.Right)
            {
                rocketMove = RocketMoveDirections.None;
            }
        }

        enum RocketMoveDirections
        {
            None,
            Left,
            Right
        }
    }
}

