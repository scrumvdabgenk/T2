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
            ScreenController = new ScreenController(this);
        }

        public void StartGame()
        {
            ScreenController.LoadScreens(TerrariumSettings);
            WorldController = new WorldController(TerrariumSettings, ScreenController);
            WorldController.Start();
        }
        public bool SaveGame()
        {
            string Path = @"c:\dir\testfile.terra";
            SaveObject Save = new SaveObject(WorldController.Terrarium, WorldController.TimeController, TerrariumSettings);
            try
            {
                using (StreamWriter file = new StreamWriter(Path))
                {
                    file.WriteLine(WorldController.Terrarium.Height);
                    file.WriteLine(WorldController.Terrarium.Width);
                    file.WriteLine(WorldController.Terrarium.Organisms.Count);
                    foreach (var Organism in WorldController.Terrarium.Organisms)
                    {
                        file.WriteLine(Organism.Position + " " + Organism.GetType().ToString());
                           
                    }
                    file.WriteLine(WorldController.TimeController.Day);
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
            int height;
            int width;

            List<IOrganism> organisms = new List<IOrganism>();
            int day;

            Terrarium terrarium;
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    height = int.Parse(file.ReadLine());
                    width = int.Parse(file.ReadLine());
                    var counter = int.Parse(file.ReadLine());
                    for (var i = 0; i < counter; i++)
                    {
                        var line = file.ReadLine().Split(' ');
                        var xPos = int.Parse(line[1]);
                        var yPos = int.Parse(line[3]);
                        var type = line[5];

                        if (line[5] == "TerraLibrary.Carnivore")
                        {
                            var organism = new Carnivore();
                            organism.Position.X = xPos;
                            organism.Position.Y = yPos;
                            organisms.Add(organism);
                        }
                        else if (line[5] == "TerraLibrary.Herbivore")
                        {
                            var organism = new Herbivore();
                            organism.Position.X = xPos;
                            organism.Position.Y = yPos;
                            organisms.Add(organism);
                        }
                        else if (line[5] == "TerraLibrary.Plant")
                        {
                            var organism = new Plant();
                            organism.Position.X = xPos;
                            organism.Position.Y = yPos;
                            organisms.Add(organism);
                        }
                        else if(line[5] == "TerraLibrary.Human")
                        {
                            var organism = new Human();
                            organism.Position.X = xPos;
                            organism.Position.Y = yPos;
                            organisms.Add(organism);
                        }
                    }
                    day = int.Parse(file.ReadLine());

                }
                terrarium = new Terrarium(width, height);
                terrarium.Organisms = organisms;
                var WorldController = new WorldController(terrarium, new TimeController(day, terrarium));
                WorldController.LoadGame();
            }
            catch (Exception ex)
            {
                ScreenController.GameScreen(new TerrariumSettings(), ex.Message);
            }
            
            
        }

        
    }
}
