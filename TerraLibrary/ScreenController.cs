using System;
using System.Collections.Generic;
using System.IO;
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

        public void LoadScreens(TerrariumSettings terrariumSettings)
        {
            // Scale window size with Terrarium width and height
            Console.SetWindowSize(120, 30);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(120, 30);
            StartScreen();
            GameScreen(terrariumSettings, "");
        }

        // START SCREEN
        public void StartScreen()
        {
            Console.CursorVisible = false;
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

        // MAIN SCREEN
        public void GameScreen(TerrariumSettings terrariumSettings, string statusUpdate)
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

            // Print status
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var wCenter = (Console.WindowWidth - statusUpdate.Length) / 2;
            Console.SetCursorPosition(wCenter, lineCounter + 2);
            Console.WriteLine(statusUpdate);
            Console.ForegroundColor = ConsoleColor.White;

            // Print menu buttons
            int selectedItem = Menu.MultipleChoice(37, 21, true, "START GAME", "LOAD GAME", "SETTINGS", "QUIT");

            // Menu actions
            switch (selectedItem)
            {
                case 0:
                    Console.Clear();
                    LoadingScreen();
                    break;
                case 1:
                    Console.Clear();
                    LoadGameScreen();
                    break;
                case 2:
                    Console.Clear();
                    SettingsScreen(terrariumSettings);
                    break;
                default:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }

        // SETTINGS
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
                    GameScreen(terrariumSettings, "SETTTINGS CHANGED");
                    break;
                case 1:
                    Console.Clear();
                    terrariumSettings.ResetSettings();
                    GameScreen(terrariumSettings, "DEFAULT SETTINGS");
                    break;

            }
        }

        // LOAD GAME
        public void LoadGameScreen()
        {
            string[] filePaths = Directory.GetFiles(@"c:\dir");
            List<string> files = new List<string>();

            for (int i = 0; i < filePaths.Length; ++i)
            {
                string path = filePaths[i];
                files.Add(System.IO.Path.GetFileName(path).ToUpper());
            }
            files.Add("CANCEL");

            // Print menu buttons
            int selectedItem = Menu.ShowFiles(14, 5, true, files);

            // Menu actions
            if (selectedItem == files.Count -1)
            {
                Console.Clear();
                GameScreen(new TerrariumSettings(), "LOAD GAME CANCELLED");
            }
            else
            {
                Console.Clear();
                GameScreen(new TerrariumSettings(), filePaths[selectedItem].ToUpper());
                //GameController.LoadGame(filePaths[selectedItem].ToString());
            }
        }



        // PAUSE GAME SCREEN
        public bool PauseGame(WorldController worldController)
        {
            Console.Clear();
            // Scale window size with Terrarium width and height
            Console.SetWindowSize(120, 30);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(120, 30);
            Console.WriteLine(worldController.Terrarium.Organisms.Count);
            Console.ReadLine();
            return true;
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