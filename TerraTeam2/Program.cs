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
            splashScreen.MainScreen();

            // Press Enter to continue
            Console.ReadLine();
            // Clear console to begin game
            Console.Clear();

            // Press Enter to continue
            Console.ReadLine();
            // Clear console to begin game
            Console.Clear();

            splashScreen.LoadingScreen(14);
            Console.Clear();

            // Create new game (worldcontroller and its terrarium)
            WorldController worldController = new WorldController(
                new Terrarium(64, 48),
                new TimeController(-1500000)
                );
            // Start the game
            worldController.Start();
        }
    }
}
