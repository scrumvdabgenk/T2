using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{[Serializable]
    public static class AudioController
    {
        private static Random random = new Random();

        private static IDictionary<string, int> notes = new Dictionary<string, int>()
        {
            { "C4", 261 },
            { "Db4", 277 },
            { "D4", 293 },
            { "Eb4", 311 },
            { "E4", 329 },
            { "F4", 349 },
            { "Gb4", 370 },
            { "G4", 392 },
            { "Ab4", 415 },
            { "A4", 440 },
            { "Bb4", 466 },
            { "B4", 494 },
            { "C5", 524 },
            { "Db5", 554 },
            { "D5", 587 },
            { "Eb5", 622 },
            { "E5", 659 },
            { "F5", 698 },
            { "Gb5", 740 },
            { "G5", 764 },
            { "Ab5", 830 },
            { "A5", 880 },
            { "Bb5", 932 },
            { "B5", 987 },
            { "C6", 1046 },
            { "Db6", 1108 },
            { "D6", 1174 },
        };

        public static void PlayVulcano()
        {
            Console.Beep(notes["G5"], 400);
            Console.Beep(notes["G5"], 400);
            Console.Beep(notes["G5"], 400);

            Console.Beep(notes["Eb5"], 300);
            Console.Beep(notes["Bb5"], 100);
            Console.Beep(notes["G5"], 400);

            Console.Beep(notes["Eb5"], 300);
            Console.Beep(notes["Bb5"], 100);
            Console.Beep(notes["G5"], 400);

            for (int i = 0; i < 4; i++)
            {
                Console.Beep(random.Next(700, 1200), 50);
            }
        }

        public static void PlayEarthquake()
        {
            Console.Beep(notes["Bb5"], 150);
            Console.Beep(notes["C6"], 150);

            Console.Beep(notes["Bb5"], 75);
            Console.Beep(notes["A5"], 75);
            Console.Beep(notes["G5"], 150);

            Console.Beep(notes["Bb5"], 150);
            Console.Beep(notes["C6"], 150);

            Console.Beep(notes["Bb5"], 75);
            Console.Beep(notes["A5"], 75);
            Console.Beep(notes["G5"], 150);

            for (int i = 0; i < 5; i++)
            {
                Console.Beep(random.Next(350, 500), 50);
            }
        }

        public static void PlayEat()
        {
            Console.Beep(500, 50);
        }
        public static void PlayFight()
        {
            Console.Beep(1000, 50);
        }

        public static void PlayBreed()
        {
            Console.Beep(3000, 50);
        }
    }
}
