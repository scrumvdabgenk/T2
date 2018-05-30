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
            ScreenController.LoadGame(TerrariumSettings);
            WorldController = new WorldController(TerrariumSettings);
            WorldController.Start();
        }
        public bool SaveGame(string Path)
        {
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
        public void LoadGame(string Path)
        {

            try
            {
                using (var bestand = File.Open(Path, FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    SaveObject load;
                    load = (SaveObject)lezer.Deserialize(bestand);
                    WorldController.Terrarium = load.Terrarium;
                    WorldController.TimeController = load.TimeController;
                    TerrariumSettings = load.TerrariumSettings;
                    WorldController.Start();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            
        }

        
    }
}
