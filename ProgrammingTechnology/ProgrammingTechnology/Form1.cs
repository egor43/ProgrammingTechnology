using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testNewForm
{
    public partial class Form1 : Form
    {
        Form formLink; //используем как ссылку на объект для события btnClose_Click
        public Form1()
        {
            InitializeComponent();
            this.button1.AutoSize = true;
            this.button1.Text = "Создать форму 2";
        }

        //Само событие "Click"
        void btnClose_Click(object sender, EventArgs e)
        {
            formLink.Close(); //закрываем форму 2
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Form form2 = new Form();
                formLink = form2;
                form2.FormBorderStyle = FormBorderStyle.FixedToolWindow; //меняем стиль окна
                form2.StartPosition = FormStartPosition.CenterScreen; //отобразить в центре экрана
                form2.Text = "Новая форма номер 2"; //заголовок окна
                form2.ShowInTaskbar = false; //не показывать созданную форму на панели задач
                form2.Show(); //показать форму 2 (тоже самое, что form2.Visible = true;)  

                Button btnClose = new Button();
                btnClose.Parent = form2;
                btnClose.Text = "Закрыть";
                Point P = new Point();
                P.X = ((form2.Width / 2) - (btnClose.Width / 2));
                P.Y = (form2.Height - btnClose.Height * 3);
                btnClose.Location = P; //указываем положение кнопки на форме

                btnClose.Click += new EventHandler(btnClose_Click); //подписываем кнопку на событие "Click"
        }
    }
}
