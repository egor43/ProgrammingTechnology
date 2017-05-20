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

        int checked_methods = 0; //Количество выбраных методов.
        public string file_name=""; // Полное имя открытого файла
        public List<int[]> list_array = new List<int[]>(); // Лист для массива чисел
        public char[] separators = new char[] { ',', ';', ':', '.', '/', '\\', '*', '=', '^', '!', '?', '%', '$', '@', '#', '~' }; // Разделители
        List<int> methods_id = new List<int> { 1 }; // Список методов
        List<MethodInfo> result_method_info = new List<MethodInfo>(); // Лист результатов работы
        List<List<MethodInfo>> list_results = new List<List<MethodInfo>>(); // Лист, содержащий листы с результатами работы

        // Обработчик кнопки "Старт"
        private void btnStart_Click(object sender, EventArgs e)
        {
            string error_msg = ""; // Сообщение об ошибке
            LoadProcess(ref error_msg); // Загружаем приложение
            SetAvailableMethods(error_msg); // Установка доступных методов
            Utilits.LogMessage("Приложение запущено " + DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToShortTimeString(), tbLog);
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
            Utilits.LogMessage("Открыт файл: " + file_name, tbLog);
        }

        // Обработчик кнопки "Начать работу"
        private void btnRun_Click(object sender, EventArgs e)
        {
            if ( !IsThereSelectedMethods() )// Если не выбран ни один метод сортировки
            {
                Utilits.ShowMessage("Не выбраны методы сортировки");
                Utilits.LogMessage("Не выбраны методы сортировки", tbLog);
                return;
            }

            if ( file_name=="" )// Если не выбран файл
            {
                Utilits.ShowMessage("Не выбран файл");
                Utilits.LogMessage("Не выбран файл", tbLog);
                return;
            }

            Utilits.LogMessage("Запуск методов сортировки. Пожалуйста подождите...", tbLog);
            Init_Process_Progress_Bar(); // Инициализируем прогресс бар для процесса
            Decorator.CloseMethod += GoProgressBar; // Подписываемся на событие завершения метода
            methods_id = SetListMethods(); // Установка списка методов для работы
            list_array.Add(Converter.Convert(file_name, separators)); // Добавляем массив в лист для хранения
            this.Enabled = false; // Блокируем форму
            RunCheckedMethods();// Запуск работы сортировок
            RunView(); // Запуск вьюшки

            this.Enabled = true; // Разблокируем форму
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
                pnlLoad.Visible = false; //Убираем панель загрузки
                pnlLoad.Enabled = false;
            }
            catch (Exception) // Если мы выловили вообще непонятную ошибку
            {
                ProgressBar.Visible = false;
                lblStart.Text = "Что-то пошло не так...";
                Utilits.LogMessage("Что-то пошло не так", tbLog);
            }
           
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
            checked_methods = 0;
            foreach (var check_box in MethodBox.Controls) // Бежим по чекбоксам
            {
                CheckBox chkbx_method = (CheckBox)check_box; // Приводим элемент к типу чекбокса
                if(chkbx_method.Checked==true) // Если метод выбран
                {
                    checked_methods++;
                }
            }

            Utilits.LogMessage("Выбрано методов сортировки: "+ checked_methods, tbLog);

            if( 0 < checked_methods )
            {
                return true;
            }
            return false;
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

        // Инициализация прогресс бара для процесса
        private void Init_Process_Progress_Bar()
        {
            pgProcess.Value = 0;
            pgProcess.Maximum = checked_methods * 10;
        }

        // Увеличение прогресса прогресс бара
        private void GoProgressBar()
        {          
            int process_delta = pgProcess.Maximum / checked_methods;
            pgProcess.Value += process_delta;
        }

        // Очищает чекбоксы
        private void Clear_Check_Boxes()
        {
            foreach (var check_box in MethodBox.Controls) // Бежим по чекбоксам
            {
                CheckBox chkbx_method = (CheckBox)check_box; // Приводим элемент к типу чекбокса
                chkbx_method.Checked = false;
            }
        }

        // Событие изменения текста в логе
        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            this.Refresh(); // Обновляем форму
        }

        // Событие нажатия на "Очистить"
        private void btnClear_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Все данные будут потеряны. Вы уверены?", "", MessageBoxButtons.YesNo) == DialogResult.Yes )
            {
                checked_methods = 0; //Количество выбраных методов.
                file_name = ""; // Полное имя открытого файла
                list_array = new List<int[]>(); // Лист для массива чисел
                methods_id = new List<int> { 1 }; // Список методов
                result_method_info = new List<MethodInfo>(); // Лист результатов работы
                list_results = new List<List<MethodInfo>>(); // Лист, содержащий листы с результатами работы
                tbLog.Text = "";

                Clear_Check_Boxes();

            }
        }
    }
}
