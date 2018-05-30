using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    public class EarthQuake : IDisaster
    {
        static Random random = new Random();
        public Position Position { get; set; }

        public EarthQuake()
        {
        }
        public EarthQuake(Position position)
        {
            Position = position;
        }

        public void Activate(Terrarium terrarium, TimeController timeController)
        {
            AudioController.PlayEarthquake();

            List<Position> earthQuakePositions = new List<Position>();
            List<IOrganism> organismsToShuffle = new List<IOrganism>();

            string quakeChar = StringManager.GetExtendedAsciiCodeAsString(176);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            

            int size = 7;

            for (int i = 0; i < size; i++)
            {

                if (Position.X + i < terrarium.Width && Position.Y + i < terrarium.Height)
                {
                    Console.SetCursorPosition(Position.X + i, Position.Y + i);
                    earthQuakePositions.Add(new Position(Position.X + i, Position.Y + i));
                    Console.Write(quakeChar);
                }
                if (Position.X - i >= 0 && Position.Y + i < terrarium.Height)
                {
                    Console.SetCursorPosition(Position.X - i, Position.Y + i);
                    earthQuakePositions.Add(new Position(Position.X - i, Position.Y + i));
                    Console.Write(quakeChar);
                }
                if (Position.X - i >= 0 && Position.Y - i >= 0)
                {
                    Console.SetCursorPosition(Position.X - i, Position.Y - i);
                    earthQuakePositions.Add(new Position(Position.X - i, Position.Y - i));
                    Console.Write(quakeChar);
                }
                if (Position.X + i < terrarium.Width && Position.Y - i >= 0)
                {
                    Console.SetCursorPosition(Position.X + i, Position.Y - i);
                    earthQuakePositions.Add(new Position(Position.X + i, Position.Y - i));
                    Console.Write(quakeChar);
                }

                for (int j = 0; j < size - 2; j++)
                {
                    if (Position.X + i < terrarium.Width && Position.Y + j < terrarium.Height)
                    {
                        Console.SetCursorPosition(Position.X + i, Position.Y + j);
                        earthQuakePositions.Add(new Position(Position.X + i, Position.Y + j));
                        Console.Write(quakeChar);
                    }
                    if (Position.X - j >= 0 && Position.Y + i < terrarium.Height)
                    {
                        Console.SetCursorPosition(Position.X - j, Position.Y + i);
                        earthQuakePositions.Add(new Position(Position.X - j, Position.Y + i));
                        Console.Write(quakeChar);
                    }
                    if (Position.X - i >= 0 && Position.Y - j >= 0)
                    {
                        Console.SetCursorPosition(Position.X - i, Position.Y - j);
                        earthQuakePositions.Add(new Position(Position.X - i, Position.Y - j));
                        Console.Write(quakeChar);
                    }
                    if (Position.X + j < terrarium.Width && Position.Y - i >= 0)
                    {
                        Console.SetCursorPosition(Position.X + j, Position.Y - i);
                        earthQuakePositions.Add(new Position(Position.X + j, Position.Y - i));
                        Console.Write(quakeChar);
                    }
                }

                timeController.Step(50);
            }

            foreach (IOrganism organism in terrarium.Organisms)
            {
                foreach (Position pos in earthQuakePositions)
                {
                    if (organism.Position.Equals(pos) && !organismsToShuffle.Contains(organism))
                    {
                        organismsToShuffle.Add(organism);
                    }
                }
            }


            foreach (IOrganism organism in organismsToShuffle)
            {
                organism.LastPosition.X = organism.Position.X;
                organism.LastPosition.Y = organism.Position.Y;

                Position randomPositionInQuake = earthQuakePositions[random.Next(earthQuakePositions.Count)];
                organism.Position.X = randomPositionInQuake.X;
                organism.Position.Y = randomPositionInQuake.Y;

            }

            Console.ResetColor();

            terrarium.RenderPlants();
            terrarium.RenderAnimals();

            
        }        
    }
}
