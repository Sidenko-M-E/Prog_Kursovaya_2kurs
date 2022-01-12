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

        List<Processor> processors = new List<Processor>();
        List<CompCase> compCases = new List<CompCase>();
        List<PowerSupplyUnit> powerSupplyUnits = new List<PowerSupplyUnit>();
        List<RAM> RAMs = new List<RAM>();
        List<Videocard> videocards = new List<Videocard>();
        List<Motherboard> motherboards = new List<Motherboard>();

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("DataBases/processor.dat") || !System.IO.File.Exists("DataBases/motherboard.dat") ||
                !System.IO.File.Exists("DataBases/power supply unit.dat") || !System.IO.File.Exists("DataBases/computer case.dat") ||
                !System.IO.File.Exists("DataBases/RAM.dat") || !System.IO.File.Exists("DataBases/videocard.dat") ||
                !System.IO.File.Exists("DataBases/hard drive.dat"))
            {
                MessageBox.Show(
                    "Базы данных не найдены! Проверьте целостность приложения!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }



            //Reading the processor.dat
            FileStream fileStream = new FileStream("DataBases/processor.dat", FileMode.Open);
            StreamReader file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;
                    inputSubStrings = file.ReadLine().Split('/');

                    processors.Add(new Processor(inputSubStrings));

                    dataGridView_Processor.Rows.Add(processors[i - 1].Name,
                        "[" + processors[i - 1].NumberOfCores + " ядра, " +
                        processors[i - 1].BaseFrequency + " ГГц, " +
                         processors[i - 1].MemoryType + ", " +
                          processors[i - 1].MinRAMFrequency + "-" +
                          processors[i - 1].MaxRAMFrequency + " МГц, " +
                           processors[i - 1].EnergyConsumption + " Вт" + "]");
                }
                file.Close();
            }



            //Reading the motherboard.dat
            fileStream = new FileStream("DataBases/motherboard.dat", FileMode.Open);
            file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;
                    inputSubStrings = file.ReadLine().Split('/');

                    motherboards.Add(new Motherboard(inputSubStrings));

                    dataGridView_Motherboard.Rows.Add(motherboards[i - 1].Name,
                        "[" + motherboards[i - 1].SocketType + ", " +
                        motherboards[i - 1].ChipsetType + ", " +
                         motherboards[i - 1].NumberOfRAMSlots + "x" +
                          motherboards[i - 1].RamType + " - " +
                           motherboards[i - 1].RamAvailableFrequenciesArray[motherboards[i - 1].RamAvailableFrequenciesArray.Length - 1] + " МГц, " + 
                           motherboards[i - 1].NumberOfPCIESlots + "xPCI-Ex16" + "]");
                }
                file.Close();
            }


            //Reading the power supply unit.dat
            fileStream = new FileStream("DataBases/power supply unit.dat", FileMode.Open);
            file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;
                    inputSubStrings = file.ReadLine().Split('/');

                    powerSupplyUnits.Add(new PowerSupplyUnit(inputSubStrings));

                    dataGridView_SupplyUnit.Rows.Add(powerSupplyUnits[i - 1].Name,
                        "["+ powerSupplyUnits[i -1].FormFactor + ", " +
                        powerSupplyUnits[i -1].TotalCapacity + ", " +
                         powerSupplyUnits[i - 1].ProcessorSupplyConnectorsType + " CPU, " +
                          powerSupplyUnits[i - 1].VideocardSupplyConnectorsType + " PCI-E, " +
                           powerSupplyUnits[i - 1].NumberOfSATASlots + " SATA's" + "]");
                }
                file.Close();
            }



            //Reading the computer case.dat
            fileStream = new FileStream("DataBases/computer case.dat", FileMode.Open);
            file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;
                    inputSubStrings = file.ReadLine().Split('/');

                    compCases.Add(new CompCase(inputSubStrings));

                    dataGridView_CompCase.Rows.Add(compCases[i - 1].Name, "[" +
                        compCases[i - 1].StandardSize + ", " +
                        compCases[i - 1].MotherboardsFormFactorArray[compCases[i - 1].MotherboardsFormFactorArray.Length - 1] + ", " +
                        compCases[i - 1].Length + "x" + compCases[i - 1].Width + "x" + compCases[i - 1].Height + "]");
                }
                file.Close();
            }



            //Reading the RAM.dat
            fileStream = new FileStream("DataBases/RAM.dat", FileMode.Open);
            file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;
                    inputSubStrings = file.ReadLine().Split('/');

                    RAMs.Add(new RAM(inputSubStrings));

                    dataGridView_RAM.Rows.Add(RAMs[i - 1].Name,
                        "[" + RAMs[i - 1].MemoryCapacity + " Гб, " +
                        RAMs[i - 1].MemoryType + ", " +
                        RAMs[i - 1].AvailableFrequenciesArray[0] + "-" + 
                        RAMs[i - 1].AvailableFrequenciesArray[RAMs[i-1].AvailableFrequenciesArray.Length-1] + ", " +
                        RAMs[i - 1].Timings + "]");
                }
                file.Close();
            }



            //Reading the videocard.dat
            fileStream = new FileStream("DataBases/videocard.dat", FileMode.Open);
            file = new StreamReader(fileStream);
            if (file.Peek() < 0)
                file.Close();
            else
            {
                int i = 0;
                string[] inputSubStrings;
                while (file.Peek() >= 0)
                {
                    i++;

                    inputSubStrings = file.ReadLine().Split('/');

                    videocards.Add(new Videocard(inputSubStrings));
                    dataGridView_Videocard.Rows.Add(videocards[i-1].Name,
                        "[" + videocards[i - 1].VideoMemoryCapacity + " Гб, " +
                        videocards[i - 1].VideoMemoryType + ", " +
                        videocards[i-1].MemoryBitRate + " бит, " + 
                        videocards[i - 1].VideoChipFrequency + " МГц, " +
                        videocards[i - 1].EnergyConsumption + " Вт" + "]");
                }
                file.Close();
                
            }


        }

    }

}
