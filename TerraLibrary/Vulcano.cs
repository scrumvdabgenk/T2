using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Vulcano : IDisaster
    {
        public Position Position { get; set; }

        public Vulcano(Position position)
        {
            Position = position;
            Activate();
        }

        public void Activate()
        {
            string vulcChar = StringManager.GetExtendedAsciiCodeAsString(176);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;


            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(vulcChar + vulcChar + vulcChar + vulcChar);
            Console.SetCursorPosition(Position.X, Position.Y+1);
            Console.Write(vulcChar + vulcChar + vulcChar + vulcChar + vulcChar + vulcChar);
            Console.SetCursorPosition(Position.X, Position.Y + 2);
            Console.Write(vulcChar + vulcChar + vulcChar + vulcChar + vulcChar);
            Console.SetCursorPosition(Position.X, Position.Y + 3);
            Console.Write(vulcChar + vulcChar + vulcChar + vulcChar);

            Console.ResetColor();
        }
    }
}
