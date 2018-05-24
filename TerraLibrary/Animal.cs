using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public abstract class Animal: Organism
    {
        private Random random = new Random();
        /* Constructor */
        public Animal(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
        }

        /* Methods */
        public void Move()
        {
            Move(random.Next(1, 4));
        }
        public void Move(int direction)
        {
            if(!CheckRight())
            {
                switch (direction)
                {
                    case 1:
                        Position.Y -= 1;
                        break;
                    case 2:
                        Position.X += 1;
                        break;
                    case 3:
                        Position.Y += 1;
                        break;
                    case 4:
                        Position.X -= 1;
                        break;
                    default:
                        break;
                }
            }
        }
        private bool CheckRight()
        {
            foreach(Organism organism in Terrarium.Organisms )
            {
                if(organism.Position==new Position(Position.X + 1,Position.Y))
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
                if (organism.Position == new Position(Position.X, Position.Y-1))
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
                if (organism.Position == new Position(Position.X - 1, Position.Y))
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
                if (organism.Position == new Position(Position.X, Position.Y-1))
                {
                    return true;
                }
            }
            return false;
        }
        private void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
