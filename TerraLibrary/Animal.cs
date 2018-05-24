using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public abstract class Animal: Organism
    {
        /* Constructor */
        public Animal(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
        }

        /* Methods */
        private void Move()
        {
            throw new NotImplementedException();
        }
        private void Move(int direction)
        {
            throw new NotImplementedException();
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
        private void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
