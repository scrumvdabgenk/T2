using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Terrarium
    {
        //properties
        public ITerrariumItem[,] TerrariumItems { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        //constructor
        public Terrarium(int height, int width)
        {
            Height = height;
            Width = width;
            TerrariumItems = new ITerrariumItem[Width, Height];
        }

        public void SpawnPlants(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                SpawnItemOnRandomEmptyPosition(new Plant());
            }
        }

        public void SpawnHerbivore(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                SpawnItemOnRandomEmptyPosition(new Herbivore());
            }
        }

        public void SpawnCarnivore(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                SpawnItemOnRandomEmptyPosition(new Carnivore());
            }
        }

        private void SpawnItemOnRandomEmptyPosition (ITerrariumItem item)
        {
            // New randomizer
            Random random = new Random();

            int xPos, yPos;
            do
            {
                xPos = random.Next(0, Width);
                yPos = random.Next(0, Height);
            } while (TerrariumItems[xPos, yPos] != null);

            // Place item in array at random generated position
            TerrariumItems[xPos, yPos] = item;
        }

    }
}

