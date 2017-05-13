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

        private void btnStart_Click(object sender, EventArgs e)
        {
            Utilits.StartAllTest();
            btnStart.Visible = false;
            ProgressBar.Visible = true;
            try
            {
                //Utilits.CheckTestResult( Converter.Test() ); НЕТ ТЕСТА
                ProgressBar.Value+=20;
                Utilits.CheckTestResult(Decorator.Test());
                ProgressBar.Value += 20;
                Utilits.CheckTestResult(FormView.Test());
                ProgressBar.Value += 20;
                //Utilits.CheckTestResult( Methods.Test() ); ТЕСТ КРИВОЙ 
                ProgressBar.Value += 20;
            }
            catch(Exception)
            {
                ProgressBar.Visible = false;
                lblStart.Text = "Что-то пошло не так...";
            }

        }

        //private void All_TEST_Click(object sender, EventArgs e)
        //{
        //    // Конвертер:
        //    string path = "1.txt";
        //    char[] separators = new char[] { ',', ';' };
        //    int[] test = new int [30000000];
        //    try
        //    {
        //        test = Converter.Convert(path, separators);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }


        //    path = "2.txt";
        //    separators = new char[] { ',', ';' };
        //    int[] test_2 = new int[30000000];
        //    try
        //    {
        //        test_2 = Converter.Convert(path, separators);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    // Декоратор:
        //    List<int> methods_id = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        //    List<MethodInfo> result_method_info = new List<MethodInfo>();
        //    result_method_info = Decorator.RunMethods(methods_id, test);
        //    List<List<MethodInfo>> list_results = new List<List<MethodInfo>>();
        //    list_results.Add(Decorator.RunMethods(methods_id, test));

        //    methods_id.Clear();
        //    methods_id = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        //    list_results.Add(Decorator.RunMethods(methods_id, test_2));

        //    // Вьюшка:
        //    FormView f = new FormView(list_results);
        //    f.Show();
        //}

    }
}
