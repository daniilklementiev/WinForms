using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace WinForms.Forms
{
    public partial class MvPatternsForm : Form
    {
        // inversion
        public MvPatternsForm()
        {
            InitializeComponent();
        }

        private void MvPatternsForm_Load(object sender, EventArgs e)
        {
            textBoxModel.Text = @"Поставщик данных. 
Файл, база данных или веб ресурс из которого (и в который) передаются данные приложения.";

            textBoxView.Text = @"Интерфейс пользователя.
Набор элементов для отображения и ввода информации
(в т.ч. с использованием периферии)";

            textBoxMvc.Text = @"Контроллер - посредник между 
пользователем, моделью и представлением. Пользователь через представление
взаимодействует с контроллером, он, анализируя запрос, выбирает 
нужную модель и нужное представление, передает пользователю новое представление, заполненное данными из модели.";

            textBoxMvp.Text = @"Presenter - соотносится с представлением. 
Обрабатывает события (UI) и при этом ""общается"" с моделями в зависимости от событий.
Пример - WinForms: 
Presenter - Form.cs; View - Form [Design].cs; Model - сохраненные (cериализованные) данные";

            this.ActiveControl = null;
        }

        private void tabControlPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControlPatterns.SelectedIndex == 1) // MVP tab
            {
                // array with random numbers
                int[] rnds = Program.Container.Resolve<RndModel>().GetRandoms(4);
                foreach (var r in rnds)
                {
                    textBoxMvpView.Text += r + "\r\n"; // show numbers in textbox
                }
            }
        }
    }

    /* Пример модель - поставщик данных: случайных чисел
     * */
    class RndModel
    {
        private Random _rnd; // random variable
        public RndModel(Random random) // inversion
        {
            _rnd = random;
        }
        public int[] GetRandoms(int count)
        {
            int[] randoms = new int[count];
            for(int i = 0; i < count; i++)
            {
                randoms[i] = _rnd.Next(100);
            }
            return randoms;
        }
    }
}
