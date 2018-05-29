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
        public void Fight(Organism organism, List<Organism> toDelete)
        {
            //Console.WriteLine("Carnivore fought with Carnivore");
            if (organism.Health > Health)
            {
                toDelete.Add(this);
                organism.Health += Health;
                //Console.WriteLine("Defender won");
            }
            else if (organism.Health <= Health)
            {
                toDelete.Add(organism);
                Health += organism.Health;
                Move(2);
                //Console.WriteLine("Attacker won");
            }
        }
    }
}