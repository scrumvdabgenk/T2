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
            // Splash screen
            var splashScreen = new SplashScreen();
            // Print "Terrarium" at line 5
            splashScreen.PrintTerra(5);
            // Print "Demo" at line 14
            splashScreen.PrintDemo(14);
            // Print credits at line 24
            splashScreen.PrintCredits(24);

            // Press Enter to continue
            Console.ReadLine();
            // Clear console to begin game
            Console.Clear();

            // Create new game (worldcontroller and its terrarium)
            WorldController worldController = new WorldController(
                new Terrarium(64, 48),
                new TimeController(-1000000)
                );
            // Start the game
            worldController.Start();
        }
    }
}
