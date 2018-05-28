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
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(157);
        /* Constructor */
        public Plant (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            Health = 1;
            DisplayLetter = Letter;
        }
    }
}
