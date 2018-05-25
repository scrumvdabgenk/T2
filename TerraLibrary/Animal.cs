using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public abstract class Animal : Organism
    {
        private Random random = new Random();
        /* Constructor */
        public Animal(Position position, Terrarium terrarium)
            : base(position, terrarium)
        {
        }

        /* Methods */
        public void Move()
        {
            Move(random.Next(1, 4));
        }
        public void Move(int direction)
        {
            if (CheckAll())
            {
                switch (direction)
                {

                    case 1: // Move up
                        if (CheckAbove())
                            Move(2); // Move right
                        Position.Y -= 1;
                        break;
                    case 2:// Move right
                        if (CheckRightBool())
                            Move(3); // Move down
                        Position.X += 1;
                        break;
                    case 3: //Move down
                        if (CheckBelow())
                            Move(4); //Move left
                        Position.Y += 1;
                        break;
                    case 4: //Move left
                        if (CheckLeft())
                            Move(1); // Move up
                        Position.X -= 1;
                        break;
                    default:
                        break;
                }
            }
        }

        public Organism CheckRight()
        {
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism.Position == new Position(Position.X + 1, Position.Y))
                {
                    return organism;
                }
            }
            return null;
        }

        private bool CheckRightBool()
        {
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism.Position == new Position(Position.X + 1, Position.Y)&&(Position.X<Terrarium.Width-1))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckBelow()
        {
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism.Position == new Position(Position.X, Position.Y - 1)&&(Position.Y<Terrarium.Height-1))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckLeft()
        {
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism.Position == new Position(Position.X - 1, Position.Y) && (Position.X > 0))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckAbove()
        {
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism.Position == new Position(Position.X, Position.Y - 1) && (Position.Y > 0))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckAll()
        {
            return !CheckAbove() || !CheckRightBool() || !CheckBelow() || !CheckLeft();
        }
        private void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
