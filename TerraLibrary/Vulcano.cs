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

        public Vulcano()
        {

        }

        public void Activate(Terrarium terrarium, TimeController timeController)
        {

            AudioController.PlayVulcano();

            List<Position> vulcanoPositions = new List<Position>();
            List<IOrganism> organismsToDelete = new List<IOrganism>();

            string vulcChar = StringManager.GetExtendedAsciiCodeAsString(176);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;

            int size = 5;

            for (int i = 0; i < size; i++)
            {
                
                if(Position.X + i < terrarium.Width && Position.Y + i < terrarium.Height)
                {
                    Console.SetCursorPosition(Position.X + i, Position.Y + i);
                    vulcanoPositions.Add(new Position(Position.X + i, Position.Y + i));
                    Console.Write(vulcChar);
                }
                if (Position.X - i >= 0 && Position.Y + i < terrarium.Height)
                {
                    Console.SetCursorPosition(Position.X - i, Position.Y + i);
                    vulcanoPositions.Add(new Position(Position.X - i, Position.Y + i));
                    Console.Write(vulcChar);
                }
                if (Position.X - i >= 0 && Position.Y - i >= 0)
                {
                    Console.SetCursorPosition(Position.X - i, Position.Y - i);
                    vulcanoPositions.Add(new Position(Position.X - i, Position.Y - i));
                    Console.Write(vulcChar);
                }
                if (Position.X + i < terrarium.Width && Position.Y - i >= 0)
                {
                    Console.SetCursorPosition(Position.X + i, Position.Y - i);
                    vulcanoPositions.Add(new Position(Position.X + i, Position.Y - i));
                    Console.Write(vulcChar);
                }

                for(int j = 0; j < size - 3; j++)
                {
                    if (Position.X + i < terrarium.Width && Position.Y + j < terrarium.Height)
                    {
                        Console.SetCursorPosition(Position.X + i, Position.Y + j);
                        vulcanoPositions.Add(new Position(Position.X + i, Position.Y + j));
                        Console.Write(vulcChar);
                    }
                    if (Position.X - j >= 0 && Position.Y + i < terrarium.Height)
                    {
                        Console.SetCursorPosition(Position.X - j, Position.Y + i);
                        vulcanoPositions.Add(new Position(Position.X - j, Position.Y + i));
                        Console.Write(vulcChar);
                    }
                    if (Position.X - i >= 0 && Position.Y - j >= 0)
                    {
                        Console.SetCursorPosition(Position.X - i, Position.Y - j);
                        vulcanoPositions.Add(new Position(Position.X - i, Position.Y - j));
                        Console.Write(vulcChar);
                    }
                    if (Position.X + j < terrarium.Width && Position.Y - i >= 0)
                    {
                        Console.SetCursorPosition(Position.X + j, Position.Y - i);
                        vulcanoPositions.Add(new Position(Position.X + j, Position.Y - i));
                        Console.Write(vulcChar);
                    }
                }
                
                timeController.Step(50);
            }

            foreach (IOrganism organism in terrarium.Organisms)
            {
                foreach(Position pos in vulcanoPositions)
                {
                    if (organism.Position.Equals(pos) && !organismsToDelete.Contains(organism))
                    {
                        organismsToDelete.Add(organism);
                    }
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
