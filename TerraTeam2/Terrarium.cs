using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Terrarium
    {
        //properties
        public List<ITerrariumItem> TerrariumItems { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        //constructor
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
            TerrariumItems = new List<ITerrariumItem>();
        }

        public void SpawnPlants(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                TerrariumItems.Add(new Plant(this));
            }
        }
    }
}

