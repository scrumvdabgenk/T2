using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    [Serializable]
    public class TerrariumSettings
    {
        // Properties
        private Dictionary<string, Tuple<string, int, int>> PropErrors = new Dictionary<string, Tuple<string, int, int>>();
        private int height;
        private int width;
        private int plants;
        private int herbivores;
        private int carnivores;
        private int humans;

        // Getters and Setters for properties
        public int Height
        {
            get { return height; }
            set
            {              
                height = value;

                // Set the PropErrors
                PropErrors["Height"] = new Tuple<string, int, int>("Height must be between 15 and ", 15, Console.LargestWindowHeight - 5);
                ChangeTupples(Width, Height);
            }
        }
        
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                ChangeTupples(Width, Height);

                // Set the PropErrors
                PropErrors["Width"] = new Tuple<string, int, int>("Height must be between 15 and ", 15, Console.LargestWindowWidth - 1);
            }
        }

        public int Plants
        {
            get { return plants; }
            set
            {              
                plants = value;

                // Set PropError
                PropErrors["Plants"] = new Tuple<string, int, int>("Plants can be max ", 0, (Height * Width / 4));
            }
        }

        public int Herbivores
        {
            get { return herbivores; }
            set
            {
                herbivores = value;

                // Set PropError
                PropErrors["Herbivores"] = new Tuple<string, int, int>("Herbivores can be max ", 0, (Height * Width / 4));
            }
        }

        public int Carnivores
        {
            get { return carnivores; }
            set
            {
                carnivores = value;

                // Set PropError
                PropErrors["Carnivores"] = new Tuple<string, int, int>("Carnivores can be max ", 0, (Height * Width / 4));
            }
        }

        public int Humans
        {
            get { return humans; }
            set
            {  
                humans = value;

                // Set PropError
                PropErrors["Humans"] = new Tuple<string, int, int>("Humans can be max ", 0, (Height * Width / 4));
            }
        }

        // Constructor
        public TerrariumSettings()
        {
            Height = 20;
            Width = 50;
            Plants = 10;
            Herbivores = 10;
            Carnivores = 10;
            Humans = 10;      
        }


        // Methods
        public void ResetSettings()
        {
            Height = 20;
            Width = 50;
            Plants = 10;
            Herbivores = 10;
            Carnivores = 10;
            Humans = 10;
        }

        public void ChangeSettings()
        {
            Console.SetCursorPosition(14, 14);
            Console.Write("Terrarium dimensions");
            Height = ReadNumber("Height", 15);
            Width = ReadNumber("Width", 16);
            Console.WriteLine();
            Console.SetCursorPosition(14, 18);
            Console.Write("Amount of organisms at start");
            Plants = ReadNumber("Plants", 19);
            Herbivores = ReadNumber("Herbivores", 20);
            Carnivores = ReadNumber("Carnivores", 21);
            Humans = ReadNumber("Humans", 22);
        }

        private int ReadNumber(string prop, int cursorPosition)
        {
            int number;
            bool isNotAcceptableNumber = true;
           
            do
            {
                Console.SetCursorPosition(14, cursorPosition);
                Console.Write(prop + ": ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number >= PropErrors[prop].Item2 && number <= PropErrors[prop].Item3 )
                        isNotAcceptableNumber = false;
                }
                if (isNotAcceptableNumber)
                {
                    Console.SetCursorPosition(14, cursorPosition + 1);
                    Console.Write(PropErrors[prop].Item1 + PropErrors[prop].Item3);
                }
            } while (isNotAcceptableNumber);

            string clearLine = "                                           ";
            Console.SetCursorPosition(14, cursorPosition + 1);
            Console.Write(clearLine);

            return number;
        }


        // Change the organism tupples when Height or Width are changed
        public void ChangeTupples(int width, int height)
        {
            PropErrors.Remove("Plants");
            PropErrors.Remove("Herbivores");
            PropErrors.Remove("Carnivores");
            PropErrors.Remove("Humans");
            int max = (height * width) / 4;
            PropErrors["Plants"] = new Tuple<string, int, int>("Plants can be max ", 0, max);
            PropErrors["Herbivores"] = new Tuple<string, int, int>("Herbivores can be max ", 0, max);
            PropErrors["Carnivores"] = new Tuple<string, int, int>("Carnivores can be max ", 0, max);
            PropErrors["Humans"] = new Tuple<string, int, int>("Humans can be max ", 0, max);
        }
    }
}