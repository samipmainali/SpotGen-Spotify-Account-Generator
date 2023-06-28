using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotgen.Display
{
    internal class Misc
    {
        private static int previousCheckeds = 0;
        private static int cpmI = 0;
        private static int[] cpmList = new int[60];

        public static void CalculateCPM()
        {
            for (; ; )
            {
                cpmList[cpmI % 60] = Variables.Checked - previousCheckeds;
                previousCheckeds = Variables.Checked;
                Variables.Cpm = cpmList.Sum();
                cpmI++;
                Thread.Sleep(1000);
            }
        }

    }
}
