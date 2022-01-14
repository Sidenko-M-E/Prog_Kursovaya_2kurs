namespace Prog_Kursovaya_sem3
{
    public class PowerSupplyUnit
    {
        private string name;
        private string formFactor;
        private int totalCapacity;
        private string processorSupplyConnectorsType;
        private string videocardSupplyConnectorsType;
        private int numberOfSATASlots;

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
        public int TotalCapacity
        {
            get
            {
                return totalCapacity;
            }
            set
            {
                if ((value >= 300) && (value <= 2000))
                    totalCapacity = value;
            }
        }
        public string ProcessorSupplyConnectorsType
        {
            get
            {
                return (new string(processorSupplyConnectorsType.ToCharArray()));
            }
            set
            {
                processorSupplyConnectorsType = new string(value.ToCharArray());
            }
        }
        public string VideocardSupplyConnectorsType
        {
            get
            {
                return (new string(videocardSupplyConnectorsType.ToCharArray()));
            }
            set
            {
                videocardSupplyConnectorsType = new string(value.ToCharArray());
            }
        }
        public int NumberOfSATASlots
        {
            get
            {
                return numberOfSATASlots;
            }
            set
            {
                if ((value >= 2) && (value <= 20))
                    numberOfSATASlots = value;
            }
        }


        public PowerSupplyUnit(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            FormFactor = inputSubStrings[1];
            TotalCapacity = int.Parse(inputSubStrings[2]);
            ProcessorSupplyConnectorsType = inputSubStrings[3];
            VideocardSupplyConnectorsType = inputSubStrings[4];
            NumberOfSATASlots = int.Parse(inputSubStrings[5]);
        }
        public PowerSupplyUnit(PowerSupplyUnit inputObject)
        {
            Name = inputObject.Name;
            FormFactor = inputObject.FormFactor;
            TotalCapacity = inputObject.TotalCapacity;
            ProcessorSupplyConnectorsType = inputObject.ProcessorSupplyConnectorsType;
            VideocardSupplyConnectorsType = inputObject.VideocardSupplyConnectorsType;
            NumberOfSATASlots = inputObject.NumberOfSATASlots;
        }
    }
}
