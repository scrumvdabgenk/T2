using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Terrarium
    {

        // private properties
        private List<ITerrariumItem> listTerrariumItemsValue;
        private int heightValue;
        private int widthValue;

        //public properties
        public List<ITerrariumItem> TerrariumItems { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        //constructor
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}

