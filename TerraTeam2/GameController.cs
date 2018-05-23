using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class GameController
    {
        // Properties
        public Terrarium Terrarium { get; set; }
        public int Day { get; set; }

        // Constructor
        public GameController(Terrarium terrarium)
        {
            Day = 0;
            Terrarium = terrarium;
        }

        // Methods
        public void WaitForInput()
        {

        }

        public void Start()
        {
            Console.WriteLine("TERRARIUM");
            Console.WriteLine("---------");
            Console.WriteLine("Press enter to show next day, 'stop' to quit.");
            string input = Console.ReadLine();
            while(input != "stop")
            {
                NextDay();
                Console.ReadLine();
            }
            
        }

        public void Stop()
        {

        }

        public void NextDay()
        {
            // Increase day by one
            Day++;
            Console.WriteLine("Day: " + Day);
            Console.WriteLine("---------");
            // Prints out terrarium in console
            PrintTerrarium();
        }
        public void PrintTerrarium ()
        {
            for(int x = 0; x < Terrarium.Height; x++)
            {
                for (int y = 0; y < Terrarium.Width; y++)
                {
                    Console.Write(".");
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}
