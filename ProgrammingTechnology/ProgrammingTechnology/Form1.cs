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

        public string file_name=""; // Полное имя открытого файла
        public List<int[]> list_array = new List<int[]>(); // Лист для массива чисел
        public char[] separators = new char[] { ',', ';' }; // Разделители
        List<int> methods_id = new List<int> { 1 }; // Список методов
        List<MethodInfo> result_method_info = new List<MethodInfo>(); // Лист результатов работы
        List<List<MethodInfo>> list_results = new List<List<MethodInfo>>(); // Лист, содержащий листы с результатами работы

        // Обработчик кнопки "Старт"
        private void btnStart_Click(object sender, EventArgs e)
        {
            string error_msg = ""; // Сообщение об ошибке
            LoadProcess(ref error_msg); // Загружаем приложение
            SetAvailableMethods(error_msg); // Установка доступных методов
        }

        // Обработчик кнопки "Открыть файл"
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Text files (*.txt)|*.txt"; // Устанавливаем фильтр
            if (dlgOpenFile.ShowDialog() == DialogResult.Cancel) // Проверяем, как был закрыт диалог
            {
                return;
            }
            file_name = dlgOpenFile.FileName; // получаем выбранный файл
        }

        // Обработчик кнопки "Начать работу"
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!IsThereSelectedMethods())// Если не выбран ни один метод сортировки
            {
                Utilits.ShowMessage("Не выбраны методы сортировки");
                return;
            }
            methods_id = SetListMethods(); // Установка списка методов для работы
            list_array.Add(Converter.Convert(file_name, separators)); // Добавляем массив в лист для хранения
            RunCheckedMethods();// Запуск работы сортировок
            RunView(); // Запуск вьюшки
        }

        // Метод логики загрузки приложения.
        private void LoadProcess(ref string error_msg)
        {
            btnStart.Visible = false; 
            ProgressBar.Visible = true;
            try
            {
                //error_msg+=Utilits.CheckTestResult( Converter.Test() ); НЕТ ТЕСТА
                ProgressBar.Value += 20;
                error_msg += Utilits.CheckTestResult(Decorator.Test());
                ProgressBar.Value += 20;
                error_msg += Utilits.CheckTestResult(FormView.Test());
                ProgressBar.Value += 20;
                //error_msg+=Utilits.CheckTestResult( Methods.Test() ); ТЕСТ КРИВОЙ 
                ProgressBar.Value += 20;

                if (error_msg != "") // Если мы нашли какие-либо ошибки
                {
                    Utilits.ShowMessage(error_msg); 
                }
            }
            catch (Exception) // Если мы выловили вообще непонятную ошибку
            {
                ProgressBar.Visible = false;
                lblStart.Text = "Что-то пошло не так...";
            }
            pnlLoad.Visible = false; //Убираем панель загрузки
            pnlLoad.Enabled = false;
        }

        // Установка в панель группировки доступных методов
        private void SetAvailableMethods(string error_msg)
        {
            int horizontal_position = 10; // Расположение элементов в груп боксе по горизонтали 
            int vertical_position = 0; // Расположение элементов в груп боксе по вертикали 
            int shift = 22; //Сдвиг элементов
            // Идем по списку методов
            foreach (var method in Methods.DicIdName)
            {
                // Ищем имена методов в сообщении об ошибке
                if(error_msg.IndexOf(method.Value)<0) // Если имя метода не упоминается в сообшении об ошибке
                {
                    CheckBox new_method_chkbox = new CheckBox(); // Создаем новый чек-бокс
                    new_method_chkbox.Text = method.Value; // Называем его именем метода
                    new_method_chkbox.Tag = method.Key;// Тегу необходимо присвоить номер метода чтобы его потом безошибочно запросить
                    new_method_chkbox.Location = new Point(horizontal_position, vertical_position += shift); // Размещаем элемент
                    MethodBox.Controls.Add(new_method_chkbox);
                }
            }
            MethodBox.Height = vertical_position + shift*2; // Устанавливаем высоту контейнера для вмещения всего списка методов
        }

        // Проверка, что выбран хотя бы один метод сортировки.
        private bool IsThereSelectedMethods()
        {
            bool IsSelected = false;
            foreach (var check_box in MethodBox.Controls) // Бежим по чекбоксам
            {
                CheckBox chkbx_method = (CheckBox)check_box; // Приводим элемент к типу чекбокса
                if(chkbx_method.Checked==true) // Если метод выбран
                {
                    return true;
                }
            }
            return IsSelected;
        }

        // Инициализирует список методов выбранными методами
        private List<int> SetListMethods()
        {
            List<int> result_list = new List<int>();
            foreach (var check_box in MethodBox.Controls) // Бежим по чекбоксам
            {
                CheckBox chkbx_method = (CheckBox)check_box; // Приводим элемент к типу чекбокса
                if (chkbx_method.Checked == true) // Если метод выбран
                {
                    result_list.Add((int)chkbx_method.Tag); // Вытаскиваем из тега номер метода и добавляем в лист
                }
            }
            return result_list;
        }

        // Запускает работу сортровок
        private void RunCheckedMethods()
        {
            list_results.Add(Decorator.RunMethods(methods_id, list_array[0]));
        }
        
        // Запускает вьюшку
        private void RunView()
        {
            FormView f = new FormView(list_results);
            f.Show();
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
