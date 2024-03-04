namespace Pozer
{
    partial class Work
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numberOfVariant = new System.Windows.Forms.TextBox();
            this.labelVariant = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.checkFile = new System.Windows.Forms.RadioButton();
            this.checkManual = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // numberOfVariant
            // 
            this.numberOfVariant.AcceptsReturn = true;
            this.numberOfVariant.Enabled = false;
            this.numberOfVariant.Location = new System.Drawing.Point(227, 23);
            this.numberOfVariant.Name = "numberOfVariant";
            this.numberOfVariant.Size = new System.Drawing.Size(160, 26);
            this.numberOfVariant.TabIndex = 2;
            // 
            // labelVariant
            // 
            this.labelVariant.AutoSize = true;
            this.labelVariant.Location = new System.Drawing.Point(241, 62);
            this.labelVariant.Name = "labelVariant";
            this.labelVariant.Size = new System.Drawing.Size(135, 20);
            this.labelVariant.TabIndex = 3;
            this.labelVariant.Text = "Номер варианта";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.White;
            this.ok.Location = new System.Drawing.Point(269, 134);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(118, 37);
            this.ok.TabIndex = 5;
            this.ok.Text = "Ок";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // checkFile
            // 
            this.checkFile.AutoSize = true;
            this.checkFile.Location = new System.Drawing.Point(24, 25);
            this.checkFile.Name = "checkFile";
            this.checkFile.Size = new System.Drawing.Size(151, 24);
            this.checkFile.TabIndex = 6;
            this.checkFile.TabStop = true;
            this.checkFile.Text = "Ввод из файла";
            this.checkFile.UseVisualStyleBackColor = true;
            this.checkFile.CheckedChanged += new System.EventHandler(this.checkFile_CheckedChanged);
            // 
            // checkManual
            // 
            this.checkManual.AutoSize = true;
            this.checkManual.Location = new System.Drawing.Point(24, 104);
            this.checkManual.Name = "checkManual";
            this.checkManual.Size = new System.Drawing.Size(129, 24);
            this.checkManual.TabIndex = 7;
            this.checkManual.TabStop = true;
            this.checkManual.Text = "Ручной ввод";
            this.checkManual.UseVisualStyleBackColor = true;
            this.checkManual.CheckedChanged += new System.EventHandler(this.checkManual_CheckedChanged);
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 194);
            this.Controls.Add(this.checkManual);
            this.Controls.Add(this.checkFile);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.labelVariant);
            this.Controls.Add(this.numberOfVariant);
            this.Name = "Work";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим работы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox numberOfVariant;
        private System.Windows.Forms.Label labelVariant;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.RadioButton checkFile;
        private System.Windows.Forms.RadioButton checkManual;
    }
}