namespace Lab_17
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.btnOnAnim = new System.Windows.Forms.Button();
            this.btnOffAnim = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Location = new System.Drawing.Point(12, 325);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(95, 34);
            this.btnChooseColor.TabIndex = 0;
            this.btnChooseColor.Text = "Сменить цвет";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // btnOnAnim
            // 
            this.btnOnAnim.Location = new System.Drawing.Point(113, 325);
            this.btnOnAnim.Name = "btnOnAnim";
            this.btnOnAnim.Size = new System.Drawing.Size(95, 34);
            this.btnOnAnim.TabIndex = 1;
            this.btnOnAnim.Text = "Включение анимации";
            this.btnOnAnim.UseVisualStyleBackColor = true;
            this.btnOnAnim.Click += new System.EventHandler(this.btnOnAnim_Click);
            // 
            // btnOffAnim
            // 
            this.btnOffAnim.Location = new System.Drawing.Point(214, 325);
            this.btnOffAnim.Name = "btnOffAnim";
            this.btnOffAnim.Size = new System.Drawing.Size(95, 34);
            this.btnOffAnim.TabIndex = 2;
            this.btnOffAnim.Text = "Выключение анимации";
            this.btnOffAnim.UseVisualStyleBackColor = true;
            this.btnOffAnim.Click += new System.EventHandler(this.btnOffAnim_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 500;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnOffAnim);
            this.Controls.Add(this.btnOnAnim);
            this.Controls.Add(this.btnChooseColor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.Button btnOnAnim;
        private System.Windows.Forms.Button btnOffAnim;
        private System.Windows.Forms.Timer MainTimer;
    }
}

