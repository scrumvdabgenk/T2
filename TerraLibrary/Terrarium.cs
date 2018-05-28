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
        public Terrarium(int width, int height)
        {
            Height = height;
            Width = width;
            Organisms = new List<IOrganism>();
        }

        /* Methods */

        public void UpdateTerrarium ()
        {
            foreach (IOrganism organism in Organisms)
            {
                
                // Set previous position to ground tile
                Console.SetCursorPosition(
                    organism.LastPosition.X, organism.LastPosition.Y
                    );
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(StringManager.GetExtendedAsciiCodeAsString(176));
                

                // Update current position
                Console.SetCursorPosition(
                    organism.Position.X,
                    organism.Position.Y
                    );
                Console.ForegroundColor = organism.DisplayColor;
                Console.Write(organism.DisplayLetter);

            }
        }

        // Create empty terrarium string filled with ground
        public void CreateEmptyTerrarium ()
        {
            // Create empty string array
            StringBuilder s = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Fill string with ground tile ascii character (code 176)
                    s.Append(StringManager.GetExtendedAsciiCodeAsString(176));
                }
                s.Append('\n');
            }
            // Set color of ground
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Print the terrarium
            Console.WriteLine(s.ToString());
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

