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
                Console.ReadLine();
            }
            
        }

        private void NextDay()
        {
            throw new NotImplementedException();
        }

        private void OrganismActions()
        {
            throw new NotImplementedException();
        }

        private void PrintTerrarium ()
        {
            throw new NotImplementedException();
        }
        private void GenerateRandomEmptyPosition()
        {
            throw new NotImplementedException();
        }
    }
}
