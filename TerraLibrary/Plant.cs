using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    public class Plant : Organism
    {
        /* Constructor */
        public Plant (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            Health = 1;
            DisplayLetter = 'P';
        }
    }
}
