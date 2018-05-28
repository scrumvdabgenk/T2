using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    public abstract class Organism
    {
        /* Properties */
        public int Health { get; set; }
        public Position Position { get; set; }
        public Terrarium Terrarium { get; set; }
        public string DisplayLetter { get; set; }
        
        /* Constructor */
        public Organism (Position position, Terrarium terrarium)
        {
            Position = position;
            Terrarium = terrarium;
        }
    }
}
