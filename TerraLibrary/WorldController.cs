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
            Day = 0;
            Terrarium = terrarium;
        }

        /* Methods */
        public void Start()
        {
            // Print start instructions
            Console.WriteLine("TERRARIUM");
            Console.WriteLine("---------");
            Console.WriteLine("Press enter to show next day, 'stop' to quit.");

            // Wait for input
            string input = Console.ReadLine();
            while(input != "stop")
            {
                NextDay();
                input = Console.ReadLine();
            }
        }

        private void NextDay()
        {
            // Go to next day
            Day++;

            // Add plant
            AddPlant();

            // Display day
            Console.WriteLine("Day " + Day);
            Console.WriteLine("---------");
            // Display terrarium
            foreach (Organism organism in Terrarium.Organisms)
            {
                Console.WriteLine(organism.Position.ToString());
            }
        }

        private void AddPlant ()
        {
            // Check if there is space left in the terrarium
            if(Terrarium.Organisms.Count < (Terrarium.Width * Terrarium.Height))
            {
                // Add Plant
                Terrarium.Organisms.Add(new Plant(GenerateRandomEmptyPosition(), Terrarium));
            }
              
            
        }

        private void OrganismActions()
        {
            throw new NotImplementedException();
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
