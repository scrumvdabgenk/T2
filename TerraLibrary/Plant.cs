using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    public class Plant : IOrganism
    {
        /* Properties */
        // STATICS
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(157);
        public static ConsoleColor Color = ConsoleColor.Green;

        // Props
        public int Health { get; set; }
        public Position Position { get; set; }
        public Position LastPosition { get; set; }
        public Terrarium Terrarium { get; set; }
        public string DisplayLetter { get; set; }
        public ConsoleColor DisplayColor { get; set; }

        /* Constructor */
        public Plant (Position position, Terrarium terrarium)
        {
            Position = position;
            Terrarium = terrarium;
            DisplayColor = Color;
            DisplayLetter = Letter;
            Health = 1;
            LastPosition = new Position(Position.X, Position.Y);
            // Render plant in terrarium
            Terrarium.RenderPlant(this);
        }
    }
}
