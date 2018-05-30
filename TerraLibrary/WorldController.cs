using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class WorldController
    {
        /* Properties*/
        public Terrarium Terrarium { get; set; }
        public TimeController TimeController { get; set; }
        public TerrariumSettings TerrariumSettings { get; set; }

        /* Constructor */
        public WorldController(Terrarium terrarium,TimeController timecontroller,TerrariumSettings terrariumSettings)
        {
            TerrariumSettings = terrariumSettings;
            Terrarium = terrarium;
            TimeController = timecontroller;
        }
        public WorldController(TerrariumSettings terrariumSettings)
        {
            TerrariumSettings = terrariumSettings;
            Terrarium = new Terrarium(TerrariumSettings.Width, TerrariumSettings.Height);
            TimeController = new TimeController(-1000000, Terrarium);
        }
        

        /* Methods */
        public void Start()
        {
            int width = Terrarium.Width + 1;
            int height = Terrarium.Height + 5;
            // Scale window size with Terrarium width and height
            Console.SetWindowSize(width, height);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(width, height);

            // Initial day (different from regular next day)
            FirstDay();
            TimeController.Step();

            // Game loop (user presses enter to see terrarium)
            GameLoop();

            // Close game
            Terrarium.RenderAnimals();
            Console.SetCursorPosition(0, Terrarium.Height + 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Thanks for playing!");
        }

        private void GameLoop()
        {

            // Go to next day if user input != stop and there is space left in the terrarium
            while (Terrarium.IsEmptySpaceInTerrarium())
            {
                do
                {
                    // As long as there is no input keep looping
                    while (!Console.KeyAvailable)
                    {
                        NextDay();
                        TimeController.Step();
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
                
                // When users presses space spawn a vulcano
                SpawnVulcano();
            }
        }

        private void FirstDay()
        {
            // Clear the console
            Console.Clear();
            // Print the terrarium to the console using colors
            Terrarium.CreateEmptyTerrarium();

            // Add Organisms to List
            for (int i = 0; i < TerrariumSettings.Carnivores; i++)
            {
                addIOrganism(new Carnivore());
            }
            for (int i = 0; i < TerrariumSettings.Herbivores; i++)
            {
                addIOrganism(new Herbivore());
            }
            for (int i = 0; i < TerrariumSettings.Plants; i++)
            {
                addIOrganism(new Plant());
            }
            for (int i = 0; i < TerrariumSettings.Humans; i++)
            {
                addIOrganism(new Human());
            }

            // Render the animals
            Terrarium.RenderAnimals();

            // Update timestep according to n organisms (n / animals)
            // This way turns always last n ms
            TimeController.SetStepTimeout();

            // Wait for input
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Terrarium.Height + 3);
            Console.Write("Press 'Enter' to start");


            string input = Console.ReadLine();
            Console.SetCursorPosition(0, Terrarium.Height + 3);
            Console.WriteLine("                       ");

        }

        private void NextDay()
        {
            ClearLines();
            // Go to next day and print in console
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Terrarium.Height + 2);
            Console.Write(TimeController);
            TimeController.ChangeTimeStep();

            // Add organisms
            addIOrganism(new Plant());

            // For every organism, perform its actions
            OrganismActions();

            // Print Terrarium to console
            Terrarium.RenderAnimals();

            // Update timestep according to n organisms (n / animals)
            // This way turns always last n ms
            TimeController.SetStepTimeout();
        }

        private void SpawnVulcano ()
        {
            Vulcano vulcano = new Vulcano(Position.GenerateRandomEmptyPosition(Terrarium));
            vulcano.Activate(Terrarium, TimeController);
        }

        private void ClearLines()
        {
            Console.SetCursorPosition(0, Terrarium.Height + 2);
            for (var i = 0; i < Terrarium.Width; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, Terrarium.Height + 3);
            for (var i = 0; i < Terrarium.Width; i++)
                Console.Write(" ");
        }

        private void addIOrganism(IOrganism organism)
        {
            organism.Position = Position.GenerateRandomEmptyPosition(this.Terrarium);
            organism.LastPosition = new Position(organism.Position.X, organism.Position.Y);
            organism.Terrarium = this.Terrarium;
            if(organism is Plant)
            {
                Plant plant = (Plant)organism;
                Terrarium.RenderPlant(plant);
            }
            this.Terrarium.Organisms.Add(organism);
        }

        private void OrganismActions()
        {
            // List to save organisms to delete later (cannot modify list while looping through)
            List<IOrganism> organismsToDelete = new List<IOrganism>();
            List<IOrganism> organismsToAdd = new List<IOrganism>();

            // Go through the list of all organisms
            foreach (IOrganism organism in Terrarium.Organisms)
            {
                // Only perform organisms action if it is not going to be deleted
                if(!organismsToDelete.Contains(organism))
                {
                    if (organism is Herbivore)
                    {
                        Herbivore herbivore = organism as Herbivore;
                        IOrganism organismRight = herbivore.CheckRight();
                        if (organismRight == null)
                        {
                            herbivore.Move();
                        }
                        else if (organismRight is Plant)
                        {
                            herbivore.Eat(organismRight, organismsToDelete);
                            //Console.WriteLine("Herbivore ate Plant");
                        }
                        else if (organismRight is Herbivore)
                        {
                            herbivore.Breed(organismsToAdd);
                            // Console.WriteLine("Hebrivore breeds with Herbivore");
                        }
                        // After action re-render terrarium
                        Terrarium.RenderAnimals();
                        // Wait before rendering next step
                        TimeController.Step();
                    }
                    else if (organism is Carnivore)
                    {
                        Carnivore carnivore = organism as Carnivore;
                        IOrganism organismRight = carnivore.CheckRight();
                        if (organismRight == null || organismRight is Plant)
                        {
                            carnivore.Move();
                        }
                        else if (organismRight is Herbivore)
                        {
                            carnivore.Eat(organismRight, organismsToDelete);
                            //Console.WriteLine("Carnivore ate Herbivore");
                        }
                        else if (organismRight is Carnivore)
                        {
                            carnivore.Fight(organismRight, organismsToDelete);
                        }
                        else if (organismRight is Human)
                        {
                            carnivore.Fight(organismRight, organismsToDelete);
                        }
                        // After action re-render terrarium
                        Terrarium.RenderAnimals();
                        // Wait before rendering next step
                        TimeController.Step();
                    }
                    else if (organism is Human)
                    {
                        Human human = organism as Human;
                        IOrganism organismRight = human.CheckRight();
                        if (organismRight == null || organismRight is Plant || organismRight is Herbivore)
                        {
                            human.Move();
                        }
                        else if (organismRight is Carnivore)
                        {
                            human.Fight(organismRight, organismsToDelete);
                        }
                        // After action re-render terrarium
                        Terrarium.RenderAnimals();
                        // Wait before rendering next step
                        TimeController.Step();
                    }
                }
                
            }
            // If there are organisms to delete
            if (organismsToDelete.Count > 0)
            {
                // Remove all killed organisms from list
                foreach (IOrganism organism in organismsToDelete)
                {
                    Terrarium.Organisms.Remove(organism);
                }
            }
            // If there are organisms to add
            if (organismsToAdd.Count > 0)
            {
                // Add organisms to terrarium
                foreach (IOrganism organism in organismsToAdd)
                {
                    if (Terrarium.IsEmptySpaceInTerrarium())
                    {
                        Terrarium.Organisms.Add(organism);
                    }
                }
            }

        }
    }
}
