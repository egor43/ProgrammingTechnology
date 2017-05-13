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
            this.MethodBox = new System.Windows.Forms.GroupBox();
            this.LoadScreen = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.LoadScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // MethodBox
            // 
            this.MethodBox.Location = new System.Drawing.Point(12, 12);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(176, 265);
            this.MethodBox.TabIndex = 0;
            this.MethodBox.TabStop = false;
            this.MethodBox.Text = "Выбор методов:";
            // 
            // LoadScreen
            // 
            this.LoadScreen.Controls.Add(this.btnStart);
            this.LoadScreen.Controls.Add(this.lblStart);
            this.LoadScreen.Controls.Add(this.ProgressBar);
            this.LoadScreen.Location = new System.Drawing.Point(1, 0);
            this.LoadScreen.Name = "LoadScreen";
            this.LoadScreen.Size = new System.Drawing.Size(523, 511);
            this.LoadScreen.TabIndex = 1;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(55, 253);
            this.ProgressBar.Maximum = 80;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(407, 23);
            this.ProgressBar.Step = 20;
            this.ProgressBar.TabIndex = 0;
            this.ProgressBar.Visible = false;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStart.Location = new System.Drawing.Point(122, 196);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(264, 39);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Sorting Methods";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(160, 253);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(187, 41);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 511);
            this.Controls.Add(this.LoadScreen);
            this.Controls.Add(this.MethodBox);
            this.Name = "Controller";
            this.Text = "Controller";
            this.LoadScreen.ResumeLayout(false);
            this.LoadScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MethodBox;
        private System.Windows.Forms.Panel LoadScreen;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnStart;
    }
}

