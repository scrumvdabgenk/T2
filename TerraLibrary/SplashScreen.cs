using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class SplashScreen
    {

        public void PrintDemo(int cursorTop)
        {
            var windowCenter = (Console.WindowWidth - 35) / 2;
            // Create new game controller with Terrarium

            var demoASCII = new String[]
            {
                @"██████╗ ███████╗███╗   ███╗ ██████╗",
                @"██╔══██╗██╔════╝████╗ ████║██╔═══██╗",
                @"██║  ██║█████╗  ██╔████╔██║██║   ██║",
                @"██║  ██║██╔══╝  ██║╚██╔╝██║██║   ██║",
                @"██████╔╝███████╗██║ ╚═╝ ██║╚██████╔╝",
                @"╚═════╝ ╚══════╝╚═╝     ╚═╝ ╚═════╝"
            };
            foreach (var line in demoASCII)
            {
                Console.SetCursorPosition(windowCenter, cursorTop);
                Console.WriteLine(line);
                cursorTop++;
            }
        }

        public void PrintTerra(int cursorTop)
        {
            var terraASCII = new String[]
           {
                @" _______                             _                   ",
                @"|__   __|                           (_)                  ",
                @"   | |  ___  _ __  _ __  __ _  _ __  _  _   _  _ __ ___  ",
                @"   | | / _ \| '__|| '__|/ _` || '__|| || | | || '_ ` _ \ ",
                @"   | ||  __/| |   | |  | (_| || |   | || |_| || | | | | |",
                @"   |_| \___||_|   |_|   \__,_||_|   |_| \__,_||_| |_| |_|"
           };

            var windowCenter = (Console.WindowWidth - terraASCII[1].Length) / 2;
            foreach (var line in terraASCII)
            {
                Console.SetCursorPosition(windowCenter, cursorTop);
                Console.WriteLine(line);
                cursorTop++;
            }
        }

        public void PrintCredits(int cursorTop)
        {
            string credits = "By Dan, Davy, Marc & Jeff";
            var windowCenter = (Console.WindowWidth - credits.Length) / 2;
            Console.SetCursorPosition(windowCenter, cursorTop);
            Console.WriteLine(credits);

            string startGame = "Press ENTER to create a terrarium";
            windowCenter = (Console.WindowWidth - startGame.Length) / 2;
            Console.SetCursorPosition(windowCenter, cursorTop + 2);
            Console.WriteLine(startGame);

        }

        


 




    }
}
