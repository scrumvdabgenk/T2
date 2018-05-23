using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new game controller with Terrarium
            GameController gameController = new GameController(new Terrarium(6,6));
            gameController.Start();
        }
    }
}
