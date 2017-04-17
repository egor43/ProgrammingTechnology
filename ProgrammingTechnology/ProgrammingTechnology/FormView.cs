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
    public partial class FormView : Form
    {   
        // Обработка графиков и их отрисовка.
        void InitializeGraphic(List<MethodInfo> info)
        {
            // создаем элемент Chart, отображающий графики
            Chart crtGraph = new Chart();

            // Добавляем его на форму и растягиваем на все окно.
            crtGraph.Parent = this;
            crtGraph.Dock = DockStyle.Fill;
            // Добавляем в Chart область для рисования графиков.
            crtGraph.ChartAreas.Add(new ChartArea("Sort methods"));

            foreach (MethodInfo aboutMethod in info)
            {
                // Создаем и настраиваем набор точек для рисования графика, 
                // при том не забыв указать имя области на которой хотим отобразить этот набор точек.
                Series srsPoints = new Series(aboutMethod.name);
                srsPoints.ChartType = SeriesChartType.Line;
                srsPoints.ChartArea = "Sort methods";

                // Временно, пока не появились валидные данные для отображения. Эмуляция графика работы методов.
                // ----------------------------------------------------------------------------------------------
                for (int x = 0; x <= 10; x++)
                {
                    srsPoints.Points.AddXY(x, aboutMethod.time * x);
                }
                // ----------------------------------------------------------------------------------------------

                // Добавляем созданный набор точек в Chart
                crtGraph.Series.Add(srsPoints);
            }
        }
        

        public FormView()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Вызов новой формы с данными о методах.
        /// </summary>
        /// <param name="info"></param>
        public FormView(List<MethodInfo> info)
        {
            InitializeComponent();
            InitializeGraphic(info);
        }



    }
}
