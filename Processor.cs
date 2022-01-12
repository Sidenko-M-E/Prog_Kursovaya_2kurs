namespace Prog_Kursovaya_sem3
{
    class Processor
    {
        private string name;
        private string socketType;
        private int numberOfCores;
        private double baseFrequency;
        private int numberOfThreads;
        private int techprocess;
        private string memoryType;
        private int memoryCapacity;
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
        public int MemoryCapacity
        {
            get
            {
                return memoryCapacity;
            }
            set
            {
                if ((value >= 1) && (value <= 128))
                    memoryCapacity = value;
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
            MemoryCapacity = int.Parse(inputSubStrings[7]);
            MinRAMFrequency = int.Parse(inputSubStrings[8]);
            MaxRAMFrequency = int.Parse(inputSubStrings[9]);
            EnergyConsumption = int.Parse(inputSubStrings[10]);
        }
    }
}
