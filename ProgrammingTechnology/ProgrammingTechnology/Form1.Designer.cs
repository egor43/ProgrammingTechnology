namespace ProgrammingTechnology
{
    partial class Controller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Converter_TEST = new System.Windows.Forms.Button();
            this.Decorator_TEST = new System.Windows.Forms.Button();
            this.Methods_TEST = new System.Windows.Forms.Button();
            this.View_TEST = new System.Windows.Forms.Button();
            this.All_TEST = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Converter_TEST
            // 
            this.Converter_TEST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Converter_TEST.Location = new System.Drawing.Point(47, 33);
            this.Converter_TEST.Name = "Converter_TEST";
            this.Converter_TEST.Size = new System.Drawing.Size(238, 54);
            this.Converter_TEST.TabIndex = 0;
            this.Converter_TEST.Text = "Converter TEST";
            this.Converter_TEST.UseVisualStyleBackColor = false;
            this.Converter_TEST.Click += new System.EventHandler(this.Converter_TEST_Click);
            // 
            // Decorator_TEST
            // 
            this.Decorator_TEST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Decorator_TEST.Location = new System.Drawing.Point(47, 120);
            this.Decorator_TEST.Name = "Decorator_TEST";
            this.Decorator_TEST.Size = new System.Drawing.Size(238, 54);
            this.Decorator_TEST.TabIndex = 1;
            this.Decorator_TEST.Text = "Decorator TEST";
            this.Decorator_TEST.UseVisualStyleBackColor = false;
            this.Decorator_TEST.Click += new System.EventHandler(this.Decorator_TEST_Click);
            // 
            // Methods_TEST
            // 
            this.Methods_TEST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Methods_TEST.Location = new System.Drawing.Point(47, 203);
            this.Methods_TEST.Name = "Methods_TEST";
            this.Methods_TEST.Size = new System.Drawing.Size(238, 54);
            this.Methods_TEST.TabIndex = 2;
            this.Methods_TEST.Text = "Methods TEST";
            this.Methods_TEST.UseVisualStyleBackColor = false;
            this.Methods_TEST.Click += new System.EventHandler(this.Methods_TEST_Click);
            // 
            // View_TEST
            // 
            this.View_TEST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.View_TEST.Location = new System.Drawing.Point(47, 285);
            this.View_TEST.Name = "View_TEST";
            this.View_TEST.Size = new System.Drawing.Size(238, 54);
            this.View_TEST.TabIndex = 3;
            this.View_TEST.Text = "View TEST";
            this.View_TEST.UseVisualStyleBackColor = false;
            this.View_TEST.Click += new System.EventHandler(this.View_TEST_Click);
            // 
            // All_TEST
            // 
            this.All_TEST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.All_TEST.Location = new System.Drawing.Point(315, 120);
            this.All_TEST.Name = "All_TEST";
            this.All_TEST.Size = new System.Drawing.Size(191, 137);
            this.All_TEST.TabIndex = 4;
            this.All_TEST.Text = "All TEST";
            this.All_TEST.UseVisualStyleBackColor = false;
            this.All_TEST.Click += new System.EventHandler(this.All_TEST_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 397);
            this.Controls.Add(this.All_TEST);
            this.Controls.Add(this.View_TEST);
            this.Controls.Add(this.Methods_TEST);
            this.Controls.Add(this.Decorator_TEST);
            this.Controls.Add(this.Converter_TEST);
            this.Name = "Controller";
            this.Text = "Controller";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Converter_TEST;
        private System.Windows.Forms.Button Decorator_TEST;
        private System.Windows.Forms.Button Methods_TEST;
        private System.Windows.Forms.Button View_TEST;
        private System.Windows.Forms.Button All_TEST;
    }
}

