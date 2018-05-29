using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public class TimeLine
    {
        public int CurrentTime { get; set; }
        public int TimeStep { get; set; }
        public Dictionary<int, string> EventsDict { get; set; }


        public TimeLine(int startTime)
        {
            EventsDict = new Dictionary<int, string>()
            {
                { -1000000, "Big Bang"},
                { -750000, "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                { -500000, "Phasellus tortor nibh" },
                { -300000, "Laoreet at metus id, fringilla tincidunt ex." },
                { -50000,  "Morbi sollicitudin hendrerit consectetur." },
                { -10000, "Suspendisse pulvinar nunc in sapien interdum, ut eleifend ipsum ultricies." },
                { -2000,  "Cras rutrum diam quis massa feugiat, nec rutrum ante sollicitudin." },
                { 0,  "Ut maximus ligula sit amet enim posuere tristique." },
                { 1000, "Praesent a felis odio. Curabitur pretium massa quis ipsum pharetra" },
                { 1300, "at pulvinar justo mollis." },
                { 1600, "Pellentesque pharetra, eros id luctus posuere" },
                { 1700, "mi felis pellentesque orci, eu tincidunt nunc lacus vel sapien." },
                { 1850, "Vestibulum elementum lobortis elit, vitae hendrerit dui efficitur nec." },
                { 1940, "Cras non laoreet leo. Integer nec venenatis felis, sed cursus erat." },
                { 2016, "Sed quis placerat nulla. Maecenas fringilla dignissim est. " }
            };

            CurrentTime = startTime;
            ChangeTimeStep();
        }

        public void ChangeTimeStep()
        {
            if (CurrentTime > -1000000)
                TimeStep = 50000;
            else if (CurrentTime > -100000)
                TimeStep = 5000;
            else if (CurrentTime > -10000)
                TimeStep = 1000;
            else if (CurrentTime > -1000)
                TimeStep = 500;
            else if (CurrentTime > 0)
                TimeStep = 50;
            else if (CurrentTime > 1000)
                TimeStep = 10;
            else if (CurrentTime > 200)
                TimeStep = 1;
        }


        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(CurrentTime);
            if (CurrentTime < 0)
            {
                output.Append(" BC").AppendLine();
            }
            if (EventsDict.ContainsKey(CurrentTime))
            {
                output.Append(EventsDict[CurrentTime]);
            };
            return output.ToString();
        }

    }

}
