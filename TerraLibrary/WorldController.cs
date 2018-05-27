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

            AddCarnivore();
            AddCarnivore();
            AddCarnivore();

            //AddCarnivore();

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
            Console.Clear();
            // Print instructions
            Console.WriteLine("\n\tTERRARIUM");
            //Console.WriteLine("\t---------");
            Console.WriteLine("\tPress enter to show next day, type 'stop' to quit.");
            Console.WriteLine();

            // Display day
            Console.WriteLine("Day " + Day);
            Console.WriteLine("---------");
            //Console.WriteLine(Terrarium.Organisms.Count());
            //// Display terrarium
            //foreach (Organism organism in Terrarium.Organisms)
            //{
            //    Console.WriteLine(organism.DisplayLetter + " - " + organism.Position.ToString());
            //}
            Console.WriteLine(Terrarium.ToString());
        }

        /*private void AddOrganism(char t)
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
            }*/

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
                        //Console.WriteLine("Herbivore ate Plant");
                    }
                    else if (organismRight is Herbivore)
                    {
                        herbivore.Breed(organismsToAdd);
                        // Console.WriteLine("Hebrivore breeds with Herbivore");
                    }
                    DisplayDay();
                    Thread.Sleep(500);
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
                    //else if (organismRight is Herbivore)
                    //{
                    //    herbivore.Breed();
                    //    Console.WriteLine("Breed");
                    //}
                    // Waits before next move
                    DisplayDay();
                    Thread.Sleep(500);
                }
                
            }
            if (organismsToDelete.Count > 0)
            {
                // Remove all killed organisms from list
                foreach (Organism organism in organismsToDelete)
                {
                    Terrarium.Organisms.Remove(organism);
                }
            }
            if (organismsToAdd.Count > 0)
            {
                // Remove all killed organisms from list
                foreach (Organism organism in organismsToAdd)
                {
                    if (Terrarium.IsEmptySpaceInTerrarium())
                    {
                        Terrarium.Organisms.Add(organism);
                    }
                    else
                    {
                        //Console.WriteLine("No space to breed");
                    }
                }
            }

        }
    }
}
