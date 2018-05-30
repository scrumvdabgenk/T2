using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class TerrariumSettings
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Plants { get; set; }
        public int Herbivores { get; set; }
        public int Carnivores { get; set; }
        public int Humans { get; set; }

        public TerrariumSettings()
        {
            Height = 20;
            Width = 50;
            Plants = 10;
            Herbivores = 10;
            Carnivores = 10;
            Humans = 10;
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
            do
            {
                Console.SetCursorPosition(14, cursorPosition);
                Console.Write(prop + ": ");
                number = int.Parse(Console.ReadLine());
            } while (number <= 0);
            return number;
        }
    }
}