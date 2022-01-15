﻿namespace Prog_Kursovaya_sem3
{
    public class Motherboard
    {
        private string name;
       
        private string formFactor;
        private string socketType;
        private string chipsetType;

        private string processorSupplyConnectorsType;
        private int numberOfThreePinSlotsForCooling;
        private int numberOfFourPinSlotsForCooling;
        private int numberOfPCIESlots;
        private int numberOfSATASlots;
        private int numberOfRAMSlots;

        private string ramFormFactor;
        private string ramType;
        private int ramMaxCapacity;
        private int[] ramAvailableFrequencies;


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
        public int NumberOfSATASlots
        {
            get
            {
                return numberOfSATASlots;
            }
            set
            {
                if ((value >= 1) && (value <= 20))
                    numberOfSATASlots = value;
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
        public string ChipsetType
        {
            get
            {
                return (new string(chipsetType.ToCharArray()));
            }
            set
            {
                chipsetType = new string(value.ToCharArray());
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
        public int NumberOfThreePinSlotsForCooling
        {
            get
            {
                return numberOfThreePinSlotsForCooling;
            }
            set
            {
                if ((value >= 0) && (value <= 6))
                    numberOfThreePinSlotsForCooling = value;
            }
        }
        public int NumberOfFourPinSlotsForCooling
        {
            get
            {
                return numberOfFourPinSlotsForCooling;
            }
            set
            {
                if ((value >= 0) && (value <= 6))
                    numberOfFourPinSlotsForCooling = value;
            }
        }

        public int NumberOfPCIESlots
        {
            get
            {
                return numberOfPCIESlots;
            }
            set
            {
                if ((value >= 0) && (value <= 6))
                    numberOfPCIESlots = value;
            }
        }
        public int NumberOfRAMSlots
        {
            get
            {
                return numberOfRAMSlots;
            }
            set
            {
                if ((value >= 1) && (value <= 8))
                    numberOfRAMSlots = value;
            }
        }
        public string RamFormFactor
        {
            get
            {
                return (new string(ramFormFactor.ToCharArray()));
            }
            set
            {
                ramFormFactor = new string(value.ToCharArray());
            }
        }
        public string RamType
        {
            get
            {
                return (new string(ramType.ToCharArray()));
            }
            set
            {
                ramType = new string(value.ToCharArray());
            }
        }
        public int RamMaxCapacity
        {
            get
            {
                return ramMaxCapacity;
            }
            set
            {
                if ((value >= 0) && (value <= 64))
                    ramMaxCapacity = value;
            }
        }
        public int[] RamAvailableFrequenciesArray
        {
            get
            {
                int[] returnArray = new int[ramAvailableFrequencies.Length];
                for (int i = 0; i < ramAvailableFrequencies.Length; i++)
                    returnArray[i] = ramAvailableFrequencies[i];
                return (returnArray);
            }
            set
            {
                ramAvailableFrequencies = new int[value.Length];
                for (int i = 0; i < value.Length; i++)
                    ramAvailableFrequencies[i] = value[i];
            }
        }
        public string RamAvailableFrequenciesString
        {
            get
            {
                string returnValue = "";
                for (int i = 0; i < ramAvailableFrequencies.Length; i++)
                {
                    if (i == ramAvailableFrequencies.Length - 1)
                        returnValue += ramAvailableFrequencies[i];
                    else
                        returnValue += ramAvailableFrequencies[i] + ",";
                }
                return (returnValue);
            }
            set
            {
                if (value.IndexOf(',') == (-1))
                {
                    ramAvailableFrequencies = new int[1];
                    ramAvailableFrequencies[0] = int.Parse(value);
                }

                else
                {
                    string[] bufStringArray = value.Split(',');
                    ramAvailableFrequencies = new int[bufStringArray.Length];
                    for (int i = 0; i < bufStringArray.Length; i++)
                        ramAvailableFrequencies[i] = int.Parse(bufStringArray[i]);
                }
            }
        }


        public Motherboard(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            NumberOfSATASlots = int.Parse(inputSubStrings[1]);
            FormFactor = inputSubStrings[2];
            SocketType = inputSubStrings[3];
            ChipsetType = inputSubStrings[4];
            ProcessorSupplyConnectorsType = inputSubStrings[5];
            NumberOfThreePinSlotsForCooling = int.Parse(inputSubStrings[6]);
            NumberOfFourPinSlotsForCooling = int.Parse(inputSubStrings[7]);
            NumberOfPCIESlots = int.Parse(inputSubStrings[8]);

            NumberOfRAMSlots = int.Parse(inputSubStrings[9]);
            RamFormFactor = inputSubStrings[10];
            RamType = inputSubStrings[11];
            RamMaxCapacity = int.Parse(inputSubStrings[12]);
            RamAvailableFrequenciesString = inputSubStrings[13];
        }
        public Motherboard(Motherboard inputObject)
        {
            Name = inputObject.Name;
            NumberOfSATASlots = inputObject.NumberOfSATASlots;
            FormFactor = inputObject.FormFactor;
            SocketType = inputObject.SocketType;
            ChipsetType = inputObject.ChipsetType;
            ProcessorSupplyConnectorsType = inputObject.ProcessorSupplyConnectorsType;
            NumberOfThreePinSlotsForCooling = inputObject.NumberOfThreePinSlotsForCooling;
            NumberOfFourPinSlotsForCooling = inputObject.NumberOfFourPinSlotsForCooling;
            NumberOfPCIESlots = inputObject.NumberOfPCIESlots;

            NumberOfRAMSlots = inputObject.NumberOfRAMSlots;
            RamFormFactor = inputObject.RamFormFactor;
            RamType = inputObject.RamType;
            RamMaxCapacity = inputObject.RamMaxCapacity;
            RamAvailableFrequenciesString = inputObject.RamAvailableFrequenciesString;
        }
    }
}
