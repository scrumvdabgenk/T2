using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TerraLibrary
{
    public class TimeController
    {
        public int Day { get; set; }
        public int TimeStep { get; set; }
        public Dictionary<int, string> EventsDict { get; set; }
        public int StepTimeout { get; set; }


        public TimeController(int startTime)
        {
            EventsDict = new Dictionary<int, string>()
            {
                { -1000000, "Big Bang"},
                { -750000, "Lorem ipsum dolor sit amet" },
                { -500000, "Phasellus tortor nibh" },
                { -300000, "Laoreet at metus id" },
                { -50000,  "Morbi sollicitudin hendrerit consectetur." },
                { -10000, "Suspendisse pulvinar nunc" },
                { -2000,  "Cras rutrum diam quis massa feugiat" },
                { 0,  "Ut maximus ligula sit amet enim posuere tristique." },
                { 1000, "Praesent a felis odior" },
                { 1300, "at pulvinar justo mollis." },
                { 1600, "Pellentesque pharetra, eros id luctus posuere" },
                { 1700, "mi felis pellentesque orci" },
                { 1850, "Vestibulum elementum lobortis elit" },
                { 1940, "Cras non laoreet leo. Integer nec" },
                { 2016, "Sed quis placerat nulla." }
            };

            Day = startTime;
            ChangeTimeStep();
            StepTimeout = 10;
        }

        public void Step()
        {
            Thread.Sleep(StepTimeout);
        }

        public void Step(int ms)
        {
            Thread.Sleep(ms);
        }

        public void ChangeTimeStep()
        {
            if (Day <= -1000000)
                TimeStep = 500000;
            else if (Day < -100000)
                TimeStep = 50000;
            else if (Day < -10000)
                TimeStep = 10000;
            else if (Day < -1000)
                TimeStep = 500;
            else if (Day < 0)
                TimeStep = 50;
            else if (Day < 1000)
                TimeStep = 10;
            else if (Day < 200)
                TimeStep = 1;
            Day += TimeStep;
        }


        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(Math.Abs(Day));
            if (Day < 0)
            {
                output.Append(" BC");
            };
            if (EventsDict.ContainsKey(Day))
            {
                output.AppendLine().Append(EventsDict[Day]);
                StepTimeout = 20;
            }
            else
            {
                StepTimeout = 10;
            };
            return output.ToString();
        }
    }
}
