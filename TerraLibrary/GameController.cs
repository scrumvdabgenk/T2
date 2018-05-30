using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class GameController
    {
        public WorldController WorldController { get; set; }
        public ScreenController ScreenController { get; set; }
        public TerrariumSettings TerrariumSettings { get; set; }

        public GameController()
        {
            TerrariumSettings = new TerrariumSettings();
            ScreenController = new ScreenController();
        }

        public void StartGame()
        {
            ScreenController.LoadGame(TerrariumSettings);
            WorldController = new WorldController(TerrariumSettings);
            WorldController.Start();
        }

        
    }
}
