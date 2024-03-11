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
            this.help.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(169, 38);
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
            this.wayOfWorking.Location = new System.Drawing.Point(171, 0);
            this.wayOfWorking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wayOfWorking.Name = "wayOfWorking";
            this.wayOfWorking.Size = new System.Drawing.Size(169, 38);
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
            this.delete.Location = new System.Drawing.Point(342, 0);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(169, 38);
            this.delete.TabIndex = 2;
            this.delete.TabStop = false;
            this.delete.Text = "Очистить поле";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.White;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Location = new System.Drawing.Point(512, 0);
            this.start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(169, 38);
            this.start.TabIndex = 3;
            this.start.TabStop = false;
            this.start.Text = "Начать решение";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 866);
            this.Controls.Add(this.start);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.wayOfWorking);
            this.Controls.Add(this.help);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Позиционные игры";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button wayOfWorking;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button start;
    }
}

