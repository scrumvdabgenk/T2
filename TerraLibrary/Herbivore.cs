using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Herbivore : Animal
    {
        /* Constructor */
        public Herbivore (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayLetter = 'H';
            Health = 0;
        }
        private void Breed()
        {
            throw new NotImplementedException();
        }
    }
}
