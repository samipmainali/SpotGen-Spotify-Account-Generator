using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotgen
{
    internal class Save
    {
        public static object resultLock = new object();
        public static string direc;
        public static string date3 = DateTime.Now.ToString($"dddd, dd MMMM yyyy HH:mm:ss");
        public static string date30 = DateTime.Now.ToString($"yyyy. MMMM dd., dddd - HH.mm.ss");

        public static void Hit(string content)
        {
            if (!Directory.Exists($"Results\\{date30}"))
            {
                Directory.CreateDirectory($"Results\\{date30}");
            }
            lock (resultLock)
                File.AppendAllText($"Results\\{date30}\\" + $"{Variables.Name} Hits.txt", content + Environment.NewLine);
        }
    }
}
