using System;
using System.Collections.Generic;
using TerraLibrary;

namespace TerraLibraryTests
{
    public  class Mens  :Animal
    {
        public Mens(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            
            Health = 0;
        }

        internal void Fight()
        {
            throw new NotImplementedException();
        }

        internal void Fight(Carnivore carnivore, List<Organism> toDelete)
        {
            throw new NotImplementedException();
        }
    }
}