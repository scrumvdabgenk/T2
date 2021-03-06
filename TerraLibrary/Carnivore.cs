﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{[Serializable]
    public class Carnivore : Animal
    {
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(206);
        public static ConsoleColor Color1 = ConsoleColor.DarkRed;
        public static ConsoleColor Color2 = ConsoleColor.DarkMagenta;
        public static ConsoleColor Color3 = ConsoleColor.Red;
        public static ConsoleColor Color4 = ConsoleColor.Magenta;
        

        /* Constructor */
        public Carnivore(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayColor = GetHealthColor(Health);
            DisplayLetter = Letter;
            Health = random.Next(1, 4);
        }
        public Carnivore()
        {
            DisplayColor = GetHealthColor(Health);
            DisplayLetter = Letter;
            Health = random.Next(1, 4);
        }
        public void Fight(IOrganism organism, List<IOrganism> toDelete)
        {
            // Cast to animal to use add health
            Animal animal = (Animal)organism;
            if(organism is Human)
            {
                if (organism.Health >= Health)
                {
                    toDelete.Add(this);
                    animal.AddHealth(Health);
                }
                else if (organism.Health < Health)
                {
                    toDelete.Add(organism);
                    AddHealth(animal.Health);
                    Move(2);
                }
            }
            else // If other carnivore
            {
                if (organism.Health > Health)
                {
                    toDelete.Add(this);
                    animal.AddHealth(Health);
                }
                else if (organism.Health < Health)
                {
                    toDelete.Add(organism);
                    AddHealth(animal.Health);
                    Move(2);
                }
            }

            AudioController.PlayFight();
            
        }

        public override void AddHealth (int amount)
        {
            // Add amount to current health
            Health += amount;

            DisplayColor = GetHealthColor(Health);
        }

        public override ConsoleColor GetHealthColor (int health)
        {
            ConsoleColor color;

            if (health < 3)
            {
                color = Color1;
            }
            else if (health < 6)
            {
                color = Color2;
            }
            else if (health < 9)
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
