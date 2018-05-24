using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Herbivore : Animal
    {
        /* Constructor */
        public Herbivore(Terrarium terrarium)
            :base(terrarium)
        {
            Type = "H";
        }


        public override void AnimalAction()
        {
            base.AnimalAction();
            // Eat plant
        }
    }
}
