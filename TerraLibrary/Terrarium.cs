using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    [Serializable]
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

        public void RenderAnimals ()
        {
            // Get animals from organisms list
            var animalList = Organisms.Where(o => o is Animal);
            
            foreach (Animal animal in animalList)
            {
                // Set previous position to ground tile
                Console.SetCursorPosition(
                    animal.LastPosition.X, animal.LastPosition.Y
                    );
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(StringManager.GetExtendedAsciiCodeAsString(176));

                // Update current position
                Console.SetCursorPosition(
                    animal.Position.X,
                    animal.Position.Y
                    );
                Console.ForegroundColor = animal.DisplayColor;
                Console.Write(animal.DisplayLetter);
            }
        }

        public void RenderPlant (Plant plant)
        {
            Console.ForegroundColor = Plant.Color;
            Console.SetCursorPosition(plant.Position.X, plant.Position.Y);
            Console.Write(Plant.Letter);
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
            return Organisms.Count < (Width * Height);
        }

    }
}

