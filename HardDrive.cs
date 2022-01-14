namespace Prog_Kursovaya_sem3
{
    public class HardDrive
    {
        private string name;
        private double memoryCapacity;
        private string formFactor;
        private int cacheSize;
        private int maxDataTransferRate;
        private int interfaceBrandwidth;
        private double energyConsumption;

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
        public double MemoryCapacity
        {
            get
            {
                return memoryCapacity;
            }
            set
            {
                if ((value >= 0.2) && (value <= 50))
                    memoryCapacity = value;
            }
        }
        public string FormFactor
        {
            get
            {
                return (new string(formFactor.ToCharArray()));
            }
            set
            {
                formFactor = new string(value.ToCharArray());
            }
        }
        public int CacheSize
        {
            get
            {
                return cacheSize;
            }
            set
            {
                if ((value >= 8) && (value <= 2048))
                    cacheSize = value;
            }
        }
        public int MaxDataTransferRate
        {
            get
            {
                return maxDataTransferRate;
            }
            set
            {
                if ((value >= 100) && (value <= 400))
                    maxDataTransferRate = value;
            }
        }
        public int InterfaceBrandwidth
        {
            get
            {
                return interfaceBrandwidth;
            }
            set
            {
                if ((value >= 1) && (value <= 12))
                    interfaceBrandwidth = value;
            }
        }
        public double EnergyConsumption
        {
            get
            {
                return energyConsumption;
            }
            set
            {
                if ((value >= 1) && (value <= 25))
                    energyConsumption = value;
            }
        }


        public HardDrive(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            MemoryCapacity = double.Parse(inputSubStrings[1]);
            FormFactor = inputSubStrings[2];
            CacheSize = int.Parse(inputSubStrings[3]);
            MaxDataTransferRate = int.Parse(inputSubStrings[4]);
            InterfaceBrandwidth = int.Parse(inputSubStrings[5]);
            EnergyConsumption = double.Parse(inputSubStrings[6]);
        }
        public HardDrive(HardDrive inputObject)
        {
            Name = inputObject.Name;
            MemoryCapacity = inputObject.MemoryCapacity;
            FormFactor = inputObject.FormFactor;
            CacheSize = inputObject.CacheSize;
            MaxDataTransferRate = inputObject.MaxDataTransferRate;
            InterfaceBrandwidth = inputObject.InterfaceBrandwidth;
            EnergyConsumption = inputObject.EnergyConsumption;
        }
    }
}
