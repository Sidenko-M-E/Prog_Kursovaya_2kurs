namespace Prog_Kursovaya_sem3
{
    public class Videocard
    {
        private string name;
        private int videoMemoryCapacity;
        private string videoMemoryType;
        private double maxBandwidth;
        private int techProcess;
        private int memoryBitRate;
        private int videoChipFrequency;
        private int length;
        private int occupiedExpansionSlots;
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
        public double MaxBandwidth
        {
            get
            {
                return maxBandwidth;
            }
            set
            {
                if ((value >= 1) && (value <= 500))
                    maxBandwidth = value;
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
        public int MemoryBitRate
        {
            get
            {
                return memoryBitRate;
            }
            set
            {
                if ((value >= 64) && (value <= 353))
                    memoryBitRate = value;
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
        public int OccupiedExpansionSlots
        {
            get
            {
                return occupiedExpansionSlots;
            }
            set
            {
                if ((value >= 1) && (value <= 8))
                    occupiedExpansionSlots = value;
            }
        }
        public int VideoChipFrequency
        {
            get
            {
                return videoChipFrequency;
            }
            set
            {
                if ((value >= 300) && (value <= 4000))
                    videoChipFrequency = value;
            }
        }
        public string SupplyConnectorsType
        {
            get
            {
                return (new string(supplyConnectorsType.ToCharArray()));
            }
            set
            {
                supplyConnectorsType = new string(value.ToCharArray());
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
            MaxBandwidth = double.Parse(inputSubStrings[3]);
            TechProcess = int.Parse(inputSubStrings[4]);
            MemoryBitRate = int.Parse(inputSubStrings[5]);
            Length = int.Parse(inputSubStrings[6]);
            OccupiedExpansionSlots = int.Parse(inputSubStrings[7]);
            VideoChipFrequency = int.Parse(inputSubStrings[8]);
            SupplyConnectorsType = inputSubStrings[9];
            EnergyConsumption = int.Parse(inputSubStrings[10]);
        }
        public Videocard(Videocard inputObject)
        {
            Name = inputObject.Name;
            VideoMemoryCapacity = inputObject.VideoMemoryCapacity;
            VideoMemoryType = inputObject.VideoMemoryType;
            MaxBandwidth = inputObject.MaxBandwidth;
            TechProcess = inputObject.TechProcess;
            MemoryBitRate = inputObject.MemoryBitRate;
            Length = inputObject.Length;
            OccupiedExpansionSlots = inputObject.OccupiedExpansionSlots;
            VideoChipFrequency = inputObject.VideoChipFrequency;
            SupplyConnectorsType = inputObject.SupplyConnectorsType;
            EnergyConsumption = inputObject.EnergyConsumption;
        }
    }
}