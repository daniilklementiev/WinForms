using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class Game2048 : Form
    {
        private readonly Random _random;
        private int timeMs;             // Game time in milliseconds
        private int animTick;           // ticks count for animation timer
        private Label appearLabel;      // ref to Label(cell);
        private List<Label> appearLabelsList { get; set; } // labels list to animate
        public Game2048(Random random)
        {
            InitializeComponent();
            appearLabel = null!;
            _random = random;
            appearLabelsList = new List<Label>(); // creating label list
        }

        private void Game2048_Load(object sender, EventArgs e)
        {
            panelGameField.BackColor = Color.FromArgb(0xBB, 0xAD, 0xA0);
            ClearGameField();
            this.ActiveControl = null;
            timeMs = 0;
            timerClock.Start();  // Start timer for Clock

            
        }


        /// <summary>
        /// Clear all field cells
        /// </summary>
        private void ClearGameField()
        {
            foreach (var control in panelGameField.Controls)
            {
                if (control is Label lbl) lbl.Text = "0";
            }
            AddCell();
            AddCell();
            ColorCells();
        }
        
        private void GameOverCheck()
        {
            List<Label> emptyIndexes = new List<Label>();
            Label? lbl;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    String name = "cell" + i + j;
                    lbl = panelGameField.Controls.Find("cell" + i + j, false)[0] as Label;
                    if (lbl.Text == "0")
                    {
                        emptyIndexes.Add(lbl);
                    }
                }
            if (emptyIndexes.Count == 0)
            {
                // Game over
                DialogResult res = MessageBox.Show("Game over. Play again?", "Game over", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes) ClearGameField();
                else Close();
                return;
            }
        }

        /// <summary>
        /// Produce new cell
        /// </summary>
        private void AddCell()
        {
    
            // Looking for empty cells
            List<Label> emptyIndexes = new List<Label>();
            Label? lbl;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    String name = "cell" + i + j;
                    lbl =panelGameField.Controls.Find("cell" + i + j, false)[0] as Label;
                    if(lbl.Text == "0")
                    {
                        emptyIndexes.Add(lbl);
                    }
                }
            // random cell from empty
            lbl = emptyIndexes[_random.Next(emptyIndexes.Count)];
            // 90% - 2, 10% - 4
            lbl.Text = _random.Next(10) == 0
                ? "4"
                : "2";

            // Appearance animation
            appearLabel = lbl;
            
        }

        /// <summary>
        /// Change colors by values
        /// </summary>
        private void ColorCells()
        {
            foreach(var control in panelGameField.Controls)
            {
                var lbl = control as Label;
                if(lbl != null)
                {
                    switch (lbl.Text)
                    {
                        case "0":
                            lbl.BackColor = Color.FromArgb(0xCD, 0xC1, 0xB5);
                            lbl.ForeColor = Color.FromArgb(0xCD, 0xC1, 0xB5);
                            break;
                        case "2":
                            lbl.BackColor = Color.FromArgb(0xEE, 0xE4, 0xDA);
                            lbl.ForeColor = Color.FromArgb(0x77, 0x6E, 0x65);
                            break;
                        case "4":
                            lbl.BackColor = Color.FromArgb(0xED, 0xE0, 0xC8);
                            lbl.ForeColor = Color.FromArgb(0x77, 0x6E, 0x65);
                            break;
                        case "8":
                            lbl.BackColor = Color.FromArgb(0xF2, 0xB1, 0x79);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "16":
                            lbl.BackColor = Color.FromArgb(0xF5, 0x95, 0x63);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "32":
                            lbl.BackColor = Color.FromArgb(0xF6, 0x7C, 0x5F);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "64": //  color: #f9f6f2;background: #f65e3b
                            lbl.BackColor = Color.FromArgb(0xF6, 0x5E, 0x3B);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "128":
                            lbl.BackColor = Color.FromArgb(0xED, 0xCF, 0x72);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "256":
                            lbl.BackColor = Color.FromArgb(0xED, 0xCC, 0x61);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "512":
                            lbl.BackColor = Color.FromArgb(0xED, 0xC8, 0x50);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "1024":
                            lbl.BackColor = Color.FromArgb(0xED, 0xC5, 0x3F);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        case "2048":
                            lbl.BackColor = Color.FromArgb(0xED, 0xC2, 0x2E);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                        default:
                            lbl.BackColor = Color.FromArgb(0x3C, 0x3A, 0x32);
                            lbl.ForeColor = Color.FromArgb(0xF9, 0xF6, 0xF2);
                            break;
                    }
                    lbl.Tag = new AnimData { BackColor = lbl.BackColor };
                }
            }
        }

        private void Game2048_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(e.KeyCode.ToString());
            switch(e.KeyCode)
            {
                case Keys.Left:  MakeMove(Directions.Left);  GameOverCheck(); break;
                case Keys.Right: MakeMove(Directions.Right); GameOverCheck(); break;  
                case Keys.Up:    MakeMove(Directions.Up);    GameOverCheck(); break; 
                case Keys.Down:  MakeMove(Directions.Down);  GameOverCheck(); break; 
                case Keys.A:     MakeMove(Directions.Left);  GameOverCheck(); break; 
                case Keys.D:     MakeMove(Directions.Right); GameOverCheck(); break; 
                case Keys.W:     MakeMove(Directions.Up);    GameOverCheck(); break; 
                case Keys.S:     MakeMove(Directions.Down);  GameOverCheck(); break; 

                case Keys.Escape: Close();break;
                    
            }
        }

        private bool MoveLeft()
        {
            bool wasMove = false;
            // Shift all non-empty cells to left
            for (int i = 0; i < 4; i++) // lines
            {
                for (int k = 0; k < 3; k++)
                for (int j = 0; j < 3; j++) // collumns
                {
                    Label lbl1 = (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
                    Label lbl2 = (Label)panelGameField.Controls.Find("cell" + i + (j+1), false)[0];
                    if(lbl1.Text == "0" && lbl2.Text != "0")
                    {
                        lbl1.Text = lbl2.Text;
                        lbl2.Text = "0";
                        wasMove = true;
                    } 
                    
                }
                // Collapse
                for (int j = 0; j < 3; j++)
                {
                    Label lbl1 = (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
                    Label lbl2 = (Label)panelGameField.Controls.Find("cell" + i + (j + 1), false)[0];
                    if (lbl1.Text == lbl2.Text)
                    {
                        lbl1.Text = (int.Parse(lbl1.Text) * 2).ToString();
                        lbl2.Text = "0";
                        appearLabelsList.Add(lbl1);
                        j++;
                        wasMove = true;
                    }
                }

                // Shift
                for (int j = 1; j < 3; j++)
                {
                    Label lbl1 = (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
                    Label lbl2 = (Label)panelGameField.Controls.Find("cell" + i + (j + 1), false)[0];
                    if (lbl1.Text == "0" && lbl2.Text != "0")
                    {
                        lbl1.Text = lbl2.Text;
                        lbl2.Text = "0";
                        wasMove = true;
                    }
                }

            }
            return wasMove;
        }
        private bool MoveRight()
        {
            bool wasMove = false;
            // Shift all non-empty cells to right
            for (int i = 0; i < 4; i++) // lines
            {
                for (int k = 0; k < 3; k++)
                    for (int j = 3; j > 0; j--) 
                    {
                        Label lbl1 = LabelAt(i, j);
                        Label lbl2 = LabelAt(i, j - 1);
                        if (lbl1.Text == "0" && lbl2.Text != "0")
                        {
                            lbl1.Text = lbl2.Text;
                            lbl2.Text = "0";
                            wasMove = true;
                        }
                    }
                // Collapse
                for (int j = 3; j > 0; j--)
                {
                    Label lbl1 = LabelAt(i, j);
                    Label lbl2 = LabelAt(i, j - 1);
                    if (lbl1.Text == lbl2.Text)
                    {
                        lbl1.Text = (int.Parse(lbl1.Text) * 2).ToString();
                        lbl2.Text = "0";
                        appearLabelsList.Add(lbl1);
                        j--;
                        wasMove = true;
                        lbl1.Tag = new AnimData { BackColor = lbl1.BackColor };
                    }
                }
                // Shift
                for (int j = 2; j > 0; j--)
                {
                    Label lbl1 = LabelAt(i, j);
                    Label lbl2 = LabelAt(i, j - 1);
                    if (lbl1.Text == "0" && lbl2.Text != "0")
                    {
                        lbl1.Text = lbl2.Text;
                        lbl2.Text = "0";
                        wasMove = true;
                    }
                }
            }
            return wasMove;
        }
        private bool MoveUp()
        {
            bool wasMove = false;
            // Shift all non-empty cells to up
            for (int j = 0; j < 4; j++) // columns
            {
                for (int k = 0; k < 3; k++)
                    for (int i = 0; i < 3; ++i)
                    {
                        Label lbl1 = LabelAt(i, j);
                        Label lbl2 = LabelAt(i + 1, j);
                        if (lbl1.Text == "0" && lbl2.Text != "0")
                        {
                            lbl1.Text = lbl2.Text;
                            lbl2.Text = "0";
                            wasMove = true;
                        }
                    }
                // Collapse
                for (int i = 0; i < 3; ++i)
                {
                    Label lbl1 = LabelAt(i, j);
                    Label lbl2 = LabelAt(i + 1, j);
                    if (lbl1.Text == lbl2.Text && lbl2.Text != "0")
                        {
                        lbl1.Text = (int.Parse(lbl1.Text) * 2).ToString();
                        lbl2.Text = "0";
                        appearLabelsList.Add(lbl1);
                        i++;
                        wasMove = true;
                        lbl1.Tag = new AnimData { BackColor = lbl1.BackColor };
                    }
                }
                // Shift
                for (int i = 3; i < 1; --i)
                {
                    Label lbl1 = LabelAt(i, j);
                    Label lbl2 = LabelAt(i - 1, j);
                    if (lbl1.Text == "0" && lbl2.Text != "0")
                    {
                        lbl1.Text = lbl2.Text;
                        lbl2.Text = "0";
                        wasMove = true;
                    }
                }

            }
            return wasMove;
        }
        private bool MoveDown()
        {
            bool wasMove = false;
            // Shift all non-empty cells to up
            for (int j = 0; j < 4; j++) // columns
            {
                for (int k = 0; k < 3; k++)
                    for (int i = 3; i > 0; --i)
                    {
                        Label lbl1 = LabelAt(i, j);
                        Label lbl2 = LabelAt(i - 1, j);
                        if (lbl1.Text == "0" && lbl2.Text != "0")
                        {
                            lbl1.Text = lbl2.Text;
                            lbl2.Text = "0";
                            wasMove = true;
                        }
                    }
                // Collapse
                for (int i = 3; i > 0; --i)
                {
                    Label lbl1 = LabelAt(i, j);
                    Label lbl2 = LabelAt(i - 1, j);
                    if (lbl1.Text == lbl2.Text && lbl2.Text != "0")
                    {
                        lbl1.Text = (int.Parse(lbl1.Text) * 2).ToString();
                        lbl2.Text = "0";
                        appearLabelsList.Add(lbl1);
                        i--;
                        wasMove = true;
                    }
                }
                // Shift
                for (int i = 1; i < 3; i++)
                {
                    Label lbl1 = (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
                    Label lbl2 = (Label)panelGameField.Controls.Find("cell" + (i - 1) + j, false)[0];
                    if (lbl1.Text == "0" && lbl2.Text != "0")
                    {
                        lbl1.Text = lbl2.Text;
                        lbl2.Text = "0";
                        wasMove = true;
                    }
                }
            }
            return wasMove;
        }

        private void MakeMove(Directions direction)
        {
            switch(direction)
            {
                case Directions.Left:
                    if (MoveLeft()) 
                    { 
                        AddCell(); 
                        ColorCells();
                        animTick = 0;
                        timerAnim.Start();  // Start timer for animations
                        return;
                    } 
                    else  break;
                case Directions.Right:
                    if (MoveRight())
                    {
                        AddCell(); 
                        ColorCells();
                        animTick = 0;
                        timerAnim.Start();  // Start timer for animations
                        return;
                    }
                    else break;
                case Directions.Up:
                    if (MoveUp())
                    {
                        AddCell();
                        ColorCells();
                        animTick = 0;
                        timerAnim.Start();  // Start timer for animations
                        return;
                    }
                    else break;
                case Directions.Down:
                    if (MoveDown())
                    {
                        AddCell();
                        ColorCells();
                        animTick = 0;
                        timerAnim.Start();  // Start timer for animations
                        return;
                    }
                    else break;
            }
            // MessageBox.Show("No move");
        }

        private Label LabelAt(int i, int j)
        {
            return (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            timeMs += timerClock.Interval; // add interval to total time
            int timeSec = timeMs / 1000;
            int h = timeSec / 3600;
            int m = (timeSec / 3600) / 60;
            int s = timeSec % 60;

            String hours = h < 10 ? "0" + (Convert.ToString(h)) : Convert.ToString(h);
            String min = m < 10 ? "0" + (Convert.ToString(m)) : Convert.ToString(m);
            String sec = s < 10 ? "0" + (Convert.ToString(s)) : Convert.ToString(s);
            labelTime.Text = $"{hours}:{min}:{sec}";
        }

        private void timerAnim_Tick(object sender, EventArgs e)
        {
            var animData = appearLabel?.Tag as AnimData;
            if(animData == null || appearLabel == null || appearLabelsList.Count == 0)
            {
                timerAnim.Stop();
                return;
            }
            // cycle for animate new labels and collapsed labels
            foreach (var l in appearLabelsList)
            {
                if (Convert.ToInt32(l.Text) % 2 == 0 && l.Text != "0")
                {
                    l.BackColor = Color.FromArgb(animTick * 10, l.BackColor);
                    l.Font = new Font(l.Font.FontFamily, animTick / 2 + 5);
                }
            }
            animTick++;
            // appearLabel.BackColor = Color.FromArgb(animTick * 10, animData.BackColor);
            // labelTime.Font = new Font(labelTime.Font.FontFamily, animTick / 2 + 1);
            if (animTick >= 25)
            {
                appearLabel.BackColor = animData.BackColor;
                timerAnim.Stop();
                appearLabel = null!;
            }
        }

        #region Sensor
        private Point DownPoint, UpPoint;
        private Boolean isMD; // is mouse down?
        private void panelSensor_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint.X = e.X;
            DownPoint.Y = e.Y;
            isMD = true;
        }

        private void panelSensor_MouseUp(object sender, MouseEventArgs e)
        {
            if(isMD)
            {
                UpPoint.X = e.X;
                UpPoint.Y = e.Y;
                SensorMove();
                isMD = false;
            }
            
        }

       

        private void SensorMove()
        {
            if( Math.Abs(UpPoint.X - DownPoint.X) <
                Math.Abs(UpPoint.Y - DownPoint.Y) ) // |dX| < |dY| -  Vertical
            {
                if(UpPoint.Y < DownPoint.Y) // Up
                {
                    MakeMove(Directions.Up);
                }
                else // Down
                {
                    MakeMove(Directions.Down);
                }
            }
            else // Horizontal
            {
                if (UpPoint.X < DownPoint.X) // Left
                {
                    MakeMove(Directions.Left);
                }
                else // Right
                {
                    MakeMove(Directions.Right);
                }
            }
        }

        #endregion


    }

    class AnimData  // Data for Control's animation
    {
        public Color BackColor { get; set; }
    }

    enum Directions
    {
        Left,
        Right,
        Up, 
        Down
    }
}
