using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgrammingTechnology
{
    //  Класс "FormView"
    //  Управляет одноимённой формой, нужен для визуального представления работы методов.
    // 
    //  Ответственный: Манукянц А. 

    public partial class FormView : Form
    {   
        /// <summary>
        /// Пустой вызов
        /// </summary>
        public FormView()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        ///  Вызов новой формы с данными о методах.
        /// </summary>
        /// <param name="info"></param>
        public FormView(List<List<MethodInfo>> info)
        {
            // Нужно для формы, сделанно Visual Studio.
            InitializeComponent();
            // Сами настраиваем форму, как нужно нам.
            InitializeForm();

            // Для проверки валидности данных.
            bool canDraw = true;
            List<MethodInfo> listInfo = null;
            try
            {
                // Cортируем, проверяем, улучшаем данные.
                listInfo = CheckInfo(info);
            }
            catch (ViewException exc)
            {
                canDraw = false;
                Label lblexc = new Label();
                lblexc.Text = exc.Message;
                lblexc.Name = "lblexc";
                lblexc.Parent = this;
                lblexc.Font = new Font(lblexc.Font.FontFamily, 14f, lblexc.Font.Style);
                lblexc.AutoSize = true;
            }

            // Если данные валидны рисуем график по проверенным данным.
            if (canDraw)
                DrawGraph(listInfo);
        }

        /// <summary>
        /// Настройка формы
        /// </summary>
        void InitializeForm()
        {
            this.MinimumSize = new Size(400, 300);
            this.Name = "FormView";
            this.ShowIcon = false;
        }

        /// <summary>
        /// Проверка данных на валидность. Сортировка по величине отсортированных массивов. Если что-то не так – ничего не рисуем и пишем пользователю, что он не прав
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        List<MethodInfo> CheckInfo(List<List<MethodInfo>> info)
        {
            if (info.Count == 0) throw new ViewException("Нет данных о методах. Нечего рисовать.");

            // Формирование нового списка, включающего в себя все подсписки старого.
            List<MethodInfo> listInfo = new List<MethodInfo>();
            foreach (List<MethodInfo> lol in info)
                listInfo.AddRange(lol);

            // Сортировка нового списка по значению capacity
            MethodInfo tempInfo;
            for (int i = 0; i < listInfo.Count; i++)
                for (int j = i + 1; j < listInfo.Count; j++)
                    if (listInfo[j].capacity < listInfo[i].capacity)
                        {
                            tempInfo = listInfo[j];
                            listInfo[j] = listInfo[i];
                            listInfo[i] = tempInfo;
                        }

            if (listInfo.Count == 0) throw new ViewException("Данные были, но неверные. Всё удалено. Нечего рисовать.");

            return listInfo;
        }

        /// <summary>
        /// Создание Chart и отрисовка графиков по данным
        /// </summary>
        /// <param name="info">Данные</param>
        void DrawGraph(List<MethodInfo> info)
        {
            // Создаем элемент Chart и настраиваем его.
            Chart crtGraph = new Chart();
            crtGraph.Name = "crtGraph";
            crtGraph.Parent = this;
            crtGraph.Dock = DockStyle.Fill;
            crtGraph.Palette = ChartColorPalette.SemiTransparent;

            // Добавляем в Chart область для рисования графиков.
            ChartArea methodsArea = new ChartArea("Sort methods");
            methodsArea.AxisX.Title = "Capacity";
            methodsArea.AxisY.Title = "Time";
            crtGraph.ChartAreas.Add(methodsArea);
            methodsArea.AxisY.Minimum = 0; 
            methodsArea.AxisX.Minimum = 0;

            // Добавляем в Chart область имён методов с цветом их графиков.
            Legend methodsLegend = new Legend("MethodsNames");
            methodsLegend.Title = "Methods Names";
            crtGraph.Legends.Add(methodsLegend);

            foreach (MethodInfo methodInfo in info)
            {
                // Если встречается имя метода, не отрисованного ранее.
                if (crtGraph.Series.IndexOf(methodInfo.name) == -1)
                {
                    // Создаем пустой набор точек для рисования графика. Настраиваем.
                    Series srsPoints = new Series(methodInfo.name);
                    srsPoints.ChartType = SeriesChartType.Line;
                    srsPoints.ChartArea = "Sort methods";
                    srsPoints.Legend = "MethodsNames";
                    // srsPoints.IsXValueIndexed = true;
                    srsPoints.IsVisibleInLegend = true;
                    srsPoints.BorderWidth = 2;

                    // Создание первой нулевой точки. Нужно только в этом проекте. // 
                    srsPoints.Points.AddXY(0, 0);
                    // ---------------------------------------------------------- //

                    // Добавляем созданный набор точек в Chart
                    crtGraph.Series.Add(srsPoints);
                }
                // Указываем точки графиков по длинам обрабатываемых массивов и времени их обработки
                crtGraph.Series.FindByName(methodInfo.name).Points.AddXY(methodInfo.capacity, methodInfo.time);

            }
        }

        /// <summary>
        /// Создаём данные для графиков. (Метод для тестов)
        /// </summary>
        /// <param name="methodsCount">Количество использованных методов</param>
        /// <param name="capacityCount">Количество тестов с разной величиной массива чисел</param>
        /// <returns></returns>
        public static List<List<MethodInfo>> CreateSomeGraphData(int methodsCount, int capacityCount)
        {
            //  lol – list of list
            List<List<MethodInfo>> lol = new List<List<MethodInfo>>();
            // Отступ между длиннами массивов.
            int capacityIndent = 50;

            Random rnd = new Random();

            //  Каждый List содержит информацию о работе только одного метода с разным количеством символов.
            for (int methodNumber = 0; methodNumber < methodsCount; methodNumber++)
            {
                lol.Add(new List<MethodInfo>());
                for (int capacityNumber = 0; capacityNumber < capacityCount; capacityNumber++)
                    lol.Last().Add(new MethodInfo("TestInfo" + methodNumber, capacityNumber * (methodNumber+1) * rnd.Next(1, 5), capacityNumber * capacityIndent));
            }
            return lol;
        }


#if DEBUG
        /// <summary>
        /// Тест вьюшки DEBUG
        /// </summary>
        /// <returns>Всё ли верно</returns>
        public static Dictionary<string, bool> Test()
        {
            Dictionary<string, bool> testCases = new Dictionary<string, bool>();

            List<List<MethodInfo>> lol;
            FormView f;
            Label lblexc;
            Chart crtGraph;

            //  FormView
            f = new FormView();
            if (f.MinimumSize == new Size(400, 300) && f.ShowIcon == false)
                testCases.Add("FormView", true);
            else
                testCases.Add("FormView", false);

            // FormView(List) – конструктор. 3 теста.
            // Типичная рабочая ситуация.
            lol = CreateSomeGraphData(10, 10);
            f = new FormView(lol);
            crtGraph = (Chart)f.Controls["crtGraph"];
            if (crtGraph.Legends.Count == 1 && crtGraph.ChartAreas.Count == 1)
                testCases.Add("FormView(List) : Валидные данные", true);
            else
                testCases.Add("FormView(List) : Валидные данные", false);
                
            // Список без данных
            lol = CreateSomeGraphData(0, 10);
            f = new FormView(lol);
            lblexc = (Label)f.Controls["lblexc"];
            if (lblexc.Text == "Нет данных о методах. Нечего рисовать.")
                testCases.Add("FormView(List) : 0 методов", true);
            else
                testCases.Add("FormView(List) : 0 методов", false);
                
            // Список с неверными данными
            lol = CreateSomeGraphData(10, 0);
            f = new FormView(lol);
            lblexc = (Label)f.Controls["lblexc"];
            if (lblexc.Text == "Данные были, но неверные. Всё удалено. Нечего рисовать.")
                testCases.Add("FormView(List) : 0 прогонов", true);
            else
                testCases.Add("FormView(List) : 0 прогонов", false);

            //  InitializeForm
            f = new FormView();
            f.MinimumSize = new Size(400, 300);
            f.ShowIcon = false;
            f.InitializeForm();
            if (f.MinimumSize == new Size(400, 300) && f.ShowIcon == false)
                testCases.Add("InitializeForm", true);
            else
                testCases.Add("InitializeForm", false);

            // CheckInfo
            if (testCases["FormView(List) : Валидные данные"] && testCases["FormView(List) : 0 методов"] && testCases["FormView(List) : 0 прогонов"])
                testCases.Add("CheckInfo", true);
            else
                testCases.Add("CheckInfo", false);

            // DrawGraph
            f.DrawGraph(f.CheckInfo(CreateSomeGraphData(10, 10)));
            crtGraph = (Chart)f.Controls["crtGraph"];
            if (crtGraph.Series.First().Points.First().XValue == 0)
                testCases.Add("DrawGraph", true);
            else
                testCases.Add("DrawGraph", false);

            return testCases;

            /* Запуск теста. Скопировать в основную форму для автоматического тестирования вьюшки.
                Dictionary<string, bool> viewTestCases = FormView.Test();
                string viewTestResult = "";

                foreach (var test in viewTestCases)
                    viewTestResult += test.Key + "\t" + test.Value.ToString() + "\n";

                MessageBox.Show(viewTestResult);
            */
        }
#else
        /// <summary>
        /// Вместо теста вьюшки, пустой метод тестирования при Релизе
        /// </summary>
        /// <returns>Пустой словарь</returns>
        public static Dictionary<string, bool> Test()
        {
            Dictionary<string, bool> testCases = new Dictionary<string, bool>();
            return testCases;
        }
#endif
    }

class ViewException : Exception
    {
        public ViewException(string message) : base(message)
        { }
    }
}
