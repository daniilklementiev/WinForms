using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using System.IO;

namespace WinForms.Forms
{
    public partial class MvPatternsForm : Form
    {
        private DemoModel model;
        private DemoModel newModel;

        public MvPatternsForm()
        {
            model = null!;
            newModel = null!;
            InitializeComponent();
        }

        private void MvPatternsForm_Load(object sender, EventArgs e)
        {
            textBoxModel.Text = @"Поставщик данных. 
Файл, база данных или веб ресурс из которого (и в который) передаются данные приложения.";

            textBoxView.Text = @"Интерфейс пользователя.
Набор элементов для отображения и ввода информации
(в т.ч. с использованием периферии)";

            textBoxMvc.Text = @"Контроллер - посредник между пользователем, 
моделью и представлением. Пользователь через представлениевзаимодействует с контроллером,
он, анализируя запрос, выбирает нужную модель и нужное представление, 
передает пользователю новое представление, заполненное данными из модели.";

            textBoxMvp.Text = @"Presenter - соотносится с представлением. 
Обрабатывает события (UI) и при этом ""общается"" с моделями в зависимости от событий.
Пример - WinForms: 
Presenter - Form.cs; View - Form [Design].cs; Model - сохраненные (cериализованные) данные";

            textBoxMvvm.Text = @"ViewModel - модуль, обеспечивающий
двустороннюю связь (binding) модели и представления. Это означает, что
все изменения в модели отслеживаются и обновляют представление. И
наоборот, все изменения данных в представлении сразу попадают в модель.
Такая связь в WinForms с элементами управления: изменения их свойств
сразу отображаются на форме (цвет, размер, текст...). 
Также - гугл документы: все изменения сразу сохраняются";

            this.ActiveControl = null;
        }

        private void tabControlPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPatterns.SelectedIndex == 1) // MVP tab
            {
                // array with random numbers
                int[] rnds = Program.Container.Resolve<RndModel>().GetRandoms(4);
                foreach (var r in rnds)
                {
                    textBoxMvpView.Text += r + "\r\n"; // show numbers in textbox
                }
            }

            if (tabControlPatterns.SelectedIndex == 3) // demo tab
            {
                // Tab activation = new application

                model = new DemoModel("demo.txt");          // model
                model.ModelChangeEvent += OnModelChange;    // Event handler (view -> model)
                model.ModelChangeEvent += OnFileSave;       // save in file
                richTextBoxDemo.TextChanged += (s, e) =>    // model -> view
                {
                    model.Content = richTextBoxDemo.Text;   // Assingment will raise ModelChangeEvent
                };                                          // and its subscribers (OnModelChange)
                richTextBoxDemo.Text = model.Content;       // view init 

                /////////////////////////////////////////////
                newModel = new DemoModel("demo2.txt");
                newModel.ModelChangeEvent += OnModelChange2;     // Event handler (view -> model)
                newModel.ModelChangeEvent += OnFileSave2;        // Save in file
                richTextBoxDemo2.TextChanged += (s, e) =>        // model -> view
                {
                    newModel.Content = richTextBoxDemo2.Text;    // Assingment will raise ModelChangeEvent
                };                                               // and its subscribers (OnModelChange)
                richTextBoxDemo2.Text = newModel.Content;        // view init 

            }
        }

        // Starts when model change event raises
        private void OnModelChange()
        {
            // Update symbols count view
            labelDemoSymbolsCnt.Text = model.Content.Length.ToString(); // binding Cnt.Text to Content.Lenght
        }

        private void OnFileSave()
        {
            File.WriteAllTextAsync(model.fileName, model.Content);
        }

        private void OnModelChange2()
        {
            // Update symbols count view
            labelDemoSymbolsCnt2.Text = newModel.Content.Length.ToString(); // binding Cnt.Text to Content.Lenght
        }

        private void OnFileSave2()
        {
            File.WriteAllTextAsync(newModel.fileName, newModel.Content);
        }
    }

    /* Пример модель - поставщик данных: случайных чисел
     * */
    class RndModel
    {
        private Random _rnd; // random variable
        public RndModel(Random random) // dependency injection
        {
            _rnd = random;
        }
        public int[] GetRandoms(int count)
        {
            int[] randoms = new int[count];
            for (int i = 0; i < count; i++)
            {
                randoms[i] = _rnd.Next(100);
            }
            return randoms;
        }
    }

    delegate void ModelChangeEvent();
    // model for tab Demo (MVVM)
    class DemoModel
    {
        private String content; // buffer for file content
        public String fileName;
        // filename - data storage (file)
        public DemoModel(String filename)
        {
            fileName = filename;
            if (File.Exists(filename))
            {

                content = File.ReadAllText(filename);
            }
            else content = String.Empty;
        }

        // Accesors
        public String Content { 
            get
            { 
                return content;
            } 
            set
            {
                content = value;                            // update buffer
                  // update file
                ModelChangeEvent.Invoke();                  // Raise event
            } 
        }

        // Event source
        public event ModelChangeEvent ModelChangeEvent;
    }

}
