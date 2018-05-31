using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraTeam2
{

    class Program
    {
        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {
            if (x > Console.WindowWidth) return;
            if (y > Console.WindowHeight) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
        }
        static void Main(string[] args)
        {

            // Scale window size with Terrarium width and height
            Console.SetWindowSize(120, 30);
            // Set buffersize to remove scroll bars from window
            Console.SetBufferSize(120, 30);

            Console.CursorVisible = false;

            Thread.Sleep(5000);

            var arr = new[]
            {

@"                                 _______                             _                                                   ",
@"                                |__   __|                           (_)                                                  ",
@"                                   | |  ___  _ __  _ __  __ _  _ __  _  _   _  _ __ ___                                  ",
@"                                   | | / _ \| '__|| '__|/ _` || '__|| || | | || '_ ` _ \                                 ",
@"                                   | ||  __/| |   | |  | (_| || |   | || |_| || | | | | |                                ",
@"                                   |_| \___||_|   |_|   \__,_||_|   |_| \__,_||_| |_| |_|                                ",
@"                                                                                                                         ",
@"                                                                                                                         ",
@"                                             ██████╗ ███████╗███╗   ███╗ ██████╗                                         ",
@"                                             ██╔══██╗██╔════╝████╗ ████║██╔═══██╗                                        ",
@"                                             ██║  ██║█████╗  ██╔████╔██║██║   ██║                                        ",
@"                                             ██║  ██║██╔══╝  ██║╚██╔╝██║██║   ██║                                        ",
@"                                             ██████╔╝███████╗██║ ╚═╝ ██║╚██████╔╝                                        ",
@"                                             ╚═════╝ ╚══════╝╚═╝     ╚═╝ ╚═════╝                                         ",
@"                                                                                                                         ",
@"                                                                                                                         ",
@"                                                                                                                         ",
@"                                                                                                                         ",
@",---------.   .`````-.      .-------. .-------.        .-''-.     .-'''-.     .-''-.  ,---.   .--.,---------.   .-'''-.  ",
@"\          \ /   ,-.  \     \  _(`)_ \|  _ _   \     .'_ _   \   / _     \  .'_ _   \ |    \  |  |\          \ / _     \ ",
@" `--.  ,---'(___/  |   |    | (_ o._)|| ( ' )  |    / ( ` )   ' (`' )/`--' / ( ` )   '|  ,  \ |  | `--.  ,---'(`' )/`--' ",
@"    |   \         .'  /     |  (_,_) /|(_ o _) /   . (_ o _)  |(_ o _).   . (_ o _)  ||  |\_ \|  |    |   \  (_ o _).    ",
@"    :_ _:     _.-'_.-'      |   '-.-' | (_,_).' __ |  (_,_)___| (_,_). '. |  (_,_)___||  _( )_\  |    :_ _:   (_,_). '.  ",
@"    (_I_)   _/_  .'         |   |     |  |\ \  |  |'  \   .---..---.  \  :'  \   .---.| (_ o _)  |    (_I_)  .---.  \  : ",
@"   (_(=)_) ( ' )(__..--.    |   |     |  | \ `'   / \  `-'    /\    `-'  | \  `-'    /|  (_,_)\  |   (_(=)_) \    `-'  | ",
@"    (_I_) (_{;}_)      |    /   )     |  |  \    /   \       /  \       /   \       / |  |    |  |    (_I_)   \       /  ",
@"    '---'  (_,_)-------     `---'     ''-'   `'-'     `'-..-'    `-...-'     `'-..-'  '--'    '--'    '---'    `-...-'   "



        };

            var maxLength = arr.Aggregate(0, (max, line) => Math.Max(max, line.Length));
            var x = Console.BufferWidth / 2 - maxLength / 2;
            for (int y = -arr.Length; y < Console.WindowHeight + arr.Length; y++)
            {
                ConsoleDraw(arr, x, y);
                Thread.Sleep(50);
            }




            var GameController = new GameController();
            GameController.StartGame();
        }
    }
}