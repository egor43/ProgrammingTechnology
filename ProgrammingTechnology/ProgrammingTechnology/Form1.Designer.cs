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
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.pgProcess = new System.Windows.Forms.ProgressBar();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlLoad.SuspendLayout();
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
            // pnlLoad
            // 
            this.pnlLoad.Controls.Add(this.btnStart);
            this.pnlLoad.Controls.Add(this.lblStart);
            this.pnlLoad.Controls.Add(this.ProgressBar);
            this.pnlLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoad.Location = new System.Drawing.Point(0, 0);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(526, 511);
            this.pnlLoad.TabIndex = 1;
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
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "File";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(241, 22);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(213, 41);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Открыть файл";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRun.Location = new System.Drawing.Point(241, 69);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(213, 208);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Начать работу";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pgProcess
            // 
            this.pgProcess.Location = new System.Drawing.Point(37, 457);
            this.pgProcess.Name = "pgProcess";
            this.pgProcess.Size = new System.Drawing.Size(452, 32);
            this.pgProcess.TabIndex = 5;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.Control;
            this.tbLog.Location = new System.Drawing.Point(37, 364);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(452, 73);
            this.tbLog.TabIndex = 6;
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(34, 348);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(29, 13);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "Лог:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.Location = new System.Drawing.Point(241, 284);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(213, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Сброс";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 511);
            this.Controls.Add(this.pnlLoad);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.MethodBox);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.pgProcess);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnClear);
            this.Name = "Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Методы сортировки 15-ИС-2 (Б)";
            this.pnlLoad.ResumeLayout(false);
            this.pnlLoad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MethodBox;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar pgProcess;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnClear;
    }
}

