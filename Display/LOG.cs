using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotgen.Display
{
    internal class LOG
    {
        public static void Gen()
        {

            while (Variables.Total <= Variables.totalfreeaccount)
            {
                Console.Title = string.Format("Spot - Generating | {0}/{1} | Generated: {2} - Invalid: {3} | Errors: {4} | CPM: {5}", new object[]
                {
                    Variables.Checked,
                    Variables.totalfreeaccount,
                    Variables.Generated,
                    Variables.Invalid,
                    Variables.Error,
                    Variables.Cpm,
                });
            }


        }

    }
}
