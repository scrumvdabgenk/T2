using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Carnivore : Animal
    {

        /* Constructor */
        public Carnivore(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayLetter = 'C';
            Health = 0;
        }
        private void Fight ()
        {
            throw new NotImplementedException();
        }
    }
}
