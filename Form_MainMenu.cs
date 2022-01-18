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
        //Files from bases
        List<Processor> processors = new List<Processor>();
        List<Motherboard> motherboards = new List<Motherboard>();
        List<RAM> RAMs = new List<RAM>();
        List<Videocard> videocards = new List<Videocard>();
        List<PowerSupplyUnit> powerSupplyUnits = new List<PowerSupplyUnit>();
        List<HardDrive> hardDrives = new List<HardDrive>();
        List<SolidStateDrive> solidStateDrives = new List<SolidStateDrive>();
        List<Cooling> coolings = new List<Cooling>();
        List<CompCase> compCases = new List<CompCase>();


        //Assembling objects
        Processor assemblingProcessor;
        Motherboard assemblingMotherboard;
        RAM assemblingRAM;
        Videocard assemblingVideocard;
        PowerSupplyUnit assemblingPSU;
        HardDrive assemblingTwoAndHalfHDD;
        HardDrive assemblingThreeAndHalfHDD;
        SolidStateDrive assemblingSSD;
        Cooling assemblingCooling;
        CompCase assemblingCompCase;

        PersonalComputer personalComputer;


        public Form_MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("DataBases/processor.dat") || !System.IO.File.Exists("DataBases/motherboard.dat") ||
                !System.IO.File.Exists("DataBases/RAM.dat") || !System.IO.File.Exists("DataBases/videocard.dat") ||
                !System.IO.File.Exists("DataBases/power supply unit.dat") || !System.IO.File.Exists("DataBases/hard drive.dat") ||
                !System.IO.File.Exists("DataBases/solid state drive.dat") || !System.IO.File.Exists("DataBases/cooling.dat") ||
                !System.IO.File.Exists("DataBases/computer case.dat"))
            {
                MessageBox.Show(
                    "Базы данных не найдены! Проверьте целостность приложения!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }

            //Reading block
            {
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
                              processors[i - 1].AvailableFrequenciesArray[0] + "-" +
                              processors[i - 1].AvailableFrequenciesArray[processors[i - 1].AvailableFrequenciesArray.Length - 1] + " МГц, " +
                               processors[i - 1].EnergyConsumption + " Вт" + "]");
                    }
                    file.Close();
                }


                //Reading the motherboard.dat
                {
                    List<string> listOfFormFactors = new List<string>();
                    List<string> listOfSockets = new List<string>();
                    List<string> listOfChipsets = new List<string>();
                    List<string> listOfProcessorSupplyConnectorsType = new List<string>();
                    List<int> listOfNumberOfThreePinSlotsForCooling = new List<int>();
                    List<int> listOfNumberOfFourPinSlotsForCooling = new List<int>();
                    List<int> listOfNumberOfPCIESlots = new List<int>();
                    List<int> listOfNumberOfSATASlots = new List<int>();
                    List<int> listOfNumberOfRAMSlots = new List<int>();
                    List<string> listOfRAMFormFactor = new List<string>();
                    List<int> listOfRAMMaxCapacity = new List<int>();
                    List<string> listOfMemoryTypes = new List<string>();
                    List<int> listOfAvailableFrequencies = new List<int>();


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
                                  motherboards[i - 1].MemoryType + " - " +
                                   motherboards[i - 1].AvailableFrequenciesArray[motherboards[i - 1].AvailableFrequenciesArray.Length - 1] + " МГц, " +
                                   motherboards[i - 1].NumberOfPCIESlots + "xPCI-Ex16" + "]");

                            //Filling the lists of future searching fields
                            {
                                if (!listOfFormFactors.Contains(motherboards[i - 1].FormFactor))
                                    listOfFormFactors.Add(motherboards[i - 1].FormFactor);

                                if (!listOfSockets.Contains(motherboards[i - 1].SocketType))
                                    listOfSockets.Add(motherboards[i - 1].SocketType);

                                if (!listOfChipsets.Contains(motherboards[i - 1].ChipsetType))
                                    listOfChipsets.Add(motherboards[i - 1].ChipsetType);

                                if (!listOfProcessorSupplyConnectorsType.Contains(motherboards[i - 1].ProcessorSupplyConnectorsType))
                                    listOfProcessorSupplyConnectorsType.Add(motherboards[i - 1].ProcessorSupplyConnectorsType);

                                if (!listOfNumberOfThreePinSlotsForCooling.Contains(motherboards[i - 1].NumberOfThreePinSlotsForCooling))
                                    listOfNumberOfThreePinSlotsForCooling.Add(motherboards[i - 1].NumberOfThreePinSlotsForCooling);

                                if (!listOfNumberOfFourPinSlotsForCooling.Contains(motherboards[i - 1].NumberOfFourPinSlotsForCooling))
                                    listOfNumberOfFourPinSlotsForCooling.Add(motherboards[i - 1].NumberOfFourPinSlotsForCooling);

                                if (!listOfNumberOfPCIESlots.Contains(motherboards[i - 1].NumberOfPCIESlots))
                                    listOfNumberOfPCIESlots.Add(motherboards[i - 1].NumberOfPCIESlots);

                                if (!listOfNumberOfSATASlots.Contains(motherboards[i - 1].NumberOfSATASlots))
                                    listOfNumberOfSATASlots.Add(motherboards[i - 1].NumberOfSATASlots);

                                if (!listOfNumberOfRAMSlots.Contains(motherboards[i - 1].NumberOfRAMSlots))
                                    listOfNumberOfRAMSlots.Add(motherboards[i - 1].NumberOfRAMSlots);

                                if (!listOfRAMFormFactor.Contains(motherboards[i - 1].RamFormFactor))
                                    listOfRAMFormFactor.Add(motherboards[i - 1].RamFormFactor);

                                if (!listOfRAMMaxCapacity.Contains(motherboards[i - 1].RamMaxCapacity))
                                    listOfRAMMaxCapacity.Add(motherboards[i - 1].RamMaxCapacity);

                                if (!listOfMemoryTypes.Contains(motherboards[i - 1].MemoryType))
                                    listOfMemoryTypes.Add(motherboards[i - 1].MemoryType);

                                for (int j =0; j < motherboards[i - 1].AvailableFrequenciesArray.Length; j++)
                                    if (!listOfAvailableFrequencies.Contains(motherboards[i - 1].AvailableFrequenciesArray[j]))
                                        listOfAvailableFrequencies.Add(motherboards[i - 1].AvailableFrequenciesArray[j]);
                            }

                        }
                        file.Close();

                        //Filling the searching fields
                        {
                            foreach (var element in listOfFormFactors)
                                checkedListBox_MotherboardSearchFormFactor.Items.Add(element);

                            foreach (var element in listOfSockets)
                                checkedListBox_MotherboardSearchSocketType.Items.Add(element);

                            foreach (var element in listOfChipsets)
                                checkedListBox_MotherboardSearchChipset.Items.Add(element);

                            foreach (var element in listOfProcessorSupplyConnectorsType)
                                checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.Items.Add(element);

                            foreach (var element in listOfNumberOfThreePinSlotsForCooling)
                                checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.Items.Add(element);

                            foreach (var element in listOfNumberOfFourPinSlotsForCooling)
                                checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.Items.Add(element);

                            foreach (var element in listOfNumberOfPCIESlots)
                                checkedListBox_MotherboardSearchNumberOfPCIESlots.Items.Add(element);

                            foreach (var element in listOfNumberOfSATASlots)
                                checkedListBox_MotherboardSearchNumberOfSATASlots.Items.Add(element);

                            foreach (var element in listOfNumberOfRAMSlots)
                                checkedListBox_MotherboardSearchNumberOfRAMSlots.Items.Add(element);

                            foreach (var element in listOfRAMFormFactor)
                                checkedListBox_MotherboardSearchRAMFormFactor.Items.Add(element);

                            foreach (var element in listOfRAMMaxCapacity)
                                checkedListBox_MotherboardSearchRAMMaxCapacity.Items.Add(element);

                            foreach (var element in listOfMemoryTypes)
                                checkedListBox_MotherboardSearchMemoryType.Items.Add(element);

                            listOfAvailableFrequencies.Sort();
                            foreach (var element in listOfAvailableFrequencies)
                                checkedListBox_MotherboardSearchAvailableFrequencies.Items.Add(element);
                        }
                    }
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
                            "[" + powerSupplyUnits[i - 1].FormFactor + ", " +
                            powerSupplyUnits[i - 1].TotalCapacity + ", " +
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


                //Reading the cooling.dat
                fileStream = new FileStream("DataBases/cooling.dat", FileMode.Open);
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

                        coolings.Add(new Cooling(inputSubStrings));

                        dataGridView_Cooling.Rows.Add(coolings[i - 1].Name, "[" +
                            coolings[i - 1].DissipationPower + " Вт, " +
                            coolings[i - 1].MaxRotationSpeed + " Об/c, " +
                            coolings[i - 1].MaxNoiseLevel + " дБ, " +
                            coolings[i - 1].ConnectorType + "]");
                    }
                    file.Close();
                }
            }

            //Initial state of assembly surface
            {
                //Processor
                label_AssemblingProcessorName.Text = "не задано";
                button_AssemblingProcessorInfo.Enabled = false;
                checkBox_AssemblingProcessorEnabled.Enabled = false;
                checkBox_AssemblingProcessorEnabled.Checked = false;

                //Motherboard
                label_AssemblingMotherboardName.Text = "не задано";
                button_AssemblingMotherboardInfo.Enabled = false;
                checkBox_AssemblingMotherboardEnabled.Enabled = false;
                checkBox_AssemblingMotherboardEnabled.Checked = false;

                //RAM
                label_AssemblingRAMName.Text = "не задано";
                button_AssemblingRAMInfo.Enabled = false;
                checkBox_AssemblingRAMEnabled.Enabled = false;
                checkBox_AssemblingRAMEnabled.Checked = false;
                numericUpDown_InstalledRAMs.Value = 0;
                numericUpDown_InstalledRAMs.Minimum = 0;
                numericUpDown_InstalledRAMs.Enabled = false;

                //Videocard
                label_AssemblingVideocardName.Text = "не задано";
                button_AssemblingVideocardInfo.Enabled = false;
                checkBox_AssemblingVideocardEnabled.Enabled = false;
                checkBox_AssemblingVideocardEnabled.Checked = false;

                //Power supply unit
                label_AssemblingPSUName.Text = "не задано";
                button_AssemblingPSUInfo.Enabled = false;
                checkBox_AssemblingPSUEnabled.Enabled = false;
                checkBox_AssemblingPSUEnabled.Checked = false;

                //Cooling
                label_AssemblingCoolingName.Text = "не задано";
                button_AssemblingCoolingInfo.Enabled = false;
                checkBox_AssemblingCoolingEnabled.Enabled = false;
                checkBox_AssemblingCoolingEnabled.Checked = false;

                //SSD
                label_AssemblingSSDName.Text = "не задано";
                button_AssemblingSSDInfo.Enabled = false;
                checkBox_AssemblingSSDEnabled.Enabled = false;
                checkBox_AssemblingSSDEnabled.Checked = false;
                numericUpDown_InstalledSSD.Value = 0;
                numericUpDown_InstalledSSD.Minimum = 0;
                numericUpDown_InstalledSSD.Enabled = false;

                //2.5" HDD
                label_AssemblingTwoAndHalfHDDName.Text = "не задано";
                button_AssemblingTwoAndHalfHDDInfo.Enabled = false;
                checkBox_AssemblingTwoAndHalfHDDEnabled.Enabled = false;
                checkBox_AssemblingTwoAndHalfHDDEnabled.Checked = false;
                numericUpDown_InstalledTwoAndHalfHDD.Value = 0;
                numericUpDown_InstalledTwoAndHalfHDD.Minimum = 0;
                numericUpDown_InstalledTwoAndHalfHDD.Enabled = false;

                //3.5" HDD
                label_AssemblingThreeAndHalfHDDName.Text = "не задано";
                button_AssemblingThreeAndHalfHDDInfo.Enabled = false;
                checkBox_AssemblingThreeAndHalfHDDEnabled.Enabled = false;
                checkBox_AssemblingThreeAndHalfHDDEnabled.Checked = false;
                numericUpDown_InstalledThreeAndHalfHDD.Value = 0;
                numericUpDown_InstalledThreeAndHalfHDD.Minimum = 0;
                numericUpDown_InstalledThreeAndHalfHDD.Enabled = false;

                //Computer case
                label_AssemblingCompCaseName.Text = "не задано";
                button_AssemblingCompCaseInfo.Enabled = false;
                checkBox_AssemblingCompCaseEnabled.Enabled = false;
                checkBox_AssemblingCompCaseEnabled.Checked = false;
            }
        }

        //Processor*
        private void dataGridView_Processor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var processorInfo = new Form_Info(processors[e.RowIndex], true);
                if (processorInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(processors[e.RowIndex]);
            }
        }
        private void button_ProcessorAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить процессор:\n" +
                dataGridView_Processor.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(processors[dataGridView_Processor.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(Processor inputObject)
        {

            assemblingProcessor = new Processor(inputObject);
            label_AssemblingProcessorName.Text = assemblingProcessor.Name;
            button_AssemblingProcessorInfo.Enabled = true;
            checkBox_AssemblingProcessorEnabled.Enabled = true;
            checkBox_AssemblingProcessorEnabled.Checked = true;
        }


        //Motherboard*
        
        private void dataGridView_Motherboard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var motherboardInfo = new Form_Info(motherboards[e.RowIndex], true);
                if (motherboardInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(motherboards[e.RowIndex]);
            }
        }
        private void button_MotherboardAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить материнскую плату:\n" +
                dataGridView_Motherboard.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(motherboards[dataGridView_Motherboard.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(Motherboard inputObject)
        {
            assemblingMotherboard = new Motherboard(inputObject);
            label_AssemblingMotherboardName.Text = assemblingMotherboard.Name;
            button_AssemblingMotherboardInfo.Enabled = true;
            checkBox_AssemblingMotherboardEnabled.Enabled = true;
            checkBox_AssemblingMotherboardEnabled.Checked = true;
        }
        private void button_MotherboardResetSearch_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow element in dataGridView_Motherboard.Rows)
                if (element.Visible == false)
                    element.Visible = true;

            textBox_MotherboardSearchName.Text = "";

            for (int i = 0; i < checkedListBox_MotherboardSearchChipset.Items.Count; i++)
                if (checkedListBox_MotherboardSearchChipset.GetItemChecked(i))
                    checkedListBox_MotherboardSearchChipset.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchFormFactor.Items.Count; i++)
                if (checkedListBox_MotherboardSearchFormFactor.GetItemChecked(i))
                    checkedListBox_MotherboardSearchFormFactor.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchSocketType.Items.Count; i++)
                if (checkedListBox_MotherboardSearchSocketType.GetItemChecked(i))
                    checkedListBox_MotherboardSearchSocketType.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchChipset.Items.Count; i++)
                if (checkedListBox_MotherboardSearchChipset.GetItemChecked(i))
                    checkedListBox_MotherboardSearchChipset.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.Items.Count; i++)
                if (checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.GetItemChecked(i))
                    checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.Items.Count; i++)
                if (checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.GetItemChecked(i))
                    checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.Items.Count; i++)
                if (checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.GetItemChecked(i))
                    checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchNumberOfPCIESlots.Items.Count; i++)
                if (checkedListBox_MotherboardSearchNumberOfPCIESlots.GetItemChecked(i))
                    checkedListBox_MotherboardSearchNumberOfPCIESlots.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchNumberOfSATASlots.Items.Count; i++)
                if (checkedListBox_MotherboardSearchNumberOfSATASlots.GetItemChecked(i))
                    checkedListBox_MotherboardSearchNumberOfSATASlots.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchNumberOfRAMSlots.Items.Count; i++)
                if (checkedListBox_MotherboardSearchNumberOfRAMSlots.GetItemChecked(i))
                    checkedListBox_MotherboardSearchNumberOfRAMSlots.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchRAMFormFactor.Items.Count; i++)
                if (checkedListBox_MotherboardSearchRAMFormFactor.GetItemChecked(i))
                    checkedListBox_MotherboardSearchRAMFormFactor.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchRAMMaxCapacity.Items.Count; i++)
                if (checkedListBox_MotherboardSearchRAMMaxCapacity.GetItemChecked(i))
                    checkedListBox_MotherboardSearchRAMMaxCapacity.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchMemoryType.Items.Count; i++)
                if (checkedListBox_MotherboardSearchMemoryType.GetItemChecked(i))
                    checkedListBox_MotherboardSearchMemoryType.SetItemChecked(i, false);

            for (int i = 0; i < checkedListBox_MotherboardSearchAvailableFrequencies.Items.Count; i++)
                if (checkedListBox_MotherboardSearchAvailableFrequencies.GetItemChecked(i))
                    checkedListBox_MotherboardSearchAvailableFrequencies.SetItemChecked(i, false);
        }
        private void button_MotherboardStartASearch_Click(object sender, EventArgs e)
        {
            bool[] requestIndex = new bool[motherboards.Count];
            for (int i = 0; i < requestIndex.Length; i++)
                requestIndex[i] = true;


            if (textBox_MotherboardSearchName.Text != "")
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (motherboards[i].Name != textBox_MotherboardSearchName.Text)
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchFormFactor.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchFormFactor.CheckedItems.Contains(motherboards[i].FormFactor))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchSocketType.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchSocketType.CheckedItems.Contains(motherboards[i].SocketType))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchChipset.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchChipset.CheckedItems.Contains(motherboards[i].ChipsetType))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.CheckedItems.Contains(motherboards[i].ProcessorSupplyConnectorsType))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.CheckedItems.Contains(motherboards[i].NumberOfThreePinSlotsForCooling))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.CheckedItems.Contains(motherboards[i].NumberOfFourPinSlotsForCooling))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchNumberOfPCIESlots.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchNumberOfPCIESlots.CheckedItems.Contains(motherboards[i].NumberOfPCIESlots))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchNumberOfSATASlots.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchNumberOfSATASlots.CheckedItems.Contains(motherboards[i].NumberOfSATASlots))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchNumberOfRAMSlots.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchNumberOfRAMSlots.CheckedItems.Contains(motherboards[i].NumberOfRAMSlots))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchRAMFormFactor.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchRAMFormFactor.CheckedItems.Contains(motherboards[i].RamFormFactor))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchRAMMaxCapacity.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchRAMMaxCapacity.CheckedItems.Contains(motherboards[i].RamMaxCapacity))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchMemoryType.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        if (!checkedListBox_MotherboardSearchMemoryType.CheckedItems.Contains(motherboards[i].MemoryType))
                            requestIndex[i] = false;
            }

            if (checkedListBox_MotherboardSearchAvailableFrequencies.CheckedItems.Count != 0)
            {
                for (int i = 0; i < requestIndex.Length; i++)
                    if (requestIndex[i] == true)
                        for (int j=0;j< checkedListBox_MotherboardSearchAvailableFrequencies.CheckedItems.Count;j++)
                            if (!motherboards[i].AvailableFrequenciesArray.Contains(int.Parse(checkedListBox_MotherboardSearchAvailableFrequencies.CheckedItems[j].ToString())))
                                requestIndex[i] = false;
            }

            button_MotherboardResetSearch_Click(sender, e);
            for (int i = 0; i < requestIndex.Length; i++)
                if (requestIndex[i] == false)
                    dataGridView_Motherboard.Rows[i].Visible = false;
        }

        //RAM*
        private void dataGridView_RAM_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var RAMInfo = new Form_Info(RAMs[e.RowIndex], true);
                if (RAMInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(RAMs[e.RowIndex]);
            }
        }
        private void button_RAMAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить оперативную память:\n" +
                dataGridView_RAM.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(RAMs[dataGridView_RAM.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(RAM inputObject)
        {
            assemblingRAM = new RAM(inputObject);
            label_AssemblingRAMName.Text = assemblingRAM.Name;
            button_AssemblingRAMInfo.Enabled = true;
            checkBox_AssemblingRAMEnabled.Enabled = true;
            checkBox_AssemblingRAMEnabled.Checked = true;
            numericUpDown_InstalledRAMs.Enabled = true;
            numericUpDown_InstalledRAMs.Value = 1;
            numericUpDown_InstalledRAMs.Minimum = 1;
        }

        //Videocard*
        private void dataGridView_Videocard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var videocardInfo = new Form_Info(videocards[e.RowIndex], true);
                if (videocardInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(videocards[e.RowIndex]);

            }
        }
        private void button_VideocardAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить видеокарту:\n" +
                dataGridView_Videocard.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(videocards[dataGridView_Videocard.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(Videocard inputObject)
        {
            assemblingVideocard = new Videocard(inputObject);
            label_AssemblingVideocardName.Text = assemblingVideocard.Name;
            button_AssemblingVideocardInfo.Enabled = true;
            checkBox_AssemblingVideocardEnabled.Enabled = true;
            checkBox_AssemblingVideocardEnabled.Checked = true;
        }

        //Power supply unit*
        private void dataGridView_PowerSupplyUnit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var powerSupplyUnitInfo = new Form_Info(powerSupplyUnits[e.RowIndex], true);
                if (powerSupplyUnitInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(powerSupplyUnits[e.RowIndex]);

            }
        }
        private void button_PowerSupplyUnitAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить блок питания:\n" +
                dataGridView_PowerSupplyUnit.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(powerSupplyUnits[dataGridView_PowerSupplyUnit.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(PowerSupplyUnit inputObject)
        {
            assemblingPSU = new PowerSupplyUnit(inputObject);
            label_AssemblingPSUName.Text = assemblingPSU.Name;
            button_AssemblingPSUInfo.Enabled = true;
            checkBox_AssemblingPSUEnabled.Enabled = true;
            checkBox_AssemblingPSUEnabled.Checked = true;
        }

        //Hard drive
        private void dataGridView_HardDrive_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var hardDriveInfo = new Form_Info(hardDrives[e.RowIndex], true);
                if (hardDriveInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(hardDrives[e.RowIndex]);

            }
        }
        private void button_HardDriveAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить жесткий диск:\n" +
                dataGridView_HardDrive.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(hardDrives[dataGridView_HardDrive.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(HardDrive inputObject)
        {
            if (inputObject.FormFactor == "3.5\"")
            {
                assemblingThreeAndHalfHDD = new HardDrive(inputObject);
                label_AssemblingThreeAndHalfHDDName.Text = assemblingThreeAndHalfHDD.Name;
                button_AssemblingThreeAndHalfHDDInfo.Enabled = true;
                checkBox_AssemblingThreeAndHalfHDDEnabled.Enabled = true;
                checkBox_AssemblingThreeAndHalfHDDEnabled.Checked = true;
                numericUpDown_InstalledThreeAndHalfHDD.Enabled = true;
                numericUpDown_InstalledThreeAndHalfHDD.Value = 1;
                numericUpDown_InstalledThreeAndHalfHDD.Minimum = 1;
            }
            else
            {
                assemblingTwoAndHalfHDD = new HardDrive(inputObject);
                label_AssemblingTwoAndHalfHDDName.Text = assemblingTwoAndHalfHDD.Name;
                button_AssemblingTwoAndHalfHDDInfo.Enabled = true;
                checkBox_AssemblingTwoAndHalfHDDEnabled.Enabled = true;
                checkBox_AssemblingTwoAndHalfHDDEnabled.Checked = true;
                numericUpDown_InstalledTwoAndHalfHDD.Enabled = true;
                numericUpDown_InstalledTwoAndHalfHDD.Value = 1;
                numericUpDown_InstalledTwoAndHalfHDD.Minimum = 1;
            }
        }

        //Solid state drive*
        private void dataGridView_SolidStateDrive_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var solidStateDriveInfo = new Form_Info(solidStateDrives[e.RowIndex], true);
                if (solidStateDriveInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(solidStateDrives[e.RowIndex]);
            }
        }
        private void button_SolidStateDriveAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить твердотельный накопитель:\n" +
                dataGridView_SolidStateDrive.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(solidStateDrives[dataGridView_SolidStateDrive.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(SolidStateDrive inputObject)
        {
            assemblingSSD = new SolidStateDrive(inputObject);
            label_AssemblingSSDName.Text = assemblingSSD.Name;
            button_AssemblingSSDInfo.Enabled = true;
            checkBox_AssemblingSSDEnabled.Enabled = true;
            checkBox_AssemblingSSDEnabled.Checked = true;
            numericUpDown_InstalledSSD.Enabled = true;
            numericUpDown_InstalledSSD.Value = 1;
            numericUpDown_InstalledSSD.Minimum = 1;
        }

        //Cooling*
        private void dataGridView_Cooling_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var coolingInfo = new Form_Info(coolings[e.RowIndex], true);
                if (coolingInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(coolings[e.RowIndex]);
            }
        }
        private void button_CoolingAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить кулер:\n" +
                dataGridView_Cooling.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(coolings[dataGridView_Cooling.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(Cooling inputObject)
        {
            assemblingCooling = new Cooling(inputObject);
            label_AssemblingCoolingName.Text = assemblingCooling.Name;
            button_AssemblingCoolingInfo.Enabled = true;
            checkBox_AssemblingCoolingEnabled.Enabled = true;
            checkBox_AssemblingCoolingEnabled.Checked = true;
        }

        //Computer case*
        private void dataGridView_CompCase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var compCaseInfo = new Form_Info(compCases[e.RowIndex], true);
                if (compCaseInfo.ShowDialog() == DialogResult.Yes)
                    MainMenu_AddToAssembling(compCases[e.RowIndex]);
            }
        }
        private void button_CompCaseAddToAssembling_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите добавить корпус:\n" +
                dataGridView_CompCase.SelectedRows[0].Cells[0].Value +
                "\nк сборке?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MainMenu_AddToAssembling(compCases[dataGridView_CompCase.SelectedCells[0].RowIndex]);
        }
        private void MainMenu_AddToAssembling(CompCase inputObject)
        {
            assemblingCompCase = new CompCase(inputObject);
            label_AssemblingCompCaseName.Text = assemblingCompCase.Name;
            button_AssemblingCompCaseInfo.Enabled = true;
            checkBox_AssemblingCompCaseEnabled.Enabled = true;
            checkBox_AssemblingCompCaseEnabled.Checked = true;
        }

        //Assembling objects processing
        private void button_AssemblingProcessorInfo_Click(object sender, EventArgs e)
        {
            var processsorInfo = new Form_Info(assemblingProcessor, false);
            processsorInfo.ShowDialog();
        }
        private void button_AssemblingMotherboardInfo_Click(object sender, EventArgs e)
        {
            var motherboardInfo = new Form_Info(assemblingMotherboard, false);
            motherboardInfo.ShowDialog();
        }
        private void button_AssemblingRAMInfo_Click(object sender, EventArgs e)
        {
            var RAMInfo = new Form_Info(assemblingRAM, false);
            RAMInfo.ShowDialog();
        }
        private void button_AssemblingVideocardInfo_Click(object sender, EventArgs e)
        {
            var videocardInfo = new Form_Info(assemblingVideocard, false);
            videocardInfo.ShowDialog();
        }
        private void button_AssemblingPSUInfo_Click(object sender, EventArgs e)
        {
            var powerSupplyUnitInfo = new Form_Info(assemblingPSU, false);
            powerSupplyUnitInfo.ShowDialog();
        }
        private void button_AssemblingSSDInfo_Click(object sender, EventArgs e)
        {
            var solidStateDriveInfo = new Form_Info(assemblingSSD, false);
            solidStateDriveInfo.ShowDialog();
        }
        private void button_AssemblingTwoAndHalfHDDInfo_Click(object sender, EventArgs e)
        {
            var hardDriveInfo = new Form_Info(assemblingTwoAndHalfHDD, false);
            hardDriveInfo.ShowDialog();
        }
        private void button_AssemblingThreeAndHalfHDDInfo_Click(object sender, EventArgs e)
        {
            var hardDriveInfo = new Form_Info(assemblingThreeAndHalfHDD, false);
            hardDriveInfo.ShowDialog();
        }
        private void button_AssemblingCoolingInfo_Click(object sender, EventArgs e)
        {
            var coolingInfo = new Form_Info(assemblingCooling, false);
            coolingInfo.ShowDialog();
        }
        private void button_AssemblingCompCaseInfo_Click(object sender, EventArgs e)
        {
            var compCaseInfo = new Form_Info(assemblingCompCase, false);
            compCaseInfo.ShowDialog();
        }

        private void button_StartTheAssembling_Click(object sender, EventArgs e)
        {
            personalComputer = new PersonalComputer();
            if (checkBox_AssemblingProcessorEnabled.Checked == true)
            {
                personalComputer.assemblingProcessor = new Processor(assemblingProcessor);
                personalComputer.isProcessorChecked = true;
            }

            if (checkBox_AssemblingMotherboardEnabled.Checked == true)
            {
                personalComputer.assemblingMotherboard = new Motherboard(assemblingMotherboard);
                personalComputer.isMotherboardChecked = true;
            }

            if (checkBox_AssemblingRAMEnabled.Checked == true)
            {
                personalComputer.assemblingRAM = new RAM(assemblingRAM);
                personalComputer.isRAMChecked = true;
                personalComputer.QuantityOfRAMs = (int)numericUpDown_InstalledRAMs.Value;
            }

            if (checkBox_AssemblingVideocardEnabled.Checked == true)
            {
                personalComputer.assemblingVideocard = new Videocard(assemblingVideocard);
                personalComputer.isVideocardChecked = true;
            }

            if (checkBox_AssemblingThreeAndHalfHDDEnabled.Checked == true)
            {
                personalComputer.assemblingThreeAndHalfHDD = new HardDrive(assemblingThreeAndHalfHDD);
                personalComputer.isThreeAndHalfHDDChecked = true;
                personalComputer.QuantityOfThreeAndHalfHDDs = (int)numericUpDown_InstalledThreeAndHalfHDD.Value;
            }

            if (checkBox_AssemblingTwoAndHalfHDDEnabled.Checked == true)
            {
                personalComputer.assemblingTwoAndHalfHDD = new HardDrive(assemblingTwoAndHalfHDD);
                personalComputer.isTwoAndHalfHDDChecked = true;
                personalComputer.QuantityOfTwoAndHalfHDDs = (int)numericUpDown_InstalledTwoAndHalfHDD.Value;
            }

            if (checkBox_AssemblingSSDEnabled.Checked == true)
            {
                personalComputer.assemblingSSD = new SolidStateDrive(assemblingSSD);
                personalComputer.isSSDChecked = true;
                personalComputer.QuantityOfSSDs = (int)numericUpDown_InstalledTwoAndHalfHDD.Value;
            }

            if (checkBox_AssemblingCoolingEnabled.Checked == true)
            {
                personalComputer.assemblingCooling = new Cooling(assemblingCooling);
                personalComputer.isCoolingChecked = true;
            }

            if (checkBox_AssemblingCompCaseEnabled.Checked == true)
            {
                personalComputer.assemblingCompCase = new CompCase(assemblingCompCase);
                personalComputer.isCompCaseChecked = true;
            }

            richTextBox_AssemblingResults.Text = personalComputer.ResultOfAssembling();
        }

        private void checkedListBox_MotherboardSearchChipset_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchChipset.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchSocketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchSocketType.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchFormFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchFormFactor.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchNumberOfThreePinSlotsForCooling.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchNumberOfFourPinSlotsForCooling.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchNumberOfPCIESlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchNumberOfPCIESlots.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchNumberOfRAMSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchNumberOfRAMSlots.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchRAMFormFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchRAMFormFactor.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchProcessorSupplyConnectorsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchProcessorSupplyConnectorsType.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchRAMMaxCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchRAMMaxCapacity.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchNumberOfSATASlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchNumberOfSATASlots.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchMemoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchMemoryType.ClearSelected();
        }

        private void checkedListBox_MotherboardSearchAvailableFrequencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_MotherboardSearchAvailableFrequencies.ClearSelected();
        }
    }
}
