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
        public Terrarium Terrarium { get; set; }    // Terrarium that created this item, for deletion, checking adjacency,...
        public Position Position { get; set; }      // Position within the terrarium (X, Y)

        /* Constructor */
        public Animal(Terrarium terrarium)
        {
            // Initialize with 1 health
            Health = 1;
            // Create reference to terrarium that created this item
            Terrarium = terrarium;
            // Generate random position (int) within terrarium dimensions
            Position = new Position(
                new Random().Next(0, Terrarium.Width),
                new Random().Next(0, Terrarium.Height)
                );
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
