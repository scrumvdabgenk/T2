using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Position
    {
        /* Properties */
        public int X { get; set; }
        public int Y { get; set; }
        /* Constructor */
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
