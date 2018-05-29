using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class Position
    {
        private static Random random = new Random();
        /* Properties */
        public int X { get; set; }
        public int Y { get; set; }
        
        /* Constructor */
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }
        public static Position GenerateRandomEmptyPosition(Terrarium terrarium)
        {
            // To check if position is empty
            bool empty;
            // Position container
            Position pos;
            do
            {
                // Reset empty
                empty = true;
                // Generate random position
                pos = new Position(random.Next(0, terrarium.Width), random.Next(0, terrarium.Height));
                // Check if position already exists, if so set fals to empty
                foreach (IOrganism organism in terrarium.Organisms)
                {
                    if (organism.Position.X == pos.X && organism.Position.Y == pos.Y)
                    {
                        empty = false;
                    }
                }
            } while (!empty);

            // Return position
            return pos;
        }
        public override bool Equals(object obj)
        {
            Position temp = (Position)obj;
            return  temp.X==X&&temp.Y==Y;
        }
    }
}
