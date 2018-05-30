﻿using System;
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
            AudioController.PlayVulcano();

            List<Position> earthQuakePositions = new List<Position>();
            List<IOrganism> organismsToShuffle = new List<IOrganism>();

            string quakeChar = StringManager.GetExtendedAsciiCodeAsString(196);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            

            int size = 10;

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

                for (int j = 0; j < size - 3; j++)
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
                
                organism.Position.X = earthQuakePositions[random.Next(earthQuakePositions.Count)].X;
                organism.Position.Y = earthQuakePositions[random.Next(earthQuakePositions.Count)].Y;
            }

            Console.ResetColor();
        }        
    }
}
