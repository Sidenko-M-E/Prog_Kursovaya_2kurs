﻿using System;
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
            compCase = new CompCase(inputObject);
        }

        private void Form_Info_Load(object sender, EventArgs e)
        {
            switch (workingMode) {
                case 1:
                    {
                        richTextBox_Info.Text =
                        "Наименование:  " + processor.Name + "\n" +
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
                        "\nЭнергопотребление: " + processor.EnergyConsumption + " Вт";
                        break;
                    }

                case 2:
                    {
                       richTextBox_Info.Text =
                       "Наименование:  " + motherboard.Name + "\n" +
                       "Форм-фактор:  " + motherboard.FormFactor + "\n" +
                       "Тип сокета:  " + motherboard.SocketType + "\n" +
                       "Чипсет:  " + motherboard.ChipsetType + "\n" +
                       "\nИнтерфейс подключения:\n" +
                       "Разъем питания процессора:  " + motherboard.ProcessorSupplyConnectorsType + "\n" +
                       "Кол-во слотов PCI-Ex16:  " + motherboard.NumberOfPCIESlots + "\n" +
                       "Кол-во слотов SATA:  " + motherboard.NumberOfPCIESlots + "\n" +
                       "Кол-во слотов оперативной памяти: " + motherboard.NumberOfRAMSlots + "\n" +
                       "\nПараметры оперативной памяти:\n" +
                       "Форм-фактор RAM:  " + motherboard.RamFormFactor + "\n" +
                       "Тип RAM:  " + motherboard.RamType + "\n" +
                       "Максимальный объем RAM:  " + motherboard.RamMaxCapacity + " Гб\n" +
                       "Список допустимых частот:  " + motherboard.RamAvailableFrequenciesString + " МГц";
                        break;
                    }
                    
                case 3:
                    {
                        richTextBox_Info.Text =
                        "Наименование:  " + ram.Name + "\n" +
                        "Тип памяти:  " + ram.MemoryType + "\n" +
                        "Объем видеопамяти:  " + ram.MemoryCapacity + " Гб\n" +
                        "Список допустимых частот:  " + ram.AvailableFrequenciesString + "\n" +
                        "Тайминги:  " + ram.Timings + "\n" +
                        "Энергопотребление:  12 Вт\n";
                        break;
                    }

                case 4:
                    {
                        richTextBox_Info.Text =
                        "Наименование:  " + videocard.Name + "\n" +
                        "Объем видеопамяти:  " + videocard.VideoMemoryCapacity + " Гб\n" +
                        "Тип видеопамяти:  " + videocard.VideoMemoryType + "\n" +
                        "Макс. пропускная способность памяти:  " + videocard.MaxBandwidth + " Гб/с \n" +
                        "Техпроцесс:  " + videocard.TechProcess + " нм\n" +
                        "Разрядность шины памяти:  " + videocard.MemoryBitRate + " бит\n" +
                        "Частота видеочипа:  " + videocard.VideoChipFrequency + " МГц\n" +
                        "Длина видеокарты:  " + videocard.Length + " мм\n" +
                        "Кол-во занимаемых слотов расширения:" + videocard.OccupiedExpansionSlots + "\n" +
                        "Разъемы доп. питания:  " + videocard.SupplyConnectorsType + "\n" +
                        "Энергопотребление:  " + videocard.EnergyConsumption + " Вт\n";
                        break;
                    }
                    
                case 5:
                    {
                        richTextBox_Info.Text =
                        "Наименование:  " + powerSupplyUnit.Name + "\n" +
                        "Общая мощность:  " + powerSupplyUnit.TotalCapacity + " Вт\n" +
                        "Форм-фактор:  " + powerSupplyUnit.FormFactor + "\n" +
                        "Питание процессора:  " + powerSupplyUnit.ProcessorSupplyConnectorsType + "\n" +
                        "Питание видеокарты:  " + powerSupplyUnit.VideocardSupplyConnectorsType + "\n" +
                        "Слотов питания SATA-накопителей:  " + powerSupplyUnit.NumberOfSATASlots;
                        break;
                    }

                case 6:
                    {
                        richTextBox_Info.Text =
                        "Код производителя:  " + hardDrive.Name + "\n" +
                        "Общая ёмкость носителя:  " + hardDrive.MemoryCapacity + " Тб\n" +
                        "Форм-фактор:  " + hardDrive.FormFactor + "\n" +
                        "Кэш-память:  " + hardDrive.CacheSize + " Мб\n" +
                        "Максимальная скорость передачи данных:  " + hardDrive.MaxDataTransferRate + " Мбайт/с\n" +
                        "Максимальная пропускная способность интерфейса:  " + hardDrive.InterfaceBrandwidth + " Гбит/с\n" +
                        "Энергопотребление:  " + hardDrive.EnergyConsumption + " Вт\n";
                        break;
                    } 

                case 7:
                    {
                        richTextBox_Info.Text =
                        "Код производителя:  " + solidStateDrive.Name + "\n" +
                        "Общая ёмкость носителя:  " + solidStateDrive.MemoryCapacityGb + " Гб\n" +
                        "Максимальная скорость чтения:  " + solidStateDrive.MaxReadingSpeedMb + " Мб/с\n" +
                        "Максимальная скорость записи:  " + solidStateDrive.MaxWritingSpeedMb + " Мб/с\n" +
                        "Максимальный ресурс записи:  " + solidStateDrive.TotalBytesWrittenTb + " Тб\n" +
                        "Кол-во битов на ячейку:  " + solidStateDrive.BitsPerCell + "\n" +
                        "Структура памяти:  " + solidStateDrive.MemoryStructure + "\n" +
                        "Энергопоnребление:  " + solidStateDrive.EnergyConsumptionWt + " Вт\n";
                        break;
                    }

                case 8:
                    {
                        richTextBox_Info.Text =
                        "Наименование:  " + compCase.Name + "\n" +
                        "Типоразмер:  " + compCase.StandardSize + "\n" +
                        "Длина x Ширина x Высота:  " + compCase.Length + " x " + compCase.Width + " x " + compCase.Height + " мм\n" +
                        "Поддерживаемые типы мат. плат:  " + compCase.MotherboardsFormFactorString + "\n" +
                        "Поддерживаемые типы блоков питания:  " + compCase.PowerSupplyFormFactorString + "\n" +
                        "Максимальная длина устанавливаемой видеокарты: " + compCase + " мм\n" +
                        "Кол-во 2.5\" слотов:  " + compCase.NumberOfTwoAndHalfSlots + "\n" +
                        "Кол-во 3.5\" слотов:  " + compCase.NumberOfThreeAndHalfSlots + "\n" +
                        "Кол-во горизонтальных слотов расширения:  " + compCase.NumberOfHorizonExpansionSlots + "\n";
                        break;
                    }   
            } 
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
