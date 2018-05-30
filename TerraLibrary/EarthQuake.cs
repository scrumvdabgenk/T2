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
        public Position Position { get; set; }

        public EarthQuake()
        {
        }
        public EarthQuake(Position position)
        {
            Position = position;
        }

        public void Activate(Terrarium terrarium, TimeController timeController)
        {
            throw new NotImplementedException();
        }        
    }
}
