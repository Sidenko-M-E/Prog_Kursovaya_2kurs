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
        List<Processor> processors = new List<Processor>();
        List<Motherboard> motherboards = new List<Motherboard>();
        List<RAM> RAMs = new List<RAM>();
        List<Videocard> videocards = new List<Videocard>();
        List<PowerSupplyUnit> powerSupplyUnits = new List<PowerSupplyUnit>();
        List<HardDrive> hardDrives = new List<HardDrive>();
        List<SolidStateDrive> solidStateDrives = new List<SolidStateDrive>();
        List<CompCase> compCases = new List<CompCase>();

        public Form_MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("DataBases/processor.dat") || !System.IO.File.Exists("DataBases/motherboard.dat") ||
                !System.IO.File.Exists("DataBases/RAM.dat") || !System.IO.File.Exists("DataBases/videocard.dat") ||
                !System.IO.File.Exists("DataBases/power supply unit.dat") || !System.IO.File.Exists("DataBases/hard drive.dat") ||
                !System.IO.File.Exists("DataBases/solid state drive.dat") || !System.IO.File.Exists("DataBases/computer case.dat"))
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
                        RAMs[i - 1].AvailableFrequenciesArray[RAMs[i - 1].AvailableFrequenciesArray.Length - 1] + ", " +
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
                    dataGridView_Videocard.Rows.Add(videocards[i - 1].Name,
                        "[" + videocards[i - 1].VideoMemoryCapacity + " Гб, " +
                        videocards[i - 1].VideoMemoryType + ", " +
                        videocards[i - 1].MemoryBitRate + " бит, " +
                        videocards[i - 1].VideoChipFrequency + " МГц, " +
                        videocards[i - 1].EnergyConsumption + " Вт" + "]");
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

                    dataGridView_PowerSupplyUnit.Rows.Add(powerSupplyUnits[i - 1].Name,
                        "["+ powerSupplyUnits[i -1].FormFactor + ", " +
                        powerSupplyUnits[i -1].TotalCapacity + ", " +
                         powerSupplyUnits[i - 1].ProcessorSupplyConnectorsType + " CPU, " +
                          powerSupplyUnits[i - 1].VideocardSupplyConnectorsType + " PCI-E, " +
                           powerSupplyUnits[i - 1].NumberOfSATASlots + " SATA's" + "]");
                }
                file.Close();
            }


            //Reading the hard drive.dat
            fileStream = new FileStream("DataBases/hard drive.dat", FileMode.Open);
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

                    hardDrives.Add(new HardDrive(inputSubStrings));

                    dataGridView_HardDrive.Rows.Add(hardDrives[i - 1].Name,
                        "[" + hardDrives[i - 1].MemoryCapacity + " Тб, " +
                        hardDrives[i - 1].FormFactor + ", " +
                        hardDrives[i - 1].InterfaceBrandwidth + " ГБит/c, " +
                        hardDrives[i - 1].CacheSize + " Мб, " +
                        hardDrives[i - 1].EnergyConsumption + " Вт" + "]");
                }
                file.Close();
            }


            //Reading the solid state drive.dat
            fileStream = new FileStream("DataBases/solid state drive.dat", FileMode.Open);
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

                    solidStateDrives.Add(new SolidStateDrive(inputSubStrings));

                    dataGridView_SolidStateDrive.Rows.Add(solidStateDrives[i - 1].Name,
                        "[" + solidStateDrives[i - 1].MemoryCapacityGb + " Гб, " +
                        "чт - " + solidStateDrives[i - 1].MaxReadingSpeedMb + " Мб/с, " +
                        "зап - " + solidStateDrives[i - 1].MaxWritingSpeedMb + " Мб/с, " +
                        "TBW - " + solidStateDrives[i - 1].TotalBytesWrittenTb + " Тб" + "]");
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
        }

        //Processor 
        private void dataGridView_Processor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var processorInfo = new Form_Info(processors[e.RowIndex]);
                if (processorInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddProcessorToAssembling();
            }
        }
        private void button_ProcessorAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить процессор:\n" +
                dataGridView_Processor.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddProcessorToAssembling();
        }
        private void MainMenu_AddProcessorToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Motherboard
        private void dataGridView_Motherboard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var motherboardInfo = new Form_MotherboardInfo(motherboards[e.RowIndex]);
                if (motherboardInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddMotherboardToAssembling();
            }
        }
        private void button_MotherboardAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить материнскую плату:\n" +
                dataGridView_Motherboard.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddMotherboardToAssembling();
        }
        private void MainMenu_AddMotherboardToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //RAM
        private void dataGridView_RAM_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var RAMInfo = new Form_RAMInfo(RAMs[e.RowIndex]);
                if (RAMInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddRAMToAssembling();
            }
        }
        private void button_RAMAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить оперативную память:\n" +
                dataGridView_RAM.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddRAMToAssembling();
        }
        private void MainMenu_AddRAMToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Videocard
        private void dataGridView_Videocard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var videocardInfo = new Form_VideocardInfo(RAMs[e.RowIndex]);
                if (videocardInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddRAMToAssembling();

            }
        }
        private void button_VideocardAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить видеокарту:\n" +
                dataGridView_Videocard.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddVideocardToAssembling();
        }
        private void MainMenu_AddVideocardToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Power supply unit
        private void dataGridView_PowerSupplyUnit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var powerSupplyUnitInfo = new Form_PowerSupplyUnitInfo(RAMs[e.RowIndex]);
                if (powerSupplyUnitInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddPowerSupplyUnitToAssembling();

            }
        }
        private void button_PowerSupplyUnitAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить блок питания:\n" +
                dataGridView_PowerSupplyUnit.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddPowerSupplyUnitToAssembling();
        }
        private void MainMenu_AddPowerSupplyUnitToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Hard drive
        private void dataGridView_HardDrive_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var hardDriveInfo = new Form_HardDriveInfo(RAMs[e.RowIndex]);
                if (hardDriveInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddHardDriveToAssembling();

            }
        }
        private void button_HardDriveAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить жесткий диск:\n" +
                dataGridView_HardDrive.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddHardDriveToAssembling();
        }
        private void MainMenu_AddHardDriveToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Solid state drive
        private void dataGridView_SolidStateDrive_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var solidStateDriveInfo = new Form_SolidStateDriveInfo(RAMs[e.RowIndex]);
                if (solidStateDriveInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddSolidStateDriveToAssembling();

            }
        }
        private void button_SolidStateDriveAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить твердотельный накопитель:\n" +
                dataGridView_SolidStateDrive.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddSolidStateDriveToAssembling();
        }
        private void MainMenu_AddSolidStateDriveToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }

        //Computer case
        private void dataGridView_CompCase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var compCaseInfo = new Form_CompCaseInfo(RAMs[e.RowIndex]);
                if (compCaseInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddCompCaseToAssembling();

            }
        }
        private void button_CompCaseAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить корпус:\n" +
                dataGridView_CompCase.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddCompCaseToAssembling();
        }
        private void MainMenu_AddCompCaseToAssembling()
        {
            MessageBox.Show("Добавили элемент к сборке");
        }










    }
}
