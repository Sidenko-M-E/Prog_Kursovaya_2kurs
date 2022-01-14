namespace Prog_Kursovaya_sem3
{
    public class Processor
    {
        private string name;
        private string socketType;
        private int numberOfCores;
        private int numberOfThreads;
        private double baseFrequency;
        private int techprocess;
        private string memoryType;
        private int maxRAMCapacityGb;
        private int minRAMFrequency;
        private int maxRAMFrequency;
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
        public string MemoryType
        {
            get
            {
                return (new string(memoryType.ToCharArray()));
            }
            set
            {
                memoryType = new string(value.ToCharArray());
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
                if ((value >= 1) && (value <= 128))
                    maxRAMCapacityGb = value;
            }
        }
        public int MinRAMFrequency
        {
            get
            {
                return minRAMFrequency;
            }
            set
            {
                if ((value >= 500) && (value <= 5000))
                    minRAMFrequency = value;
            }
        }
        public int MaxRAMFrequency
        {
            get
            {
                return maxRAMFrequency;
            }
            set
            {
                if ((value >= 500) && (value <= 5000))
                    maxRAMFrequency = value;
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
            NumberOfCores = int.Parse(inputSubStrings[2]);
            BaseFrequency = double.Parse(inputSubStrings[3]);
            NumberOfThreads = int.Parse(inputSubStrings[4]);
            Techprocess = int.Parse(inputSubStrings[5]);
            MemoryType = inputSubStrings[6];
            MaxRamCapacityGb = int.Parse(inputSubStrings[7]);
            MinRAMFrequency = int.Parse(inputSubStrings[8]);
            MaxRAMFrequency = int.Parse(inputSubStrings[9]);
            EnergyConsumption = int.Parse(inputSubStrings[10]);
        }
        public Processor(Processor inputObject)
        {
            Name = inputObject.Name;
            SocketType = inputObject.SocketType;
            NumberOfCores = inputObject.NumberOfCores;
            BaseFrequency = inputObject.BaseFrequency;
            NumberOfThreads = inputObject.NumberOfThreads;
            Techprocess = inputObject.Techprocess;
            MemoryType = inputObject.MemoryType;
            MaxRamCapacityGb = inputObject.MaxRamCapacityGb;
            MinRAMFrequency = inputObject.MinRAMFrequency;
            MaxRAMFrequency = inputObject.MaxRAMFrequency;
            EnergyConsumption = inputObject.EnergyConsumption;
        }
    }
}
