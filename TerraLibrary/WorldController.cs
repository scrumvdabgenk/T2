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
            while (input != "stop" && IsEmptySpaceInTerrarium())
            {
                NextDay();
                input = Console.ReadLine();
            }
            
        }

        private void FirstDay()
        {
            AddHerbivore();
            AddCarnivore();
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
            //OrganismActions();

            // Print day console
            DisplayDay();
            
        }

        private void DisplayDay()
        {
            // Display day
            Console.WriteLine("Day " + Day);
            Console.WriteLine("---------");
            // Display terrarium
            //foreach (Organism organism in Terrarium.Organisms)
            //{
            //    Console.WriteLine(organism.Position.ToString());
            //}
            Console.WriteLine(Terrarium.ToString());
        }

        private void AddPlant()
        {
            // Check if there is space left in the terrarium
            if (IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Plant(GenerateRandomEmptyPosition(), Terrarium));
            }
        }

        private void AddHerbivore()
        {
            // Check if there is space left in the terrarium
            if (IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Herbivore(GenerateRandomEmptyPosition(), Terrarium));
            }
        }
        private void AddCarnivore()
        {
            // Check if there is space left in the terrarium
            if (IsEmptySpaceInTerrarium())
            {
                // Add Plant
                Terrarium.Organisms.Add(new Carnivore(GenerateRandomEmptyPosition(), Terrarium));
            }
        }
        private bool IsEmptySpaceInTerrarium ()
        {
            if (!(Terrarium.Organisms.Count < (Terrarium.Width * Terrarium.Height)))
            {
                Console.WriteLine("Field is full, exiting game");
            }
            return Terrarium.Organisms.Count < (Terrarium.Width * Terrarium.Height);
        }

        private void OrganismActions()
        {
            //foreach(Organism organism in Terrarium.Organisms)
            //{
            //    if(organism is Herbivore)
            //    {
            //        Herbivore herbivore = organism as Herbivore;
            //        Organism rightOrganism = herbivore.CheckRight();
            //        if(rightOrganism == null)
            //        {
            //            herbivore.Move();
            //        }
            //        else if (rightOrganism is Plant)
            //        {
            //            herbivore.Eat(rightOrganism);
            //        }
            //        else if (rightOrganism is Herbivore)
            //        {
            //            herbivore.Breed(rightOrganism);
            //        }
            //    }
            //}
        }

        private Position GenerateRandomEmptyPosition()
        {
            // Random number generator
            Random random = new Random();

            // To check if position is empty
            bool empty;
            // Position container
            Position pos;
            do
            {
                // Reset empty
                empty = true;
                // Generate random position
                pos = new Position(random.Next(0, Terrarium.Width), random.Next(0, Terrarium.Height));
                // Check if position already exists, if so set fals to empty
                foreach (Organism organism in Terrarium.Organisms)
                {
                    if (organism.Position.X == pos.X && organism.Position.Y == pos.Y)
                    {
                        empty = false;
                    }
                }
            } while (!empty);

            // Return position
            return pos;
        }
    }
}
