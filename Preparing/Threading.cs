using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using Spotgen.Display;
using Spotgen.Modules;
using System.Runtime.InteropServices;

namespace Spotgen
{
    internal class Threading
    {
        public static List<Thread> threads = new List<Thread>();

        public static void Start()
        {
            
            Config.Read();            
            Task.Factory.StartNew(delegate (){Display.Misc.CalculateCPM();});
            Console.Clear();
            Logo.Print();
            Task.Factory.StartNew(delegate () { LOG.Gen(); });
            for (int i = 0; i < int.Parse(Variables.Threads); i++)
            {
                Thread item = new Thread((ThreadStart)Accountgenerator.Check);
                threads.Add(item);
            }
            foreach (var thread in threads)
                thread.Start();
            foreach (var thread in threads)
                thread.Join();



            Console.Clear();
            Console.Title = $"Spot - Finished | Demon.#5513, pami#7674";
            Logo.Print();
            Thread.Sleep(-1);
        }

        public static void stop()
        {
            foreach (var thread in threads)
            {
                thread.Suspend();
            }
        }

    }

}
