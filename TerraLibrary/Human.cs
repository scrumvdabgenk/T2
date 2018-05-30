using System;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibrary
{[Serializable]
    public class Human:Animal
    {
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(219);
        public static ConsoleColor Color1 = ConsoleColor.DarkGray;
        public static ConsoleColor Color2 = ConsoleColor.Gray;
        public static ConsoleColor Color3 = ConsoleColor.White;
        public static ConsoleColor Color4 = ConsoleColor.Yellow;

        public Human(Position begin, Terrarium Terrarium):base(begin,Terrarium)
        {
            DisplayColor = GetHealthColor(Health);
            DisplayLetter = Letter;
            Health = random.Next(1, 4);
        }
        public Human()
        {
            DisplayColor = GetHealthColor(Health);
            DisplayLetter = Letter;
            Health = random.Next(1, 4);
        }
        public void Fight(IOrganism organism, List<IOrganism> toDelete)
        {
            // Cast to animal to use add health
            Animal animal = (Animal)organism;
            //Console.WriteLine("Carnivore fought with Carnivore");
            if (organism.Health > Health)
            {
                toDelete.Add(this);
                animal.AddHealth(Health);
            }
            else if (organism.Health <= Health)
            {
                toDelete.Add(organism);
                AddHealth(animal.Health);
                Move(2);
            }
            AudioController.PlayFight();
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