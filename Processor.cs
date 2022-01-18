namespace Prog_Kursovaya_sem3
{
    public class Processor : RAMCompatibleObject
    {
        private string name;
        private string socketType;
        private string[] supportedChipsets;
        private int numberOfCores;
        private int numberOfThreads;
        private double baseFrequency;
        private int techprocess;
        private int maxRAMCapacityGb;
        private int energyConsumption;

        public string Name
        {
            get
            {
                return (new string(name.ToCharArray()));
            }
            set
            {
                name = new string(value.ToCharArray());
            }
        }
        public string SocketType
        {
            get
            {
                return (new string(socketType.ToCharArray()));
            }
            set
            {
                socketType = new string(value.ToCharArray());
            }
        }
        public string SupportedChipsetsString
        {
            get
            {
                string returnValue = "";
                for (int i = 0; i < supportedChipsets.Length; i++)
                {
                    if (i == supportedChipsets.Length - 1)
                        returnValue += supportedChipsets[i];
                    else
                        returnValue += supportedChipsets[i] + ',';
                }
                return (returnValue);
            }
            set
            {
                if (value.IndexOf(',') == (-1))
                {
                    supportedChipsets = new string[1];
                    supportedChipsets[0] = new string(value.ToCharArray());
                }

                else
                {
                    supportedChipsets = value.Split(',');
                }
            }
        }
        public string[] SupportedChipsetsArray
        {
            get
            {
                string[] returnArray = new string[supportedChipsets.Length];
                for (int i = 0; i < supportedChipsets.Length; i++)
                    returnArray[i] = new string(supportedChipsets[i].ToCharArray());
                return (returnArray);
            }
            set
            {
                supportedChipsets = new string[value.Length];
                for (int i = 0; i < value.Length; i++)
                    supportedChipsets[i] = new string(value[i].ToCharArray());
            }
        }
        public int NumberOfCores
        {
            get
            {
                return numberOfCores;
            }
            set
            {
                if ((value >= 1) && (value <= 128))
                    numberOfCores = value;
            }
        }
        public double BaseFrequency
        {
            get
            {
                return baseFrequency;
            }
            set
            {
                if ((value >= 1) && (value <= 5))
                    baseFrequency = value;
            }
        }
        public int NumberOfThreads
        {
            get
            {
                return numberOfThreads;
            }
            set
            {
                if ((value >= 1) && (value <= 256))
                    numberOfThreads = value;
            }
        }
        public int Techprocess
        {
            get
            {
                return techprocess;
            }
            set
            {
                if ((value >= 1) && (value <= 150))
                    techprocess = value;
            }
        }
        public int MaxRamCapacityGb
        {
            get
            {
                return maxRAMCapacityGb;
            }
            set
            {
                if ((value >= 1) && (value <= 256))
                    maxRAMCapacityGb = value;
            }
        }
        public int EnergyConsumption
        {
            get
            {
                return energyConsumption;
            }
            set
            {
                if ((value >= 1) && (value <= 300))
                    energyConsumption = value;
            }
        }


        public Processor(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            SocketType = inputSubStrings[1];
            SupportedChipsetsString = inputSubStrings[2];
            NumberOfCores = int.Parse(inputSubStrings[3]);
            BaseFrequency = double.Parse(inputSubStrings[4]);
            NumberOfThreads = int.Parse(inputSubStrings[5]);
            Techprocess = int.Parse(inputSubStrings[6]);
            MemoryType = inputSubStrings[7];
            MaxRamCapacityGb = int.Parse(inputSubStrings[8]);
            AvailableFrequenciesString = inputSubStrings[9];
            EnergyConsumption = int.Parse(inputSubStrings[10]);
        }
        public Processor(Processor inputObject)
        {
            Name = inputObject.Name;
            SocketType = inputObject.SocketType;
            SupportedChipsetsArray = inputObject.SupportedChipsetsArray;
            NumberOfCores = inputObject.NumberOfCores;
            BaseFrequency = inputObject.BaseFrequency;
            NumberOfThreads = inputObject.NumberOfThreads;
            Techprocess = inputObject.Techprocess;
            MemoryType = inputObject.MemoryType;
            MaxRamCapacityGb = inputObject.MaxRamCapacityGb;
            AvailableFrequenciesString = inputObject.AvailableFrequenciesString;
            EnergyConsumption = inputObject.EnergyConsumption;
        }
    }
}
