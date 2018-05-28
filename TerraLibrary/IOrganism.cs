using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public interface IOrganism
    {
        /* Properties */
        int Health { get; set; }
        Position Position { get; set; }
        Terrarium Terrarium { get; set; }
        string DisplayLetter { get; set; }
        ConsoleColor DisplayColor { get; set; }
    }
}
