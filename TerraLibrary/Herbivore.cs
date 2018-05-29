using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Herbivore : Animal
    {
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(20);
        public static ConsoleColor Color = ConsoleColor.Cyan;
        /* Constructor */
        public Herbivore (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayColor = Color;
            DisplayLetter = Letter;
            Health = 0;
        }
        public void Breed(List<IOrganism> toAdd)
        {
            toAdd.Add(new Herbivore(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
        }
    }
}
