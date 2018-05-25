using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Herbivore : Animal
    {
        /* Constructor */
        public Herbivore (Position position, Terrarium terrarium)
            :base(position, terrarium)
        {
            DisplayLetter = 'H';
            Health = 0;
        }
        public void Breed()
        {
            if (Terrarium.IsEmptySpaceInTerrarium())
            {
                Terrarium.Organisms.Add(new Herbivore(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
            }
            else
            {
                Console.WriteLine("No space to breed");
            }
        }
    }
}
