using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // Print start instructions
            Console.WriteLine("TERRARIUM");
            Console.WriteLine("---------");
            Console.WriteLine("Press enter to show next day, 'stop' to quit.");

            // Initial day (different from regular next day)
            FirstDay();

            // Wait for input
            string input = Console.ReadLine();
            while (input != "stop" && Terrarium.IsEmptySpaceInTerrarium())
            {
                NextDay();
                input = Console.ReadLine();
            }
            
        }

        private void FirstDay()
        {
            AddHerbivore();
            AddHerbivore();
            AddHerbivore();
            AddHerbivore();
            AddHerbivore();
            AddHerbivore();
            //AddCarnivore();
            AddPlant();
            AddPlant();
            AddPlant();
            AddPlant();
            AddPlant();
            AddPlant();

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
            // Display day
            Console.WriteLine("Day " + Day);
            Console.WriteLine("---------");
            // Display terrarium
            foreach (Organism organism in Terrarium.Organisms)
            {
                Console.WriteLine(organism.DisplayLetter + " - " + organism.Position.ToString());
            }
            Console.WriteLine(Terrarium.ToString());
        }

        private void AddOrganism(char t)
        {
            //Organism newOrganism = typeof();
            //// Check if there is space left in the terrarium
            //if (IsEmptySpaceInTerrarium())
            //{
            //    var randomPosition = GenerateRandomEmptyPosition();
            //    switch (t)
            //    {
            //        case 'P':
            //            Terrarium.Organisms.Add(new Plant(randomPosition, Terrarium));
            //            break;
            //        case 'C':
            //            Terrarium.Organisms.Add(new Carnivore(randomPosition, Terrarium));
            //            break;
            //        case 'H':
            //            Terrarium.Organisms.Add(new Plant(randomPosition, Terrarium));
            //            break;
            //    }
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
        

        private void OrganismActions()
        {
            // List to save organisms to delete later (cannot modify list while looping through)
            List<Organism> organismsToDelete = new List<Organism>();
            List<Organism> organismsToAdd = new List<Organism>();

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
                        Console.WriteLine("eat");
                    }
                    //else if (organismRight is Herbivore)
                    //{
                    //    herbivore.Breed();
                    //    Console.WriteLine("Breed");
                    //}
                }
            }

            // Remove all killed organisms from list
            foreach(Organism organism in organismsToDelete)
            {
                Terrarium.Organisms.Remove(organism);
            }
        }
    }
}
