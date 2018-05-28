using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TerraLibrary
{
    public class TimeController
    {
        public int StepTimeout { get; set; }
        public int Day { get; set; }

        public TimeController(int day = 1)
        {
            Day = day;
            // Timeout for each step in ms
            StepTimeout = 50;
        }

        public void Step ()
        {
            Thread.Sleep(StepTimeout);
        }
    }
}
