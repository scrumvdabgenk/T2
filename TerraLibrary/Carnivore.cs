using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Carnivore : Animal
    {
        public static string Letter = StringManager.GetExtendedAsciiCodeAsString(206);
        /* Constructor */
        public Carnivore(Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayLetter = Letter;
            Health = 0;
        }
        public void Fight(Organism organism, List<Organism> toDelete)
        {
            //Console.WriteLine("Carnivore fought with Carnivore");
            if(organism.Health > Health)
            {
                toDelete.Add(this);
                organism.Health += Health;
                //Console.WriteLine("Defender won");
            }
            else if (organism.Health < Health)
            {
                toDelete.Add(organism);
                Health += organism.Health;
                Move(2);
                //Console.WriteLine("Attacker won");
            }
            else
            {
                //Console.WriteLine("No one won");
            }
        }
    }
}
