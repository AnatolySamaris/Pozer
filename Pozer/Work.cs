using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pozer
{
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            //if (checkFile.Checked && checkManual.Checked)
            //{
            //    MessageBox.Show("Можно выбрать только один вариант!");
            //}

            if (checkFile.Checked)
            {
                Regex regex = new Regex("[0-9]+");
                if (numberOfVariant.Text == "")
                {
                    MessageBox.Show("Введите номер варианта!");
                }
                else
                {
                    if (regex.IsMatch(numberOfVariant.Text))
                    {
                        if (Int32.Parse(numberOfVariant.Text) < 0 || Int32.Parse(numberOfVariant.Text) > 100)
                        {
                            MessageBox.Show("Номер варианта может содержать только числа от 1 до 100");
                        }
                        else
                        {
                            // выбран ввод из файла
                            ;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер варианта может содержать только числа от 1 до 100");
                    }
                }
            }

            else if (checkManual.Checked)
            {
                // выбран ручной ввод
                //Main main = new Main();
                //main.CreateNode();
                //main.DrawGraph();
            }

            else
            {
                MessageBox.Show("Выберете режим работы");
            }
        }

        private void checkFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFile.Checked) numberOfVariant.Enabled = true;
            else
            {
                numberOfVariant.Text = "";
                numberOfVariant.Enabled = false;
            }
        }

        private void checkManual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkManual.Checked)
            {
                numberOfVariant.Text = "";
                numberOfVariant.Enabled = false;
            }
        }
    }
}
