namespace Prog_Kursovaya_sem3
{
    public class RAM : RAMCompatibleObject
    {
        private string name;
        private int memoryCapacity;
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
        public RAM(RAM inputObject)
        {
            Name = inputObject.Name;
            MemoryCapacity = inputObject.MemoryCapacity;
            MemoryType = inputObject.MemoryType;
            AvailableFrequenciesString = inputObject.AvailableFrequenciesString;
            Timings = inputObject.Timings;
        }
    }
}
