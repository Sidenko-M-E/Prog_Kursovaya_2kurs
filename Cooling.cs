using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Kursovaya_sem3
{
    public class Cooling
    {
        private string name;
        private int dissipationPower;
        private int minRotationSpeed;
        private int maxRotationSpeed;
        private double maxNoiseLevel;
        private string recomendedSocketType;
        private string constructionType;
        private int numberOfHeatPipes;
        private int length;
        private int width;
        private int height;
        private string connectorType;

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
        public int DissipationPower
        {
            get
            {
                return dissipationPower;
            }
            set
            {
                if ((value >= 0) && (value <= 500))
                    dissipationPower = value;
            }
        }
        public int MinRotationSpeed
        {
            get
            {
                return minRotationSpeed;
            }
            set
            {
                if ((value >= 0) && (value <= 8000))
                    minRotationSpeed = value;
            }
        }
        public int MaxRotationSpeed
        {
            get
            {
                return maxRotationSpeed;
            }
            set
            {
                if ((value >= 0) && (value <= 8000))
                    maxRotationSpeed = value;
            }
        }
        public double MaxNoiseLevel
        {
            get
            {
                return maxNoiseLevel;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                    maxNoiseLevel = value;
            }
        }
        public string RecomendedSocketType
        {
            get
            {
                return (new string(recomendedSocketType.ToCharArray()));
            }
            set
            {
                recomendedSocketType = new string(value.ToCharArray());
            }
        }
        public string ConstructionType
        {
            get
            {
                return (new string(constructionType.ToCharArray()));
            }
            set
            {
                constructionType = new string(value.ToCharArray());
            }
        }
        public int NumberOfHeatPipes
        {
            get
            {
                return numberOfHeatPipes;
            }
            set
            {
                if ((value >= 0) && (value <= 15))
                    numberOfHeatPipes = value;
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
                if ((value >= 0) && (value <= 300))
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
                if ((value >= 0) && (value <= 300))
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
                if ((value >= 0) && (value <= 300))
                    height = value;
            }
        }
        public string ConnectorType
        {
            get
            {
                return (new string(connectorType.ToCharArray()));
            }
            set
            {
                connectorType = new string(value.ToCharArray());
            }
        }


        public Cooling(string[] inputSubStrings)
        {
            Name = inputSubStrings[0];
            DissipationPower = int.Parse(inputSubStrings[1]);
            MinRotationSpeed = int.Parse(inputSubStrings[2]);
            MaxRotationSpeed = int.Parse(inputSubStrings[3]);
            MaxNoiseLevel = double.Parse(inputSubStrings[4]);
            RecomendedSocketType = inputSubStrings[5];
            ConstructionType = inputSubStrings[6];
            NumberOfHeatPipes = int.Parse(inputSubStrings[7]);
            Length = int.Parse(inputSubStrings[8]);
            Width = int.Parse(inputSubStrings[9]);
            Height = int.Parse(inputSubStrings[10]);
            ConnectorType = inputSubStrings[11];
        }
        public Cooling(Cooling inputObject)
        {
            Name = inputObject.Name;
            DissipationPower = inputObject.DissipationPower;
            MinRotationSpeed = inputObject.MinRotationSpeed;
            MaxRotationSpeed = inputObject.MaxRotationSpeed;
            MaxNoiseLevel = inputObject.MaxNoiseLevel;
            RecomendedSocketType = inputObject.RecomendedSocketType;
            ConstructionType = inputObject.ConstructionType;
            NumberOfHeatPipes = inputObject.NumberOfHeatPipes;
            Length = inputObject.Length;
            Width = inputObject.Width;
            Height = inputObject.Height;
            ConnectorType = inputObject.ConnectorType;
        }
    }
}
