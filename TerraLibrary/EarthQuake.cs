using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    public class EarthQuake : IDisaster
    {
        Position IDisaster.Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void IDisaster.ActivateAndKillOrganisms(Terrarium terrarium, TimeController timeController)
        {
            throw new NotImplementedException();
        }
    }
}
