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
            var screenController = new ScreenController();
            var terrariumSettings = new TerrariumSettings();
            screenController.LoadGame(terrariumSettings);

            // Create new game (worldcontroller and its terrarium)
            WorldController worldController = new WorldController(terrariumSettings);
            // Start the game
            worldController.Start();
        }
    }
}
