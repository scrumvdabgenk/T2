using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public static class AudioController
    {
        private static Random random = new Random();

        public static void PlayVulcano()
        {
            //Console.Beep(784, 500);
            //Console.Beep(784, 500);
            //Console.Beep(784, 500);

            //Console.Beep(622, 375);
            //Console.Beep(932, 125);
            //Console.Beep(784, 500);

            //Console.Beep(622, 375);
            //Console.Beep(932, 125);
            //Console.Beep(784, 500);

            for (int i = 0; i < 5; i++)
            {
                Console.Beep(random.Next(400, 1000), 50);
            }
        }

        public static void PlayEarthquake()
        {
            //Console.Beep(784, 500);
            //Console.Beep(784, 500);
            //Console.Beep(784, 500);

            //Console.Beep(622, 375);
            //Console.Beep(932, 125);
            //Console.Beep(784, 500);

            //Console.Beep(622, 375);
            //Console.Beep(932, 125);
            //Console.Beep(784, 500);

            for (int i = 0; i < 5; i++)
            {
                Console.Beep(random.Next(350, 600), 50);
            }
        }
    }
}
