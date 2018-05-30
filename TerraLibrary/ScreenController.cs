using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerraLibrary
{

    public class ScreenController
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

        public void LoadGame(TerrariumSettings terrariumSettings)
        {
            StartScreen();
            GameScreen(terrariumSettings);
        }

        public void StartScreen()
        {
            // Print ASCIIART "Terrarium"
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintASCIIArt(5, ASCIIART["terrarium"]);
            // Print ASCIIART "Demo"
            Console.ForegroundColor = ConsoleColor.White;
            PrintASCIIArt(14, ASCIIART["demo"]);
            // Print credits
            PrintCredits(24);
            // Press Enter to continue
            Console.ReadLine();
            // Clear console to begin game
            Console.Clear();
        }

        public void GameScreen(TerrariumSettings terrariumSettings)
        {
            // Print ASCIIART "Terrarium"
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintASCIIArt(2, ASCIIART["terrarium"]);

            // Create introtext array
            var intro = new String[]
            {
                "Well, the way they make shows is, they make one show.",
                "That show's called a pilot. Then they show that show to the people who make shows, ",
                "and on the strength of that one show they decide if they're going to make more shows.",
                "Some pilots get picked and become television programs.",
                "Some don't, become nothing. She starred in one of the ones that became nothing."
            };

            // Print introText
            Console.ForegroundColor = ConsoleColor.White;
            var lineCounter = 10;
            foreach (var line in intro)
            {
                var windowCenter = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(windowCenter, lineCounter);
                Console.WriteLine(line);
                lineCounter++;
            }

            // Print menu buttons
            int selectedItem = Menu.MultipleChoice(42, 21, true, "START GAME", "SETTINGS", "QUIT");

            // Menu actions
            switch (selectedItem)
            {
                case 0:
                    Console.Clear();
                    LoadingScreen();
                    break;
                case 1:
                    Console.Clear();
                    SettingsScreen(terrariumSettings);
                    break;
                case 2:
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }

        public void SettingsScreen(TerrariumSettings terrariumSettings)
        {
            // Print ASCIIART "Terrarium"
            PrintASCIIArt(2, ASCIIART["settings"]);

            // Loop through props to change settings
            terrariumSettings.ChangeSettings();

            // Print menu buttons
            int selectedItem = Menu.MultipleChoice(14, 25, true, "SAVE CHANGES", "BACK (without saving)");

            // Menu actions
            switch (selectedItem)
            {
                case 0:
                    Console.Clear();
                    GameScreen(terrariumSettings);
                    break;
                case 1:
                    Console.Clear();
                    terrariumSettings.ResetSettings();
                    GameScreen(terrariumSettings);
                    break;

            }
        }


        // Print ASCIIART from dictionary
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

        // Print gamecredits
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

        // Displays loadingscreen
        public void LoadingScreen()
        {
            string loadingStr = "";
            var windowCenter = (Console.WindowWidth - 10) / 2;
            Console.SetCursorPosition(windowCenter, 12);
            Console.WriteLine("LOADING...");
            for (var i = 0; i < 40; i++)
            {
                Console.CursorVisible = false;
                if (i == 1)
                    loadingStr = StringManager.GetExtendedAsciiCodeAsString(177);
                else
                    loadingStr = loadingStr = StringManager.GetExtendedAsciiCodeAsString(178) + loadingStr;
                windowCenter = (Console.WindowWidth - 40) / 2;
                Console.SetCursorPosition(windowCenter, 14);
                Console.WriteLine(loadingStr);
                Thread.Sleep(40);
            }
            Console.Clear();
        }


    }
}