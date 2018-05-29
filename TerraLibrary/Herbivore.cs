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
        public static ConsoleColor Color1 = ConsoleColor.DarkBlue;
        public static ConsoleColor Color2 = ConsoleColor.DarkCyan;
        public static ConsoleColor Color3 = ConsoleColor.Blue;
        public static ConsoleColor Color4 = ConsoleColor.Cyan;

        /* Constructor */
        public Herbivore (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayColor = GetHealthColor(Health);
            DisplayLetter = Letter;
        }
        public void Breed(List<IOrganism> toAdd)
        {
            toAdd.Add(new Herbivore(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
        }

        public override void AddHealth(int amount)
        {
            // Add amount to current health
            Health += amount;

            DisplayColor = GetHealthColor(Health);
        }

        public override ConsoleColor GetHealthColor(int health)
        {
            ConsoleColor color;

            if(health < 3)
            {
                color = Color1;
            }
            else if (health < 6)
            {
                color = Color2;
            }
            else if (health < 10)
            {
                color = Color3;
            }
            else
            {
                color = Color4;
            }

            return color;
        }
    }
}
