using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pozer
{
    public partial class Main : Form
    {
        

        public Main()
        {
            InitializeComponent();
        }

        // Обработка клика на кнопку "Справка"
        private void help_Click(object sender, EventArgs e)
        {

        }

        // Обработка клика на кнопку "Режим работы"
        private void wayOfWorking_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.ShowDialog();
        }

        // Обработка хз чего в главном окне
        private void Main_Load(object sender, EventArgs e)
        {

        }

        // Обработка клика на кнопку "Очистить поле"
        private void delete_Click(object sender, EventArgs e)
        {

        }

        // Обработка клика на кнопку "Начать решение"
        private void start_Click(object sender, EventArgs e)
        {

        }
    }
}
