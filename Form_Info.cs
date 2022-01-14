using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog_Kursovaya_sem3
{
    public partial class Form_Info : Form
    {
        private int workingMode;

        private Processor processor;
        private Motherboard motherboard;
        private RAM ram;
        private Videocard videocard;
        private PowerSupplyUnit powerSupplyUnit;
        private HardDrive hardDrive;
        private SolidStateDrive solidStateDrive;
        private CompCase compCase;

        public Form_Info()
        {
            InitializeComponent();
        }
        public Form_Info(Processor inputObject)
        {
            InitializeComponent();
            workingMode = 1;
            processor = new Processor(inputObject);
        }
        public Form_Info(Motherboard inputObject)
        {
            InitializeComponent();
            workingMode = 2;
            motherboard = new Motherboard(inputObject);
        }
        public Form_Info(RAM inputObject)
        {
            InitializeComponent();
            workingMode = 3;
            ram = new RAM(inputObject);
        }

        public Form_Info(Videocard inputObject)
        {
            InitializeComponent();
            workingMode = 4;
            videocard = new Videocard(inputObject);
        }

        public Form_Info(PowerSupplyUnit inputObject)
        {
            InitializeComponent();
            workingMode = 5;
            powerSupplyUnit = new PowerSupplyUnit(inputObject);
        }

        public Form_Info(HardDrive inputObject)
        {
            InitializeComponent();
            workingMode = 6;
            hardDrive = new HardDrive(inputObject);
        }

        public Form_Info(SolidStateDrive inputObject)
        {
            InitializeComponent();
            workingMode = 7;
            solidStateDrive = new SolidStateDrive(inputObject);
        }
        public Form_Info(CompCase inputObject)
        {
            InitializeComponent();
            workingMode = 8;
            processor = new CompCase(inputObject);
        }

        private void Form_Info_Load(object sender, EventArgs e)
        {
            richTextBox_ProcessorInfo.Text =
                "Название:  " + processor.Name + "\n" +
                "Тип сокета:  " + processor.SocketType + "\n" +
                "Кол-во ядер:  " + processor.NumberOfCores + "\n" +
                "Кол-во потоков:  " + processor.NumberOfThreads + "\n" +
                "Базовая частота:  " + processor.BaseFrequency + " ГГц\n" +
                "Техпроцесс:  " + processor.Techprocess + " нм\n" +
                "\nПараметры оперативной памяти:\n" + 
                "Тип памяти:  " + processor.MemoryType + "\n" +
                "Объём памяти:  " + processor.MaxRamCapacityGb + " Гб\n" +
                "Минимальная частота RAM:  " + processor.MinRAMFrequency + " МГц\n" +
                "Максимальная частота RAM:  " + processor.MaxRAMFrequency + " МГц\n" +
                "\nПотребление энергии: " + processor.EnergyConsumption + " Вт";
        }

        private void button_InfoNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_InfoYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
