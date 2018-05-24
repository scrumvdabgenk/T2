using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public abstract class Animal: IAnimalBehaviour, ITerrariumItem
    {
        /* Properties */
        public int Health { get; set; }             // Health for fighting, eating, ...
        public abstract char DisplayLetter { get; }        // Represents the animal type in the console, set in subclass
        /* Constructor */
        public Animal()
        {
            // Initialize with 1 health
            Health = 1;
        }

        /* Methods */
        // Animal action override in subclass
        public virtual void AnimalAction()
        {
            // Check in terrarium list for adjacent items
            // If Adjacent item == true
                // Do action ...
        }
    }
}
