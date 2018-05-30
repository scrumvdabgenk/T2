using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            ScreenController.LoadScreens(TerrariumSettings);
            WorldController = new WorldController(TerrariumSettings);
            WorldController.Start();
        }
        public bool SaveGame()
        {
            string Path = @"c:\dir\testfile.terra";
            SaveObject Save = new SaveObject(WorldController.Terrarium, WorldController.TimeController, TerrariumSettings);
            try
            {
                using(var bestand = File.Open(Path, FileMode.OpenOrCreate))
                {
                    var schrijver = new BinaryFormatter();
                    schrijver.Serialize(bestand, Save);
                }
                return true;
            }
            catch(SerializationException)
            {
                throw new Exception("Fout bij het serializeren");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void LoadGame(string path)
        {
            try
            {
                using (var bestand = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    SaveObject Load = (SaveObject)lezer.Deserialize(bestand);
                    WorldController world = new WorldController(Load.Terrarium, Load.TimeController, Load.TerrariumSettings);
                    WorldController = world;
                    TerrariumSettings = world.TerrariumSettings;
                    WorldController.Start();
                }
            }
            catch
            {
                ScreenController.GameScreen(new TerrariumSettings(), "LOAD FAILED");
            }
            
            
        }

        
    }
}
