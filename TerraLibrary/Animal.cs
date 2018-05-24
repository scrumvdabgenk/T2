using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public abstract class Animal: IItemBehaviour, ITerrariumItem
    {
        /* Properties */
        public int Health { get; set; }             // Health for fighting, eating, ...
        public abstract char DisplayLetter { get; }        // Represents the animal type in the console, set in subclass
        public int posX { get; set; }
        public int posY { get; set; }
        public ITerrariumItem[,] TerrariumItems { get; set; }

        /* Constructor */
        public Animal()
        {
            // Initialize with 1 health
            Health = 1;
        }

        /* Methods */
        // Animal action override in subclass
        public virtual void ItemAction(ITerrariumItem[,] terrariumItems)
        {
            Move(terrariumItems);
            // Check in terrarium list for adjacent items
            // If Adjacent item == true
                // Do action ...
        }

        private void Move(ITerrariumItem[,] terrariumItems)
        {
            // If posX is within width
            if (posX + 1 < (terrariumItems.GetLength(0)-1))
            {
                Console.WriteLine("Trying to move: " + posX + " " + posY);
                if (terrariumItems[posX + 1, posY] == null)
                {
                    Console.WriteLine("Moving right");
                    terrariumItems[posX + 1, posY] = this;
                    terrariumItems[posX, posY] = null;
                    posX += 1;
                }
                else
                {
                    Console.WriteLine("Can not move");

                }
            }
            
        }
    }
}
