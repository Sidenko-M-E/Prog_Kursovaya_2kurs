using System.Linq;

namespace Prog_Kursovaya_sem3
{
    public class PersonalComputer
    {
        //Attributes
        public Processor assemblingProcessor;
        public Motherboard assemblingMotherboard;
        public RAM assemblingRAM;
        private int quantityOfRAMs;
        public Videocard assemblingVideocard;
        public PowerSupplyUnit assemblingPSU;

        public HardDrive assemblingThreeAndHalfHDD;
        private int quantityOfThreeAndHalfHDDs;

        public HardDrive assemblingTwoAndHalfHDD;
        private int quantityOfTwoAndHalfHDDs;

        public SolidStateDrive assemblingSSD;
        private int quantityOfSSDs;

        public Cooling assemblingCooling;
        public CompCase assemblingCompCase;

        public bool isProcessorChecked;
        public bool isMotherboardChecked;
        public bool isRAMChecked;
        public bool isVideocardChecked;
        public bool isPSUChecked;
        public bool isThreeAndHalfHDDChecked;
        public bool isTwoAndHalfHDDChecked;
        public bool isSSDChecked;
        public bool isCoolingChecked;
        public bool isCompCaseChecked;


        //Methods
        public int QuantityOfRAMs
        {
            get
            {
                return quantityOfRAMs;
            }
            set
            {
                if ((value >= 0) && (value <= 8))
                    quantityOfRAMs = value;
            }
        }
        public int QuantityOfThreeAndHalfHDDs
        {
            get
            {
                return quantityOfThreeAndHalfHDDs;
            }
            set
            {
                if ((value >= 0) && (value <= 10))
                    quantityOfThreeAndHalfHDDs = value;
            }
        }
        public int QuantityOfTwoAndHalfHDDs
        {
            get
            {
                return quantityOfTwoAndHalfHDDs;
            }
            set
            {
                if ((value >= 0) && (value <= 10))
                    quantityOfTwoAndHalfHDDs = value;
            }
        }
        public int QuantityOfSSDs
        {
            get
            {
                return quantityOfSSDs;
            }
            set
            {
                if ((value >= 0) && (value <= 10))
                    quantityOfSSDs = value;
            }
        }

        public string ResultOfAssembling()
        {
            string returnValue = "Проблем нет";
            string resultOfAssembling = "";

            if (isProcessorChecked == true)
            {
                if (isMotherboardChecked == true)
                {
                    if (assemblingProcessor.SocketType != assemblingMotherboard.SocketType)
                        resultOfAssembling += "(*)Несовпадение типа сокета у материнской платы и процессора!!!\n";
                    if (!assemblingProcessor.SupportedChipsetsArray.Contains(assemblingMotherboard.ChipsetType))
                        resultOfAssembling += "(*)Процессор не поддерживает чипсет материнской платы!!!\n";
                    if (assemblingProcessor.MemoryType != assemblingMotherboard.RamType)
                        resultOfAssembling += "(*)Типы памяти процессора и материнской платы не совместимы!!!\n";
                    if ((assemblingProcessor.MaxRAMFrequency < assemblingMotherboard.RamAvailableFrequenciesArray[0]) ||
                        (assemblingProcessor.MinRAMFrequency > assemblingMotherboard.RamAvailableFrequenciesArray[assemblingMotherboard.RamAvailableFrequenciesArray.Length - 1]))
                        resultOfAssembling += "(*)Процессор и материнская плата имеют непересекающиеся диапазоны поддерживаемых частот!!!\n";
                }

                if (isRAMChecked == true)
                {
                    if (assemblingProcessor.MemoryType != assemblingRAM.MemoryType)
                        resultOfAssembling += "(*)Тип памяти процессора и оперативной памяти не совместимы!!!\n";
                    if (assemblingProcessor.MaxRamCapacityGb < assemblingRAM.MemoryCapacity * quantityOfRAMs)
                        resultOfAssembling += "(*)Превышен лимит по объему оперативной памяти для процесссора!!!\n";
                }

                if (isCoolingChecked == true)
                {
                    if (assemblingProcessor.EnergyConsumption > assemblingCooling.DissipationPower)
                        resultOfAssembling += "(*)Кулер не справляется с охлаждением процессора!!!\n"; ;
                }
            }

            if (isMotherboardChecked == true)
            {
                if (isRAMChecked == true)
                {
                    if (assemblingMotherboard.RamType != assemblingRAM.MemoryType)
                        resultOfAssembling += "(*)Типы памяти материнской платы и оперативной памяти не совместимы!!!\n";

                    if ((assemblingMotherboard.RamAvailableFrequenciesArray[assemblingMotherboard.RamAvailableFrequenciesArray.Length - 1] < assemblingRAM.AvailableFrequenciesArray[0]) ||
                        (assemblingMotherboard.RamAvailableFrequenciesArray[0] > assemblingRAM.AvailableFrequenciesArray[assemblingRAM.AvailableFrequenciesArray.Length - 1]))
                        resultOfAssembling += "(*)Материнская плата и оперативная память имеют непересекающиеся диапазоны поддерживаемых частот!!!\n";

                    if (assemblingMotherboard.RamMaxCapacity < assemblingRAM.MemoryCapacity * quantityOfRAMs)
                        resultOfAssembling += "(*)Превышен лимит по объему оперативной памяти для материнской платы!!!\n";

                    if (assemblingMotherboard.NumberOfRAMSlots < quantityOfRAMs)
                        resultOfAssembling += "(*)У материнской платы недостаточно слотов для оперативной памяти!!!\n";
                }

                if (isVideocardChecked == true)
                {
                    if (assemblingMotherboard.NumberOfPCIESlots == 0)
                        resultOfAssembling += "(*)Данная материнская плата не поддерживает установку видеокарт!!!\n";
                }

                if (isPSUChecked == true)
                {
                    if ((assemblingMotherboard.ProcessorSupplyConnectorsType == "4 pin") &&
                        (assemblingPSU.ProcessorSupplyConnectorsType == "1x8 pin"))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки процесора, устанавливаемого на данную материнскую плату!!!\n";

                    if ((assemblingMotherboard.ProcessorSupplyConnectorsType == "4+4 pin") &&
                        ((assemblingPSU.ProcessorSupplyConnectorsType == "1x4 pin") ||
                        (assemblingPSU.ProcessorSupplyConnectorsType == "1x8 pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки процесора, устанавливаемого на данную материнскую плату!!!\n";

                    if ((assemblingMotherboard.ProcessorSupplyConnectorsType == "8 pin") &&
                        (assemblingPSU.ProcessorSupplyConnectorsType == "1x4 pin"))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки процесора, устанавливаемого на данную материнскую плату!!!\n";

                    if ((assemblingMotherboard.ProcessorSupplyConnectorsType == "4+8 pin") &&
                        ((assemblingPSU.ProcessorSupplyConnectorsType == "1x4 pin") ||
                        (assemblingPSU.ProcessorSupplyConnectorsType == "1x(4+4) pin") ||
                        (assemblingPSU.ProcessorSupplyConnectorsType == "1x8 pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки процесора, устанавливаемого на данную материнскую плату!!!\n";

                    if ((assemblingMotherboard.ProcessorSupplyConnectorsType == "8+8 pin") &&
                       ((assemblingPSU.ProcessorSupplyConnectorsType == "1x4 pin") ||
                       (assemblingPSU.ProcessorSupplyConnectorsType == "1x(4+4) pin") ||
                       (assemblingPSU.ProcessorSupplyConnectorsType == "1x8 pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки процесора, устанавливаемого на данную материнскую плату!!!\n";
                }

                //Checking the drives
                {
                    int numberOfSATAOccupiedPorts = 0;
                    if (isThreeAndHalfHDDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfThreeAndHalfHDDs;

                    if (isTwoAndHalfHDDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfTwoAndHalfHDDs;

                    if (isSSDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfSSDs;

                    if (assemblingMotherboard.NumberOfSATASlots < numberOfSATAOccupiedPorts)
                        resultOfAssembling += "(*)У материнской платы недостаточно разъемов для подключения всех накопителей!!!\n";
                }

                if (isCoolingChecked == true)
                {
                    if ((assemblingCooling.ConnectorType == "3 pin") &&
                        (assemblingMotherboard.NumberOfThreePinSlotsForCooling == 0) &&
                        (assemblingMotherboard.NumberOfFourPinSlotsForCooling == 0))
                        resultOfAssembling += "(*)Материнская плата не имеет разъемов для подключения данного кулера!!!\n";
                    if ((assemblingCooling.ConnectorType == "4 pin") && (assemblingMotherboard.NumberOfFourPinSlotsForCooling == 0))
                        resultOfAssembling += "(*)Материнская плата не имеет разъемов для подключения данного кулера!!!\n";
                }

                if (isCompCaseChecked == true)
                {
                    if (!assemblingCompCase.MotherboardsFormFactorArray.Contains(assemblingMotherboard.FormFactor))
                        resultOfAssembling += "(*)Данный корпус не поддерживает установку материнской платы данного форм-фактора!!!\n";
                }
            }

            if (isVideocardChecked == true)
            {
                if (isPSUChecked == true)
                {
                    if ((assemblingVideocard.SupplyConnectorsType == "6 pin") &&
                         (assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x8 pin"))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";

                    if ((assemblingVideocard.SupplyConnectorsType == "1x8 pin") &&
                        ((assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "2x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "3x6 pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";

                    if ((assemblingVideocard.SupplyConnectorsType == "2x8 pin") &&
                        ((assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "2x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "3x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x8 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x(6+2) pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";

                    if ((assemblingVideocard.SupplyConnectorsType == "3x8 pin") &&
                        ((assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "2x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "3x6 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x8 pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "1x(6+2) pin") ||
                        (assemblingPSU.VideocardSupplyConnectorsType == "2x(6+2) pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";

                    if ((assemblingVideocard.SupplyConnectorsType == "1x(6+8) pin") &&
                         ((assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "2x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "3x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x8 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x(6+2) pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";

                    if ((assemblingVideocard.SupplyConnectorsType == "2x(6+8) pin") &&
                         ((assemblingPSU.VideocardSupplyConnectorsType == "none") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "2x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "3x6 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x8 pin") ||
                         (assemblingPSU.VideocardSupplyConnectorsType == "1x(6+2) pin") ||
                          (assemblingPSU.VideocardSupplyConnectorsType == "2x(6+2) pin") ||
                           (assemblingPSU.VideocardSupplyConnectorsType == "3x(6+2) pin")))
                        resultOfAssembling += "(*)Блок питания не имеет разъемов для запитки данной видеокарты!!!\n";
                }

                if (isCompCaseChecked == true)
                {
                    if (assemblingVideocard.Length > assemblingCompCase.VideocardMaxLength)
                        resultOfAssembling += "(*)Данная видеокарта слишком длинная для данного корпуса!!!\n";

                    if (assemblingVideocard.OccupiedExpansionSlots > assemblingCompCase.NumberOfHorizonExpansionSlots)
                        resultOfAssembling += "(*)У данного корпуса недостаточно горизонтальных слотов расширения для установки данной видеокарты!!!\n";
                }
            }

            if (isPSUChecked == true)
            {
                if (isCompCaseChecked == true)
                {
                    if (!assemblingCompCase.PowerSupplyFormFactorArray.Contains(assemblingPSU.FormFactor))
                        resultOfAssembling += "(*)Данный корпус не поддерживает установку блока питания данного форм-фактора!!!\n";
                }

                //Checking the drives
                {
                    int numberOfSATAOccupiedPorts = 0;
                    if (isThreeAndHalfHDDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfThreeAndHalfHDDs;

                    if (isTwoAndHalfHDDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfTwoAndHalfHDDs;

                    if (isSSDChecked == true)
                        numberOfSATAOccupiedPorts += (int)quantityOfSSDs;

                    if (assemblingPSU.NumberOfSATASlots < numberOfSATAOccupiedPorts)
                        resultOfAssembling += "(*)У данного блока питания недостаточно слотов для подключения всех накопителей!!!\n";
                }

                //Checking the total capacity of system
                {
                    double systemTotalCapacity = 0;
                    if (isProcessorChecked == true)
                        systemTotalCapacity += assemblingProcessor.EnergyConsumption;

                    if (isRAMChecked == true)
                        systemTotalCapacity += (double)quantityOfRAMs * 7;

                    if (isVideocardChecked == true)
                        systemTotalCapacity += assemblingVideocard.EnergyConsumption;

                    if (isThreeAndHalfHDDChecked == true)
                        systemTotalCapacity += assemblingThreeAndHalfHDD.EnergyConsumption * (double)quantityOfThreeAndHalfHDDs;

                    if (isTwoAndHalfHDDChecked == true)
                        systemTotalCapacity += assemblingTwoAndHalfHDD.EnergyConsumption * (double)quantityOfTwoAndHalfHDDs;

                    if (isSSDChecked == true)
                        systemTotalCapacity += assemblingSSD.EnergyConsumptionWt * (double)quantityOfSSDs;

                    if (isCoolingChecked == true)
                        systemTotalCapacity += 5;

                    if (assemblingPSU.TotalCapacity < systemTotalCapacity * 1.2)
                        resultOfAssembling += "(*)Данный блок питания не обладает достаточной мощностью!!!\n";
                }
            }

            if (isCoolingChecked == true)
            {
                if (isCompCaseChecked == true)
                {
                    if (assemblingCooling.Height > assemblingCompCase.CoolingMaxHeight)
                        resultOfAssembling += "(*)Данный кулер слишком высокий для данного корпуса!!!\n";
                }
            }

            if (isCompCaseChecked == true)
            {
                if (isThreeAndHalfHDDChecked == true)
                {
                    if (assemblingCompCase.NumberOfThreeAndHalfSlots < quantityOfThreeAndHalfHDDs)
                        resultOfAssembling += "(*)Данный корпус не имеет достаточного кол-ва слотов для установки всех 3.5\" накопителей!!!\n";
                }

                //Checking the 2.5" slots
                {
                    int numberOfOccupiedTwoAndHalfSlots = 0;
                    if (isTwoAndHalfHDDChecked == true)
                        numberOfOccupiedTwoAndHalfSlots += (int)quantityOfTwoAndHalfHDDs;

                    if (isSSDChecked == true)
                        numberOfOccupiedTwoAndHalfSlots += (int)quantityOfSSDs;

                    if (assemblingCompCase.NumberOfTwoAndHalfSlots < numberOfOccupiedTwoAndHalfSlots)
                        resultOfAssembling += "(*)Данный корпус не имеет достаточного кол-ва слотов для установки всех 2.5\" накопителей!!!\n";
                }
            }

            if (resultOfAssembling != "")
                returnValue = new string(resultOfAssembling.ToCharArray());

            return (returnValue);
        }
    }
}
