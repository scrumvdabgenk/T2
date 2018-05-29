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
        public int Day { get; set; }

        /* Constructor */
        public WorldController(Terrarium terrarium)
        {
            Day = 1;
            Terrarium = terrarium;
        }

        /* Methods */
        public void Start()
        {
            // Scale window size with Terrarium width and height
            Console.SetWindowSize(Terrarium.Width * 4, Terrarium.Height * 3);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(Terrarium.Width * 4, Terrarium.Height * 3);
            // Initial day (different from regular next day)
            FirstDay();

            // Game loop (user presses enter to see terrarium)
            GameLoop();

            // Close game
            Console.WriteLine("Thanks for playing!");
        }

        private void GameLoop()
        {
            // Wait for input
            string input = Console.ReadLine();

            // Go to next day if user input != stop and there is space left in the terrarium
            while (input != "stop" && Terrarium.IsEmptySpaceInTerrarium())
            {
                NextDay();
                // Wait for new user input
                input = Console.ReadLine();
            }
        }

        private void FirstDay()
        {
            // Add Organisms to List
            addOrganism(new Herbivore());
            addOrganism(new Herbivore());
            addOrganism(new Herbivore());
            //AddHerbivore();
            //AddHerbivore();
            //AddHerbivore();

            addOrganism(new Carnivore());
            addOrganism(new Carnivore());
            addOrganism(new Carnivore());
            //AddCarnivore();
            //AddCarnivore();
            //AddCarnivore();

            addOrganism(new Plant());
            addOrganism(new Plant());
            addOrganism(new Plant());
            //AddPlant();
            //AddPlant();
            //AddPlant();

            // Print day in console
            DisplayDay();
        }

        private void NextDay()
        {
            // Go to next day
            Day++;

            // Add organisms
            AddPlant();

            // For every organism, perform its actions
            OrganismActions();

            // Print day console
            DisplayDay();

        }

        private void DisplayDay()
        {
            // Clear the console
            Console.Clear();

            // Prints header with instructions + day info
            PrintInfoHeader();

            // Print the terrarium to the console using colors
            Terrarium.PrintTerrarium();
        }
        private void PrintInfoHeader()
        {
            // Print instructions
            //Console.WriteLine("\n\tTERRARIUM");
            //Console.WriteLine("\tPress enter to show next day, type 'stop' to quit.");
            //Console.WriteLine();

            // Display day
            Console.WriteLine();
            Console.WriteLine("\tDay " + Day);
            Console.WriteLine();
        }

        private void AddPlant()
        {
            // Check if there is space left in the terrarium
            if (Terrarium.IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Plant(Position.GenerateRandomEmptyPosition(Terrarium), Terrarium));
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
        private void addOrganism(Organism organism)
        {
            organism.Terrarium = this.Terrarium;
            organism.Position = Position.GenerateRandomEmptyPosition(this.Terrarium);
            Terrarium.Organisms.Add(organism);
        }
        private void OrganismActions()
        {
            // List to save organisms to delete later (cannot modify list while looping through)
            List<Organism> organismsToDelete = new List<Organism>();
            List<Organism> organismsToAdd = new List<Organism>();

            // Go through the list of all organisms
            foreach (Organism organism in Terrarium.Organisms)
            {
                if (organism is Herbivore)
                {
                    Herbivore herbivore = organism as Herbivore;
                    Organism organismRight = herbivore.CheckRight();
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
                    // After action re-render terrarium and wait x ms before
                    DisplayDay();
                    Thread.Sleep(200);
                }
                else if (organism is Carnivore)
                {
                    Carnivore carnivore = organism as Carnivore;
                    Organism organismRight = carnivore.CheckRight();
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
                    DisplayDay();
                    Thread.Sleep(200);
                }
            }
            // If there are organisms to delete
            if (organismsToDelete.Count > 0)
            {
                // Remove all killed organisms from list
                foreach (Organism organism in organismsToDelete)
                {
                    Terrarium.Organisms.Remove(organism);
                }
            }
            // If there are organisms to add
            if (organismsToAdd.Count > 0)
            {
                // Add organisms to terrarium
                foreach (Organism organism in organismsToAdd)
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
