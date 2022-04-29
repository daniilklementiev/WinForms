using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace WinForms.Forms
{
    public partial class FractalForm : Form
    {
        private Brush сonvergentBrush;      // if graphic convergent
        private Brush diсonvergentBrush;    // if graphic not convergent
        Graphics graphics;                  // graphics variable
        private Thread drawThread;
        private Stopwatch stopwatch;
                                            
        // [Dependency]
        // public Services.IRandom Random { get; set; }
        
        
        public FractalForm()
        {
            InitializeComponent();
            сonvergentBrush = new SolidBrush(Color.White);
            diсonvergentBrush = new SolidBrush(Color.Black);
            graphics = null!;
            drawThread = null!;
        }
        private void FractalForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = buttonStart;           // set focus on buttonStart
            graphics = panelPicture.CreateGraphics();   // create graphics variable for panelPicture
            // textBoxImC.Text = Random.NextDouble().ToString();
            // textBoxReC.Text = Random.NextDouble().ToString();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            сonvergentBrush.Dispose();      // dispose brush
            diсonvergentBrush.Dispose();    // dispose brush
            this.Close();
        }

        /// <summary>
        /// Button that starting fractal drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // if start button clicked while thread not finished
            if (drawThread != null)
            {
                MessageBox.Show("Wait please");
                return;
            }                
            Complex C;

            try
            {
                C = new Complex
                {
                    Re = Convert.ToDouble(textBoxReC.Text.Replace('.', ',')),
                    Im = Convert.ToDouble(textBoxImC.Text.Replace('.', ','))
                };
            }
            catch
            {
                MessageBox.Show("Something wrong with numeric values");
                return;
            }
            drawThread = new Thread(CheckingPixels);
            stopwatch = Stopwatch.StartNew();
            drawThread.Start(C);
        }

        int threadCnt;
        private async void ShowPoint2(int x, int y, Complex C)
        {
            await Task.Run(() =>
            {
                Complex Z = new Complex
                {
                    Re = 3.0 * (x - panelPicture.Width / 2) / panelPicture.Width,   // Определить значения из соображений, что края
                    Im = 3.0 * (y - panelPicture.Height / 2) / panelPicture.Height  // "холста" имеют значения -1.5 1.5
                };
                int n = 0;
                do
                {
                    n++;
                    Z = Z * Z + C;

                } while (n < 100 && Z.Abs < 10);

                Brush colorPixel;
                if (n < 100) // Последовательность разошлась
                {
                    // Выбираем белый цвет
                    colorPixel = diсonvergentBrush;
                }
                else
                {
                    // Выбираем черный цвет
                    colorPixel = сonvergentBrush;
                }
                lock (graphics)
                {
                    // Рисуем пиксель - прямоугольник 1х1
                    // using (Graphics g = panelPicture.CreateGraphics())
                    graphics.FillRectangle(colorPixel, x, y, 1, 1);
                    threadCnt--;
                    if (threadCnt == 0)
                    {
                        stopwatch.Stop();
                        MessageBox.Show("Finished @" + stopwatch.ElapsedMilliseconds);
                        drawThread = null!;
                    }
                }
            });
        }


        /// <summary>
        /// Checking all pixels of panel
        /// </summary>
        /// <param name="obj"></param>
        private void CheckingPixels(object? obj)
        {
            Complex? C = obj as Complex;
            if (C == null) return;
            threadCnt = panelPicture.Width * panelPicture.Height;
            for (int x = 0; x < panelPicture.Width; x += 1)         // width of panel
                for (int y = 0; y < panelPicture.Height; y += 1)    // height of panel
                {
                    // Sync - 11 sec (degree - 2)
                    // ShowPoint(new PointData { X = x, Y = y, C = C });

                    // MultiThread
                    // new Thread(ShowPoint).Start(new PointData { X = x, Y = y, C = C });

                    // MultiTask - 48 sec (degree - 2)
                    ShowPoint2(x, y, C);

                    // ThreadPool - 12 sec (degree - 2)
                    // ThreadPool.QueueUserWorkItem(ShowPoint, new PointData { X = x, Y = y, C = C });
                    
                }
                      
            // stopwatch.Stop();
            // MessageBox.Show("Finished @" + stopwatch.ElapsedMilliseconds);
            // drawThread = null!;
        }

        /// <summary>
        /// Showing point on the picture
        /// </summary>
        /// <param name="obj"></param>
        private void ShowPoint(object? obj)
        {
            PointData? data = obj as PointData;
            if (data == null)
            {
                return;
            }

            Complex Z = new Complex
            {
                Re = 3.0 * (data.X - panelPicture.Width / 2) / panelPicture.Width,   // Определить значения из соображений, что края
                Im = 3.0 * (data.Y - panelPicture.Height / 2) / panelPicture.Height  // "холста" имеют значения -1.5 1.5
            };
            int n = 0;
            do
            {
                n++;
                Z = Z * Z + data.C;

            } while (n < 100 && Z.Abs < 10);

            Brush colorPixel;
            if (n < 100) // Последовательность разошлась
            {
                // Выбираем белый цвет
                colorPixel = diсonvergentBrush;
            }
            else
            {
                // Выбираем черный цвет
                colorPixel = сonvergentBrush;
            }
            lock (graphics)
            {
                // Рисуем пиксель - прямоугольник 1х1
                //using (Graphics g = panelPicture.CreateGraphics())
                graphics.FillRectangle(colorPixel, data.X, data.Y, 1, 1);
                threadCnt--;
                if(threadCnt == 0)
                {
                    stopwatch.Stop();
                    MessageBox.Show("Finished @" + stopwatch.ElapsedMilliseconds);
                    drawThread = null!;
                }
            }

        }


        /// <summary>
        /// Button that starting fractal drawing sync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click_Sync(object sender, EventArgs e)
        {
            Complex C;
            try
            {
                C = new Complex
                {
                    Re = Convert.ToDouble(textBoxReC.Text.Replace('.', ',')),
                    Im = Convert.ToDouble(textBoxImC.Text.Replace('.', ','))
                };
            }
            catch
            {
                MessageBox.Show("Something wrong with numeric values");
                return;
            }
            for (int x = 0; x <= panelPicture.Width; x += 1)      // panel coordinates
                for (int y = 0; y <= panelPicture.Height; y += 1)  // panel coordinates
                {

                    Complex Z = new Complex
                    {
                        Re = 3.0 * (x - panelPicture.Width / 2) / panelPicture.Width,   // Определить значения из соображений, что края
                        Im = 3.0 * (y - panelPicture.Height / 2) / panelPicture.Height  // "холста" имеют значения -1.5 1.5
                    };
                    int n = 0;
                    do
                    {
                        n++;
                        Z = Z * Z + C;

                    } while (n < 100 && Z.Abs < 10);

                    Brush colorPixel;
                    if (n < 100) // Последовательность разошлась
                    {
                        // Выбираем белый цвет
                        colorPixel = diсonvergentBrush;
                    }
                    else
                    {
                        // Выбираем черный цвет
                        colorPixel = сonvergentBrush;
                    }
                    lock (panelPicture)
                    {
                        // Рисуем пиксель - прямоугольник 1х1
                        using (Graphics g = panelPicture.CreateGraphics())
                            g.FillRectangle(colorPixel, x, y, 1, 1);
                    }
                }



        }

    }
    
    class PointData
    {
        public int X;
        public int Y;
        public Complex C;
    }
    
    class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public double Abs { get => Math.Sqrt(Re * Re + Im * Im); }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex
            {
                Re = c1.Re + c2.Re,
                Im = c1.Im + c2.Im
            };
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex
            {
                Re = c1.Re * c2.Re - c1.Im * c2.Im,
                Im = c1.Re * c2.Im + c2.Im * c1.Re
            };
        }

    }
}

/* Фракталы
Самоподобные объекты, в которых каждая деталь отображает весь объект в целом
 Алгебрарический фрактал - множество, каждая точка которого отвечает за сходимость 
итеративной последовательности
Жюлиа - 
Zn = Zn-1 ^ 2 + C
Z0 - стартовая точка

Алгоритм построения (для заданной константы С)
- задаем холст - образ комплексной плоскости (-1.5..1.5 х -1.5..1.5)
- выбираем точку Z(х,у)
- циклически рассчитываем последовательность, оцениваем модуль Z
 - если модуль превысил 10, то ставим белую точку
 - если модуль не превысил 10 в течении 100 итераций, то ставим черную точку
- повторяем алгоритм для всех точек холста



 */
