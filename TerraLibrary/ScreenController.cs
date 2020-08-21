using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerraLibrary
{
    [Serializable]
    public class ScreenController
    {
        public GameController GameController { get; set; }
        public ScreenController(GameController gameController)
        {
            GameController = gameController;
        }
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
            },
            { "pause", new String[]
                {
                    @" _____                     ",
                    @"|  __ \                    ",
                    @"| |__) |_ _ _   _ ___  ___ ",
                    @"|  ___/ _` | | | / __|/ _ \",
                    @"| |  | (_| | |_| \__ \  __/",
                    @"|_|   \__,_|\__,_|___/\___|"
                }
            },
            { "howto", new String[]
                {
                    @" _    _            _______    ",
                    @"| |  | |          |__   __|   ",
                    @"| |__| | _____      _| | ___  ",
                    @"|  __  |/ _ \ \ /\ / / |/ _ \ ",
                    @"| |  | | (_) \ V  V /| | (_) |",
                    @"|_|  |_|\___/ \_/\_/ |_|\___/ "
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

            Thread beepThread = new Thread(new ThreadStart(song));
            beepThread.IsBackground = true;

                beepThread.Start();

            //playMusic();
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
            beepThread.Abort();
        }

       

        public void song()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);

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
            int selectedItem = Menu.MultipleChoice(42, 21, true, "START GAME", "LOAD GAME", "HOW TO", "SETTINGS", "QUIT");

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
                    HowToScreen(terrariumSettings);
                    break;
                case 3:
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintASCIIArt(2, ASCIIART["settings"]);
            Console.ForegroundColor = ConsoleColor.White;

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
                LoadingScreen();
                GameController.LoadGame(filePaths[selectedItem].ToString());
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
            // Print ASCIIART "Terrarium"
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintASCIIArt(2, ASCIIART["pause"]);
            Console.ForegroundColor = ConsoleColor.White;
            printHowTo(14, 10);
            // Print menu buttons
            int selectedItem = Menu.MultipleChoice(32, 21, true, "SAVE GAME", "CONTINUE", "QUIT");

            // Menu actions
            switch (selectedItem)
            {
                case 0:
                    GameController.SaveGame();
                    return true;
                case 1:
                    return true;
                default:
                    Console.Clear();
                    Environment.Exit(0);
                    return false;
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

        public void HowToScreen(TerrariumSettings terrariumSettings)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintASCIIArt(2, ASCIIART["howto"]);
            Console.ForegroundColor = ConsoleColor.White;
            printHowTo(14, 12);

            int selectedItem = Menu.MultipleChoice(14, 25, true, "BACK");

            // Menu actions
            switch (selectedItem)
            {
                default:
                    Console.Clear();
                    GameScreen(terrariumSettings, "");
                    break;
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


        // Print HowTo
        public void printHowTo(int x, int y)
        {
            var output = new StringBuilder();
            var herbivore = StringManager.GetExtendedAsciiCodeAsString(20);
            var carnivore = StringManager.GetExtendedAsciiCodeAsString(206);
            var human = StringManager.GetExtendedAsciiCodeAsString(219);
            var plant = StringManager.GetExtendedAsciiCodeAsString(157);

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(herbivore  + " ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(herbivore + " ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(herbivore + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(herbivore + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Icon for herbivores with color for health");


            y++;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(carnivore + " ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(carnivore + " ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(carnivore + " ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(carnivore + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Icon for carnivores with color for health");

            y++;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(human + " ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(human + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(human + " ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(human + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Icon for humans with color for health");

            y++;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(plant + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Icon for plants");


            y++;
            y++;
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to spawn a volcano eruptions at a random position");
            
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to create an earthquake at a random position");
            y++;
            Console.SetCursorPosition(x, y);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("ESC");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to pause and save the game");
        }

    }
}