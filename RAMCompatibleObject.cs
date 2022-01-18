namespace Prog_Kursovaya_sem3
{
    public abstract class RAMCompatibleObject
    {
        protected string memoryType;
        protected int[] availableFrequencies;

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
                        returnValue += availableFrequencies[i] + ",";
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
    }
}
