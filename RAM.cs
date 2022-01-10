namespace Prog_Kursovaya_sem3
{
    class RAM
    {
        private string name;
        private string memoryType;
        private int memoryCapacity;
        private int[] availableFrequencies;
        private string timings;

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
                if ((value >= 1) && (value <= 64))
                    memoryCapacity = value;
            }
        }
        public int[] AvailableFrequenciesArray
        {
            get
            {
                int[] returnArray = new int[availableFrequencies.Length];
                for (int i = 0; i < availableFrequencies.Length; i++)
                    returnArray[i] = availableFrequencies[i];
                return (returnArray);
            }
            set
            {
                availableFrequencies = new int[value.Length];
                for (int i = 0; i < value.Length; i++)
                    availableFrequencies[i] = value[i];
            }
        }
        public string AvailableFrequenciesString
        {
            get
            {
                string returnValue = "";
                for (int i = 0; i < availableFrequencies.Length; i++)
                {
                    if (i == availableFrequencies.Length - 1)
                        returnValue += availableFrequencies[i];
                    else
                        returnValue += availableFrequencies[i] + ',';
                }
                return (returnValue);
            }
            set
            {
                if (value.IndexOf(',') == (-1))
                {
                    availableFrequencies = new int[1];
                    availableFrequencies[0] = int.Parse(value);
                }

                else
                {
                    string[] bufStringArray = value.Split(',');
                    availableFrequencies = new int[bufStringArray.Length];
                    for (int i = 0; i < bufStringArray.Length; i++)
                        availableFrequencies[i] = int.Parse(bufStringArray[i]);
                }
            }
        }
        public string Timings
        {
            get
            {
                return (new string(timings.ToCharArray()));
            }
            set
            {
                timings = new string(value.ToCharArray());
            }
        }


        public RAM(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            MemoryCapacity = int.Parse(inputSubStrings[1]);
            MemoryType = inputSubStrings[2];
            AvailableFrequenciesString = inputSubStrings[3];
            Timings = inputSubStrings[4];
        }
    }
}
