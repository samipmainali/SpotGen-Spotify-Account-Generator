﻿using System;
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

            while (Variables.Generated <= Variables.totalfreeaccount)
            {
                Console.Title = string.Format("Spot - Generating | {0}/{1} | Generated: {2} | Errors: {3} | CPM: {4}", new object[]
                {
                    Variables.Checked,
                    Variables.totalfreeaccount,
                    Variables.Generated,
                    Variables.Error,
                    Variables.Cpm,
                });
            }


        }

    }
}
