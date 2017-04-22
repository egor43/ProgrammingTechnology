using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingTechnology
{
    //Класс "Controller"
    //Представляет собой "мост" между пользовательским интерфейсом и бизнес-логикой программы
    // 
    //Ответственный: Мышко Е. 

    public partial class Controller : Form
    {
        public Controller()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Тест конвертера текстового файлов в массив int.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Converter_TEST_Click(object sender, EventArgs e)
        {
            //Конвертер тестируем ТУТ !!!!!!!!!!!!!!!!!!!!!
            string path = "D:\\Loads\\1.txt";
            char[] separators = new char[] { ',', ';' };
            int[] test;
            try
            {
                test = Converter.Convert(path, separators);
                MessageBox.Show("Тест успешен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Decorator_TEST_Click(object sender, EventArgs e)
        {
            //Декоратор тестируем ТУТ !!!!!!!!!!!!!!!!!!!!!
        }   

        private void Methods_TEST_Click(object sender, EventArgs e)
        {
            //Методы тестируем ТУТ !!!!!!!!!!!!!!!!!!!!!
        }

        private void View_TEST_Click(object sender, EventArgs e)
        {
            //Вьюшку тестируем ТУТ !!!!!!!!!!!!!!!!!!!!!

            // Создаём демонстрационные данные. Потом удалить. 
            List<List<MethodInfo>> lol = FormView.CreateSomeGraphData(10, 10);


            // Это оставляем, lol можно заменить на нормальное название.
            FormView f = new FormView(lol);
            f.Show();

            // Запуск теста. Потом удалить.
            Dictionary<string, bool> testCases = FormView.Test();
            string testResult = "";

            foreach (var test in testCases)
                testResult += test.Key + "\t" + test.Value.ToString() + "\n";

            MessageBox.Show(testResult);
        }
    }
}
