using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public abstract class Animal : IOrganism
    {

        /* Properties */
        public int Health { get; set; }
        public Position Position { get; set; }
        public Position LastPosition { get; set; }
        public Terrarium Terrarium { get; set; }
        public string DisplayLetter { get; set; }
        public ConsoleColor DisplayColor { get; set; }

        // Object used to generate random numbers, static to share same random object between all animals
        private static Random random = new Random();

        /* Constructor */
        public Animal(Position position, Terrarium terrarium)
        {
            Position = position;
            Terrarium = terrarium;
            LastPosition = new Position(Position.X, Position.Y);
            Health = random.Next(1, 3);
        }

        /* Methods */
        public void Move()
        {
            if (
                CheckAll())
            {
                int randomGetal = random.Next(1, 5);
                if (!CheckAbove() && randomGetal == 1)
                {
                    Move(1);
                }
                else if (!CheckRightBool() && randomGetal == 2)
                {
                    Move(2);
                }
                else if (!CheckBelow() && randomGetal == 3)
                {
                    Move(3);
                }
                else if (!CheckLeft() && randomGetal == 4)
                {
                    Move(4);
                }
                else Move();
            }
        }
        public void Move(int direction)
        {
            // Save previous position before updating (for rendering the terrarium)
            LastPosition.X = Position.X;
            LastPosition.Y = Position.Y;

            switch (direction)
            {

                case 1: // Move up

                    Position.Y -= 1;

                    break;
                case 2:// Move right

                    Position.X += 1;

                    break;
                case 3: //Move down

                    Position.Y += 1;

                    break;
                case 4: //Move left

                    Position.X -= 1;

                    break;
                default:
                    break;
            }

        }

        public IOrganism CheckRight()
        {
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                if (organism.Position.X == Position.X + 1 && organism.Position.Y == Position.Y)
                {
                    return organism;
                }
            }
            return null;
        }

        private bool CheckRightBool()
        {
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                if (organism.Position.X == Position.X + 1 && organism.Position.Y == Position.Y)
                {
                    return true;
                }
            }
            if (Position.X == Terrarium.Width - 1)
                return true;
            return false;

        }
        private bool CheckBelow()
        {
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                if (organism.Position.X == Position.X && organism.Position.Y == Position.Y + 1)
                {
                    return true;
                }
            }
            if (Position.Y == Terrarium.Height - 1)
                return true;
            return false;
        }
        private bool CheckLeft()
        {
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                if (organism.Position.X == Position.X - 1 && organism.Position.Y == Position.Y)
                {
                    return true;
                }
            }
            if (Position.X == 0)
            {
                return true;
            }
            return false;
        }
        private bool CheckAbove()
        {
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                if (organism.Position.X == Position.X && organism.Position.Y == Position.Y - 1)
                {
                    return true;
                }
            }
            if (Position.Y == 0)
                return true;
            return false;
        }

        private bool CheckAll()
        {
            return !CheckAbove() || !CheckRightBool() || !CheckBelow() || !CheckLeft();
        }
        public void Eat(IOrganism organism,List<IOrganism> toDelete)
        {
            AddHealth(organism.Health);
            toDelete.Add(organism);
            Move(2);
        }
        public abstract void AddHealth(int amount);
        public abstract ConsoleColor GetHealthColor(int health);
    }
}
