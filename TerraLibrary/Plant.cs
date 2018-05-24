using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Plant : ITerrariumItem
    {
        /* Properties */
        public char DisplayLetter { get { return 'P'; } }
        public int posX { get; set; }
        public int posY { get; set; }
        public ITerrariumItem[,] TerrariumItems { get; set; }
    }
}
