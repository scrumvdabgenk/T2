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
        }

        public void Stop()
        {

        }

        public void NextDay()
        {

        }
    }
}
