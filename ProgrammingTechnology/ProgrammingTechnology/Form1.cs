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

            FormView.RunTest();
        }

        private void All_TEST_Click(object sender, EventArgs e)
        {
            // Конвертер:
            string path = "1.txt";
            char[] separators = new char[] { ',', ';' };
            int[] test = new int [30000000];
            try
            {
                test = Converter.Convert(path, separators);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            path = "2.txt";
            separators = new char[] { ',', ';' };
            int[] test_2 = new int[30000000];
            try
            {
                test_2 = Converter.Convert(path, separators);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Декоратор:
            List<int> methods_id = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<MethodInfo> result_method_info = new List<MethodInfo>();
            result_method_info = Decorator.RunMethods(methods_id, test);
            List<List<MethodInfo>> list_results = new List<List<MethodInfo>>();
            list_results.Add(Decorator.RunMethods(methods_id, test));

            methods_id.Clear();
            methods_id = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
          
            list_results.Add(Decorator.RunMethods(methods_id, test_2));

            // Вьюшка:
            FormView f = new FormView(list_results);
            f.Show();
        }
    }
}
