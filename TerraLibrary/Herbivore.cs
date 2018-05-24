using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Herbivore : Animal
    {
        // Represents the animal type in the console, set in subclass
        public override char DisplayLetter { get { return 'H'; } }

        public override void ItemAction(ITerrariumItem[,] terrariumItems)
        {
            base.ItemAction(terrariumItems);
            // Eat plant
        }
    }
}
