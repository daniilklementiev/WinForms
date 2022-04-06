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
        public Game2048(Random random)
        {
            InitializeComponent();
            _random = random;
        }

        private void Game2048_Load(object sender, EventArgs e)
        {
            panelGameField.BackColor = Color.FromArgb(0xBB, 0xAD, 0xA0);
            // ColorCells();
            // AddCell();
            // ColorCells();
            ClearGameField();
            AddCell();
            AddCell();
            ColorCells();
            this.ActiveControl = null;
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
            if(emptyIndexes.Count == 0)
            {
                // Game over
                return;
            }
            // random cell from empty
            lbl = emptyIndexes[_random.Next(emptyIndexes.Count)];
            // 90% - 2, 10% - 4
            lbl.Text = _random.Next(10) == 0
                ? "4"
                : "2";
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
                    switch(lbl.Text)
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
                }
            }
        }

        private void Game2048_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(e.KeyCode.ToString());
            switch(e.KeyCode)
            {
                case Keys.Left:  if (MoveLeft())  { AddCell(); ColorCells(); } else MessageBox.Show("No move"); break;
                case Keys.Right: if (MoveRight()) { AddCell(); ColorCells(); } else MessageBox.Show("No move"); break; 
                case Keys.Up:    if (MoveUp())    { AddCell(); ColorCells(); } else MessageBox.Show("No move"); break;
                case Keys.Down:  if (MoveDown())  { AddCell(); ColorCells(); } else MessageBox.Show("No move"); break;
                    
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
                        j--;
                        wasMove = true;
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
                        i++;
                        wasMove = true;
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
                        i--;
                        wasMove = true;
                    }
                }
            }
            return wasMove;
        }

        private Label LabelAt(int i, int j)
        {
            return (Label)panelGameField.Controls.Find("cell" + i + j, false)[0];
        }
    }
}
