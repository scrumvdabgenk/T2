using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Plant : ITerrariumItem
    {
        /* Properties */
        public string Type { get; set; }            // Letter that representents Plant in the app
        public Terrarium Terrarium { get; set; }    // Terrarium that created this item, for deletion, checking adjacency,...
        public Position Position { get; set; }      // Position within the terrarium (X, Y)

        /* Constructor */
        public Plant (Terrarium terrarium)
        {
            Type = "P";
            // Create reference to terrarium that created this item
            Terrarium = terrarium;
            // Generate random position (int) within terrarium dimensions
            Position = new Position(
                new Random().Next(0, Terrarium.Width),
                new Random().Next(0, Terrarium.Height)
                );
        }
    }
}
