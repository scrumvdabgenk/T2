using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Vulcano : IDisaster
    {
        public Position Position { get; set; }

        public Vulcano(Position position)
        {
            Position = position;
        }

        public void ActivateAndKillOrganisms(Terrarium terrarium, TimeController timeController)
        {
            List<IOrganism> organismsToDelete = new List<IOrganism>();

            string vulcChar = StringManager.GetExtendedAsciiCodeAsString(176);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;

            int size = 12;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(Position.X + i < terrarium.Width && Position.Y + j < terrarium.Height)
                    {
                        Console.SetCursorPosition(Position.X + i, Position.Y + j);
                        Console.Write(vulcChar);
                    }
                }
                timeController.Step(50);
            }

            foreach (IOrganism organism in terrarium.Organisms)
            {
                if( organism.Position.X > Position.X &&
                    organism.Position.X < Position.X + size &&
                    organism.Position.Y > Position.Y &&
                    organism.Position.Y < Position.Y + size)
                {
                    organismsToDelete.Add(organism);
                }
            }
           

            foreach(IOrganism organism in organismsToDelete)
            {
                terrarium.Organisms.Remove(organism);
            }

            Console.ResetColor();

        }
    }
}
