namespace Prog_Kursovaya_sem3
{
    class Videocard
    {
        private string name;
        private int videoMemoryCapacity;
        private string videoMemoryType;
        private int bandwidth;
        private int techProcess;
        private int length;
        private string supplyConnectorsType;
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
        public int VideoMemoryCapacity
        {
            get
            {
                return videoMemoryCapacity;
            }
            set
            {
                if ((value >= 1) && (value <= 24))
                    videoMemoryCapacity = value;
            }
        }
        public string VideoMemoryType
        {
            get
            {
                return (new string(videoMemoryType.ToCharArray()));
            }
            set
            {
                videoMemoryType = new string(value.ToCharArray());
            }
        }
        public int Bandwidth
        {
            get
            {
                return bandwidth;
            }
            set
            {
                if ((value >= 1) && (value <= 100))
                    bandwidth = value;
            }
        }
        public int TechProcess
        {
            get
            {
                return techProcess;
            }
            set
            {
                if ((value >= 1) && (value <= 150))
                    techProcess = value;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if ((value >= 80) && (value <= 500))
                    length = value;
            }
        }
        public string SupplyConnectorsType
        {
            get
            {
                return (new string(videoMemoryType.ToCharArray()));
            }
            set
            {
                videoMemoryType = new string(value.ToCharArray());
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
                if ((value >= 10) && (value <= 500))
                    energyConsumption = value;
            }
        }

        public Videocard(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            VideoMemoryCapacity = int.Parse(inputSubStrings[1]);
            VideoMemoryType = inputSubStrings[2];
            Bandwidth = int.Parse(inputSubStrings[3]);
            TechProcess;
        Length;
        DupplyConnectorsType;
        EnergyConsumption;
    
            MemoryCapacity = int.Parse(inputSubStrings[1]);
            MemoryType = inputSubStrings[2];
            AvailableFrequenciesString = inputSubStrings[3];
            Timings = inputSubStrings[4];
        }
    }
}
