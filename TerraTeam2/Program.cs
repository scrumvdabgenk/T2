using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraTeam2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new game controller with Terrarium
            WorldController worldController = new WorldController(new Terrarium(2,2));
            worldController.Start();
        }
    }
}
