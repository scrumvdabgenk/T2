using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Terrarium
    {
        /* Properties */
        public List<IOrganism> Organisms { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        /* Constructor */
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
            Organisms = new List<IOrganism>();
        }

        /* Methods */

        // Print the terrarium to console using colors
        public void PrintTerrarium()
        {
            // Creates array filled with dots
            string[,] terraArray = CreateEmptyTerrarium();
            // Place organism letters in array
            foreach (IOrganism organism in Organisms)
            {
                terraArray[organism.Position.X, organism.Position.Y] = organism.DisplayLetter;
            }

            // Create new colors
            ConsoleColor brown = ConsoleColor.DarkYellow;

            // Check every terrarium coordinate for a letter
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.ResetColor();
                    //Console.Write(".");
                    if(terraArray[x,y] == Plant.Letter)
                    {
                        Console.ForegroundColor = Plant.Color;
                    }
                    else if (terraArray[x, y] == Herbivore.Letter)
                    {
                        Console.ForegroundColor = Herbivore.Color;
                    }
                    else if (terraArray[x, y] == Carnivore.Letter)
                    {
                        Console.ForegroundColor = Carnivore.Color;
                    } else
                    {
                        Console.ForegroundColor = brown;
                    }
                    // (string format, string)
                    Console.Write("{0, 1}", terraArray[x, y]);
                }
                Console.WriteLine();
                
                
            }
            // Reset colors to default
            Console.ResetColor();

        }

        // Create empty terrarium string filled with dots, for use in other methods
        private string[,] CreateEmptyTerrarium ()
        {
            // Create empty string array
            string[,] terraArray = new string[Width, Height];
            // Used to get Extended Ascii characters
            Encoding cp437 = Encoding.GetEncoding(437);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Fill array with ground tile ascii character (code 176)
                    terraArray[x, y] = StringManager.GetExtendedAsciiCodeAsString(176);
                }
            }
            // Return string filled with empty tiles
            return terraArray;
        }

        // Check if there is any space left in the terrarium
        public bool IsEmptySpaceInTerrarium()
        {
            if (!(Organisms.Count < (Width * Height)))
            {
                Console.WriteLine("Field is full");
            }
            return Organisms.Count < (Width * Height);
        }

    }
}

