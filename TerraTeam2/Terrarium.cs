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
        private List<TerrariumItems> listTerrariumItemsValue;
        private int lenghtValue;
        private int widthValue;

        //public properties
        public List<TerrariumItems> ListTerrariumItems
        {
            get { return listTerrariumItemsValue; }
            set { listTerrariumItemsValue = value; }
        }

        public int Length
        {
            get { return lenghtValue; }
            set { lenghtValue = value; }
        }

        public int Width
        {
            get { return widthValue; }
            set { widthValue = value; }
        }

        //constructor
        public Terrarium(int length, int width)
        {
            Length = length;
            Width = width;
        }
    }
}

