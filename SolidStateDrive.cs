namespace Prog_Kursovaya_sem3
{
    public class SolidStateDrive
    {
        private string name;
        private int memoryCapacityGb;
        private int maxReadingSpeedMb;
        private int maxWritingSpeedMb;
        private int totalBytesWrittenTb;
        private string bitsPerCell;
        private string memoryStructure;
        private double energyConsumptionWt;

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
        public int MemoryCapacityGb
        {
            get
            {
                return memoryCapacityGb;
            }
            set
            {
                if ((value >= 100) && (value <= 5000))
                    memoryCapacityGb = value;
            }
        }
        public int MaxReadingSpeedMb
        {
            get
            {
                return maxReadingSpeedMb;
            }
            set
            {
                if ((value >= 100) && (value <= 1000))
                    maxReadingSpeedMb = value;
            }
        }
        public int MaxWritingSpeedMb
        {
            get
            {
                return maxWritingSpeedMb;
            }
            set
            {
                if ((value >= 100) && (value <= 1000))
                    maxWritingSpeedMb = value;
            }
        }
        public int TotalBytesWrittenTb
        {
            get
            {
                return totalBytesWrittenTb;
            }
            set
            {
                if ((value >= 10) && (value <= 8000))
                    totalBytesWrittenTb = value;
            }
        }
        public string BitsPerCell
        {
            get
            {
                return (new string(bitsPerCell.ToCharArray()));
            }
            set
            {
                bitsPerCell = new string(value.ToCharArray());
            }
        }
        public string MemoryStructure
        {
            get
            {
                return (new string(memoryStructure.ToCharArray()));
            }
            set
            {
                memoryStructure = new string(value.ToCharArray());
            }
        }
        public double EnergyConsumptionWt
        {
            get
            {
                return energyConsumptionWt;
            }
            set
            {
                if ((value >= 1) && (value <= 15))
                    energyConsumptionWt = value;
            }
        }


        public SolidStateDrive(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            MemoryCapacityGb = int.Parse(inputSubStrings[1]);
            MaxReadingSpeedMb = int.Parse(inputSubStrings[2]);
            MaxWritingSpeedMb = int.Parse(inputSubStrings[3]);
            TotalBytesWrittenTb = int.Parse(inputSubStrings[4]);
            BitsPerCell = inputSubStrings[5];
            MemoryStructure = inputSubStrings[6];
            EnergyConsumptionWt = double.Parse(inputSubStrings[7]);
        }
        public SolidStateDrive(SolidStateDrive inputObject)
        {
            Name = inputObject.Name;
            MemoryCapacityGb = inputObject.MemoryCapacityGb;
            MaxReadingSpeedMb = inputObject.MaxReadingSpeedMb;
            MaxWritingSpeedMb = inputObject.MaxWritingSpeedMb;
            TotalBytesWrittenTb = inputObject.TotalBytesWrittenTb;
            BitsPerCell = inputObject.BitsPerCell;
            MemoryStructure = inputObject.MemoryStructure;
            EnergyConsumptionWt = inputObject.EnergyConsumptionWt;
        }
    }
}