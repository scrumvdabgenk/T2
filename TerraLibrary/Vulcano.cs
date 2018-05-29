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
        private int counter = 5;

        public Vulcano(Position position)
        {
            Position = position;
            Activate();
        }

        public void Activate()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            for(int i = 0; i < counter; i++)
            {
                Console.Write(StringManager.GetExtendedAsciiCodeAsString(176));
            }
            
            Console.ResetColor();
        }
    }
}
