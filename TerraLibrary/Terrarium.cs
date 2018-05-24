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

        public void SpawnTerrariumItems(int amount, Type type)
        {
            for (int i = 0; i < amount; i++)
            {
                // Create instance of type
                var item = Activator.CreateInstance(type);
                // Spawn instance on random position
                SpawnItemOnRandomEmptyPosition((ITerrariumItem)item);
            }
        }

        public void TerrariumItemActions()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Check if this position contains an object (null = empty)
                    if(TerrariumItems[x,y] != null)
                    {
                        // Get the item from the array
                        ITerrariumItem item = TerrariumItems[x, y];
                        Console.WriteLine(item.ToString() + item.posX + item.posY);
                        // If this item has an itembehaviour
                        if (item is IItemBehaviour)
                        {
                            // Cast to itembehaviour to access ItemAction();
                            IItemBehaviour behaviourItem = (IItemBehaviour)item;
                            // Call this item's action
                            behaviourItem.ItemAction(TerrariumItems);
                        }
                    }
                    
                }
            }
        }

        private void SpawnItemOnRandomEmptyPosition (ITerrariumItem item)
        {
            // New randomizer
            Random random = new Random();

            // Generate random position until an empty spot is found
            int xPos, yPos;
            do
            {
                xPos = random.Next(0, Width);
                yPos = random.Next(0, Height);
            } while (TerrariumItems[xPos, yPos] != null);

            // Set properties of the terrarium item
            item.posX = xPos;
            item.posY = yPos;
            item.TerrariumItems = TerrariumItems;

            // Place item in array at random generated position
            TerrariumItems[xPos, yPos] = item;

            //Console.WriteLine("Spawned " + item.DisplayLetter + " at " + item.posX + " " + item.posY);
        }

    }
}

