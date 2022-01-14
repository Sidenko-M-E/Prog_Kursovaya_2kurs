namespace Prog_Kursovaya_sem3
{
    public class CompCase
    {
        private string name;
        private string standardSize;
        private int length;
        private int width;
        private int height;
        private string[] motherboardsFormFactor;
        private string[] powerSupplyFormFactor;
        private int videocardMaxLength;
        private int numberOfTwoAndHalfSlots;
        private int numberOfThreeAndHalfSlots;
        private int numberOfHorizonExpansionSlots;

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
        public string StandardSize
        {
            get
            {
                return (new string(standardSize.ToCharArray()));
            }
            set
            {
                standardSize = new string(value.ToCharArray());
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
                if ((value >= 0) && (value <= 600))
                   length = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if ((value >= 0) && (value <= 600))
                    width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if ((value >= 0) && (value <= 600))
                    height = value;
            }
        }
        public string MotherboardsFormFactorString
        {
            get
            {
                string returnValue = "";
                for (int i = 0; i < motherboardsFormFactor.Length; i++)
                {
                    if (i == motherboardsFormFactor.Length - 1)
                        returnValue += motherboardsFormFactor[i];
                    else
                        returnValue += motherboardsFormFactor[i] + ',';
                }
                return (returnValue);
            }
            set
            {
                if (value.IndexOf(',') == (-1))
                {
                    motherboardsFormFactor = new string[1];
                    motherboardsFormFactor[0] = new string(value.ToCharArray());
                }
                    
                else
                {
                    motherboardsFormFactor = value.Split(',');
                }
            }
        }
        public string[] MotherboardsFormFactorArray
        {
            get
            {
                string[] returnArray = new string[motherboardsFormFactor.Length];
                for (int i = 0; i < motherboardsFormFactor.Length; i++)
                    returnArray[i] = new string(motherboardsFormFactor[i].ToCharArray());
                return (returnArray);
            }
            set
            {
                motherboardsFormFactor = new string[value.Length];
                for (int i = 0; i < value.Length; i++)
                    motherboardsFormFactor[i] = new string(value[i].ToCharArray());
            }
        }
        public string PowerSupplyFormFactorString
        {
            get
            {
                string returnValue = "";
                for (int i = 0; i < powerSupplyFormFactor.Length; i++)
                {
                    if (i == powerSupplyFormFactor.Length - 1)
                        returnValue += powerSupplyFormFactor[i];
                    else
                        returnValue += powerSupplyFormFactor[i] + ',';
                }
                return (returnValue);
            }
            set
            {
                if (value.IndexOf(',') == (-1))
                {
                    powerSupplyFormFactor = new string[1];
                    powerSupplyFormFactor[0] = new string(value.ToCharArray());
                }
   
                else
                {
                    powerSupplyFormFactor = value.Split(',');
                }

            }

        }
        public string[] PowerSupplyFormFactorArray
        {
            get
            {
                string[] returnArray = new string[powerSupplyFormFactor.Length];
                for (int i = 0; i < powerSupplyFormFactor.Length; i++)
                    returnArray[i] = new string(powerSupplyFormFactor[i].ToCharArray());
                return (returnArray);
            }
            set
            {
                powerSupplyFormFactor = new string[value.Length];
                for (int i = 0; i < value.Length; i++)
                    powerSupplyFormFactor[i] = new string(value[i].ToCharArray());
            }
        }
        public int VideocardMaxLength
        {
            get
            {
                return videocardMaxLength;
            }
            set
            {
                if ((value >= 0) && (value <= 1000))
                    videocardMaxLength = value;
            }
        }
        public int NumberOfTwoAndHalfSlots
        {
            get
            {
                return numberOfTwoAndHalfSlots;
            }
            set
            {
                if ((value >= 0) && (value <= 10))
                    numberOfTwoAndHalfSlots = value;
            }
        }
        public int NumberOfThreeAndHalfSlots
        {
            get
            {
                return numberOfThreeAndHalfSlots;
            }
            set
            {
                if ((value >= 0) && (value <= 10))
                    numberOfThreeAndHalfSlots = value;
            }
        }
        public int NumberOfHorizonExpansionSlots
        {
            get
            {
                return numberOfHorizonExpansionSlots;
            }
            set
            {
                if ((value >= 0) && (value <= 15))
                    numberOfHorizonExpansionSlots = value;
            }
        }


        public CompCase(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            StandardSize = inputSubStrings[1];
            Length = int.Parse(inputSubStrings[2]);
            Width = int.Parse(inputSubStrings[3]);
            Height = int.Parse(inputSubStrings[4]);
            MotherboardsFormFactorString = inputSubStrings[5];
            PowerSupplyFormFactorString = inputSubStrings[6];
            VideocardMaxLength = int.Parse(inputSubStrings[7]);
            NumberOfTwoAndHalfSlots = int.Parse(inputSubStrings[8]);
            NumberOfThreeAndHalfSlots = int.Parse(inputSubStrings[9]);
            NumberOfHorizonExpansionSlots = int.Parse(inputSubStrings[10]);
        }
        public CompCase(CompCase inputObject)
        {
            Name = inputObject.Name;
            StandardSize = inputObject.StandardSize;
            Length = inputObject.Length;
            Width = inputObject.Width;
            Height = inputObject.Height;
            MotherboardsFormFactorString = inputObject.MotherboardsFormFactorString;
            PowerSupplyFormFactorString = inputObject.PowerSupplyFormFactorString;
            VideocardMaxLength = inputObject.VideocardMaxLength;
            NumberOfTwoAndHalfSlots = inputObject.NumberOfTwoAndHalfSlots;
            NumberOfThreeAndHalfSlots = inputObject.NumberOfThreeAndHalfSlots;
            NumberOfHorizonExpansionSlots = inputObject.NumberOfHorizonExpansionSlots;
        }
    }
}
