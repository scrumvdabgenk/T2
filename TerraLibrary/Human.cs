using System;
using TerraLibrary;
using System.Collections.Generic;

namespace TerraLibrary
{
    public class Human:Animal
    {
        private Random rng= new Random();
        public Human(Position begin, Terrarium Terrarium):base(begin,Terrarium)
        {
            Health = rng.Next(4);            
        }
        public Human()
        {
            Health = rng.Next(4);
        }
        public void Fight(IOrganism organism, List<IOrganism> toDelete)
        {
            //Console.WriteLine("Carnivore fought with Carnivore");
            if (organism.Health > Health)
            {
                toDelete.Add(this);
                ((Animal)organism).AddHealth(Health);
                //Console.WriteLine("Defender won");
            }
            else if (organism.Health <= Health)
            {
                toDelete.Add(organism);
                AddHealth(organism.Health);
                Move(2);
                //Console.WriteLine("Attacker won");
            }
        }

        public override void AddHealth(int amount)
        {
            Health += amount;
        }

        public override ConsoleColor GetHealthColor(int health)
        {
            throw new NotImplementedException();
        }
    }
}