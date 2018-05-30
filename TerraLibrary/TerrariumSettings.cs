using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class TerrariumSettings
    {
        private int height;

        public int Height { get; set; }
        public int Width { get; set; }
        public int Plants { get; set; }
        public int Herbivores { get; set; }
        public int Carnivores { get; set; }
        public int Humans { get; set; }
        public Frame DictionaryFrame { get; set; }

        private static Dictionary<string, string> PropErrors { get; set; }

        public TerrariumSettings()
        {
            Height = 20;
            Width = 50;
            Plants = 10;
            Herbivores = 10;
            Carnivores = 10;
            Humans = 10;

            PropErrors = new Dictionary<string, string>()
            {
                { "Height" , "Height must be between 15 and " + (Console.LargestWindowHeight - 5) },
                { "Width" , "Width must be between 15 and " + (Console.LargestWindowWidth -1) },
                { "Plants" , "Plants can be max " + (this.Height* this.Width / 4) },
                { "Herbivores" , "Herbivores can be max " + (this.Height* this.Width / 4) },
                { "Carnivores" , "Carnivores can be max " + (this.Height* this.Width / 4) },
                { "Humans" , "Humans can be max " + (this.Height* this.Width / 4) }
            };
        }

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
                    isNotAcceptableNumber = false;
                }
                else
                {
                    Console.SetCursorPosition(14, cursorPosition + 1);
                    Console.Write(PropErrors[prop]);
                }
            } while (isNotAcceptableNumber);

            string clearLine = "                                           ";
            Console.SetCursorPosition(14, cursorPosition + 1);
            Console.Write(clearLine);

            return number;
        }
    }

    public class Frame
    {
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public Frame(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max;
        }
    }
}