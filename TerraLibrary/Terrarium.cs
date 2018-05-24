using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Terrarium
    {
        /* Properties */
        public List<Organism> Organisms { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        /* Constructor */
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
            Organisms = new List<Organism>();
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}

