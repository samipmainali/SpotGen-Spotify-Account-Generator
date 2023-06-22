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

namespace Spotgen
{
    internal class Threading
    {
        public static List<string> list_0 = new List<string>();
        public static Dictionary<string, Func<string, string, string>> dictionary_0 = new Dictionary<string, Func<string, string, string>>();

        public static void smethod_0()
        {
            Threading.dictionary_0["Gen"] = new Func<string, string, string>(Accountgenerator.Check);
            Threading.list_0 = new List<string>(Threading.dictionary_0.Keys);
        }

        public static void Start()
        {
            
            Config.Read();            
            Task.Factory.StartNew(delegate ()
            {
                Display.Misc.CalculateCPM();
            });
            Class12 @object = new Class12();
            Console.Clear();
            Logo.Print();
            Task.Factory.StartNew(delegate () { LOG.Gen(); });
            ThreadPool.SetMinThreads(int.Parse(Variables.Threads), int.Parse(Variables.Threads));
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = int.Parse(Variables.Threads)
            };
            Parallel.ForEach<string>(Combo.asd, parallelOptions, new Action<string>(@object.method_0));
            Console.Clear();
            Console.Title = $"Spot - Finished | Demon.#5513, pami#7674";
            Logo.Print();
            Thread.Sleep(-1);
        }

    }

    public sealed class Class12
    {


        internal void method_0(string string_0)
        {
            string text = "";
            string text2 = "";
            foreach (string key in Threading.list_0)
            {
                string text3 = Threading.dictionary_0[key](text, text2);
                if (text3.Contains("|"))
                {
                    Save.Hit(text3);
                    Variables.Checked++;
                    Variables.Cpm++;
                    Variables.Generated++;
                    Console.WriteLine("[+] ~ " + text3, Color.Green);
                }
                else if (text3.Contains("Invalid"))
                {
                    Variables.Checked++;
                    Variables.Cpm++;
                    Variables.Invalid++;
                }

                Variables.accounts.Remove(string_0);
            }
        }
    }
}
