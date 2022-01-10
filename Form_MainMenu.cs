using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Prog_Kursovaya_sem3
{
    public partial class Form_MainMenu : Form
    {
        public Form_MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("DataBases/processor.dat") || !System.IO.File.Exists("DataBases/motherboard.dat") ||
                !System.IO.File.Exists("DataBases/power supply unit.dat") || !System.IO.File.Exists("DataBases/cooling system.dat") ||
                !System.IO.File.Exists("DataBases/RAM.dat") || !System.IO.File.Exists("DataBases/video card.dat"))
            {
                MessageBox.Show(
                    "Базы данных не найдены! Проверьте целостность приложения!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }


            FileStream fileStream = new FileStream("DataBases/computer case.dat", FileMode.Open);
            StreamReader file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else 
            {
                int count = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    count++;
                    dataGridView_CompCase.Rows.Add();
                    inputSubStrings = file.ReadLine().Split('/');
                    for (int i = 0; i < 3; i++)
                        dataGridView_CompCase.Rows[count - 1].Cells[i].Value = inputSubStrings[i];
                }
                file.Close();

                dataGridView_CompCase.Rows[1].Visible = false;
            }   
            
        }

    }

}
