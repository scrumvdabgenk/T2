using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerraLibrary
{
    
    public class SplashScreen
    {
        private static Dictionary<string, String[]> ASCIIART = new Dictionary<string, String[]>()
        {
            { "demo", new string[]
                {
                    @"██████╗ ███████╗███╗   ███╗ ██████╗",
                    @"██╔══██╗██╔════╝████╗ ████║██╔═══██╗",
                    @"██║  ██║█████╗  ██╔████╔██║██║   ██║",
                    @"██║  ██║██╔══╝  ██║╚██╔╝██║██║   ██║",
                    @"██████╔╝███████╗██║ ╚═╝ ██║╚██████╔╝",
                    @"╚═════╝ ╚══════╝╚═╝     ╚═╝ ╚═════╝"
                }
            },
            { "terrarium", new String[]
               {
                    @" _______                             _                   ",
                    @"|__   __|                           (_)                  ",
                    @"   | |  ___  _ __  _ __  __ _  _ __  _  _   _  _ __ ___  ",
                    @"   | | / _ \| '__|| '__|/ _` || '__|| || | | || '_ ` _ \ ",
                    @"   | ||  __/| |   | |  | (_| || |   | || |_| || | | | | |",
                    @"   |_| \___||_|   |_|   \__,_||_|   |_| \__,_||_| |_| |_|"
               }
            },
            { "settings", new String[]
                {
                    @"          _   _   _                 ",
                    @"         | | | | (_)                ",
                    @" ___  ___| |_| |_ _ _ __   __ _ ___ ",
                    @"/ __|/ _ \ __| __| | '_ \ / _` / __|",
                    @"\__ \  __/ |_| |_| | | | | (_| \__ \",
                    @"|___/\___|\__|\__|_|_| |_|\__, |___/",
                    @"                           __/ |    ",
                    @"                          |___/     "
                }
            }
        };

        public void PrintASCIIArt(int cursorTop, string[] asciiArt)
        {
            var windowCenter = (Console.WindowWidth - asciiArt[0].Length) / 2;
            // Create new game controller with Terrarium

            var ASCIIArt = asciiArt;
            foreach (var line in ASCIIArt)
            {
                Console.SetCursorPosition(windowCenter, cursorTop);
                Console.WriteLine(line);
                cursorTop++;
            }
        }

       public void MainScreen()
        {
            PrintASCIIArt(5, ASCIIART["terrarium"]);
            PrintASCIIArt(14, ASCIIART["demo"]);
            PrintCredits(24);
        }

       

        public void PrintCredits(int cursorTop)
        {
            string credits = "By Dan, Davy, Marc & Jeff";
            var windowCenter = (Console.WindowWidth - credits.Length) / 2;
            Console.SetCursorPosition(windowCenter, cursorTop);
            Console.WriteLine(credits);

            string startGame = "Press ENTER to start";
            windowCenter = (Console.WindowWidth - startGame.Length) / 2;
            Console.SetCursorPosition(windowCenter, cursorTop + 2);
            Console.WriteLine(startGame);

        }

        public void LoadingScreen(int cursorTop)
        {
            string loadingStr = "";
            var windowCenter = (Console.WindowWidth - 10) / 2;
            Console.SetCursorPosition(windowCenter, cursorTop - 1);
            Console.WriteLine("LOADING...");
            for (var i = 0; i < 40; i++)
            {
                if (i == 1)
                    loadingStr = StringManager.GetExtendedAsciiCodeAsString(177);
                else
                    loadingStr = loadingStr = StringManager.GetExtendedAsciiCodeAsString(178) + loadingStr;
                windowCenter = (Console.WindowWidth - 40) / 2;
                Console.SetCursorPosition(windowCenter, cursorTop);
                Console.WriteLine(loadingStr);
                Thread.Sleep(40);
            }
            
        }

        


 




    }
}
