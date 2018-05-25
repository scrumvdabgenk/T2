using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraTeam2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new game controller with Terrarium
            Console.WriteLine(@"
    ██████╗ ███████╗███╗   ███╗ ██████╗ 
    ██╔══██╗██╔════╝████╗ ████║██╔═══██╗
    ██║  ██║█████╗  ██╔████╔██║██║   ██║
    ██║  ██║██╔══╝  ██║╚██╔╝██║██║   ██║
    ██████╔╝███████╗██║ ╚═╝ ██║╚██████╔╝
    ╚═════╝ ╚══════╝╚═╝     ╚═╝ ╚═════╝ 
                                    ");
            Console.WriteLine(@"
  _______                             _                   
 |__   __|                           (_)                  
    | |  ___  _ __  _ __  __ _  _ __  _  _   _  _ __ ___  
    | | / _ \| '__|| '__|/ _` || '__|| || | | || '_ ` _ \ 
    | ||  __/| |   | |  | (_| || |   | || |_| || | | | | |
    |_| \___||_|   |_|   \__,_||_|   |_| \__,_||_| |_| |_|
                                                          
                                                          
");
            Console.WriteLine("By Dan, Davy, Marc & Jeff");
            Console.ReadLine();
            Console.Clear();
            WorldController worldController = new WorldController(new Terrarium(6,6));
            worldController.Start();
        }
    }
}
