using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;

namespace Spotgen
{
    internal class Prefix
    {
        public static void Print(string pref, string cont)
        {
            Console.Write("     [", Color.White);
            Console.Write(pref, Color.MediumSpringGreen);
            Console.Write("] ", Color.White);
            Console.Write(cont, Color.White);
            Console.ForegroundColor = Color.White;

        }

        public static void White(string pref, string cont)
        {
            Console.Write("     [", Color.White);
            Console.Write(pref, Color.White);
            Console.Write("] ", Color.White);
            Console.Write(cont, Color.White);
            Console.ForegroundColor = Color.White;

        }
    }
}
