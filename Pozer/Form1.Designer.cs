using System.Windows.Forms;

namespace Pozer
{
    partial class Main
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
            this.help = new System.Windows.Forms.Button();
            this.wayOfWorking = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.White;
            this.help.FlatAppearance.BorderSize = 0;
            this.help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help.Location = new System.Drawing.Point(0, 0);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(136, 32);
            this.help.TabIndex = 0;
            this.help.TabStop = false;
            this.help.Text = "Справка";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // wayOfWorking
            // 
            this.wayOfWorking.BackColor = System.Drawing.Color.White;
            this.wayOfWorking.FlatAppearance.BorderSize = 0;
            this.wayOfWorking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wayOfWorking.Location = new System.Drawing.Point(142, 0);
            this.wayOfWorking.Name = "wayOfWorking";
            this.wayOfWorking.Size = new System.Drawing.Size(156, 32);
            this.wayOfWorking.TabIndex = 1;
            this.wayOfWorking.TabStop = false;
            this.wayOfWorking.Text = "Режим работы";
            this.wayOfWorking.UseVisualStyleBackColor = false;
            this.wayOfWorking.Click += new System.EventHandler(this.wayOfWorking_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.White;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Location = new System.Drawing.Point(304, 0);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(150, 32);
            this.delete.TabIndex = 2;
            this.delete.TabStop = false;
            this.delete.Text = "Очистить поле";
            this.delete.UseVisualStyleBackColor = false;
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.White;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Location = new System.Drawing.Point(460, 0);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(195, 32);
            this.start.TabIndex = 3;
            this.start.TabStop = false;
            this.start.Text = "Начать решение";
            this.start.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.start);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.wayOfWorking);
            this.Controls.Add(this.help);
            this.Name = "Main";
            this.Text = "Позиционные игры";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button wayOfWorking;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button start;
    }
}

