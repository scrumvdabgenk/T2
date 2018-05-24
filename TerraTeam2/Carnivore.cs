using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Carnivore : Animal
    {
        // Represents the animal type in the console, set in subclass
        public override char DisplayLetter { get { return 'C'; } }

        public override void AnimalAction()
        {
            base.AnimalAction();
            // Eat others
        }
    }
}
