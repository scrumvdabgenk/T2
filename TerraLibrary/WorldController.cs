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

        /* Constructor */
        public WorldController(Terrarium terrarium, TimeController timeController)
        {
            Terrarium = terrarium;
            TimeController = timeController;
        }

        /* Methods */
        public void Start()
        {
            // Scale window size with Terrarium width and height
            Console.SetWindowSize(Terrarium.Width, Terrarium.Height+5);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(Terrarium.Width + 1, Terrarium.Height+5);

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
                NextDay();
                TimeController.Step();
            }
        }

        private void FirstDay()
        {
            // Clear the console
            Console.Clear();
            // Print the terrarium to the console using colors
            Terrarium.CreateEmptyTerrarium();

            // Add Organisms to List
            for (int i = 0; i < 10; i++)
            {
                AddCarnivore();
            }
            for (int i = 0; i < 10; i++)
            {
                AddHerbivore();
            }
            for (int i = 0; i < 10; i++)
            {
                AddPlant();
            }

            // Render the animals
            Terrarium.RenderAnimals();

            // Wait for input
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Terrarium.Height + 3);
            Console.Write("Press 'Enter' to start");

            Console.SetCursorPosition(0, Terrarium.Height + 2);
            Console.Write("Day " + TimeController.Day);

            string input = Console.ReadLine();
            Console.SetCursorPosition(0, Terrarium.Height + 3);
            Console.WriteLine("                       ");

        }

        private void NextDay()
        {
            // Go to next day and print in console
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(4, Terrarium.Height + 2);
            Console.Write(++TimeController.Day);

            // Add organisms
            AddPlant();

            // For every organism, perform its actions
            OrganismActions();

            // Print Terrarium to console
            Terrarium.RenderAnimals();
        }

        private void PrintInfoHeader()
        {
            // Display day
            Console.WriteLine();
            Console.WriteLine("\tDay " + TimeController.Day);
            Console.WriteLine();
        }

        private void AddPlant()
        {
            // Check if there is space left in the terrarium
            if (Terrarium.IsEmptySpaceInTerrarium())
            {
                Plant plant = new Plant(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium);
                // Add Plant to list
                Terrarium.Organisms.Add(plant);
                
            }
        }
        private void AddHerbivore()
        {
            // Check if there is space left in the terrarium
            if (Terrarium.IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Herbivore(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
            }
        }
        private void AddCarnivore()
        {
            // Check if there is space left in the terrarium
            if (Terrarium.IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Carnivore(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
            }
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
