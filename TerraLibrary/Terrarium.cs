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
        public List<Organism> Organisms { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        /* Constructor */
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
            Organisms = new List<Organism>();
        }
        public override string ToString()
        {
            // Creates array filled with dots
            string[,] terraArray = CreateEmptyTerrarium();
            // Place organism letters in array
            foreach(Organism organism in Organisms)
            {
                terraArray[organism.Position.X, organism.Position.Y] = organism.DisplayLetter.ToString();
            }
            // Make new string
            StringBuilder s = new StringBuilder();

            // Create new colors
            ConsoleColor red = ConsoleColor.Red;
            ConsoleColor blue = ConsoleColor.Blue;
            ConsoleColor green = ConsoleColor.Green;
            ConsoleColor brown = ConsoleColor.DarkYellow;

            // Check every terrarium coordinate for a letter
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    s.Append(terraArray[x, y]);
                    s.Append('\t');
                }
                s.Append('\n');
            }
            return s.ToString();

        }
        private string[,] CreateEmptyTerrarium ()
        {
            string[,] terraArray = new string[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    terraArray[x, y] = ".";
                }
            }
            return terraArray;
        }

        public bool IsEmptySpaceInTerrarium()
        {
            if (!(Organisms.Count < (Width * Height)))
            {
                Console.WriteLine("Field is full, exiting game");
            }
            return Organisms.Count < (Width * Height);
        }

    }
}

