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

        private void help_Click(object sender, EventArgs e)
        {

        }

        private void wayOfWorking_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.ShowDialog();
        }
    }
}
