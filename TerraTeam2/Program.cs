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


            var splashScreen = new SplashScreen();
            splashScreen.PrintTerra(5);
            splashScreen.PrintDemo(14);
            splashScreen.PrintCredits(24);


            Console.ReadLine();
            Console.Clear();









            WorldController worldController = new WorldController(new Terrarium(12,12));
            worldController.Start();
        }
    }
}
