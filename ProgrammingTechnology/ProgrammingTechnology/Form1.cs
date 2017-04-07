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

        private void Converter_TEST_Click(object sender, EventArgs e)
        {
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
        }
    }
}
