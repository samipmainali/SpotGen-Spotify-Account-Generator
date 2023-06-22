using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;

namespace Spotgen
{
    internal class Logo
    {
        public static void Print()
        {
            List<string> log = new List<string>()
{
    "                                             __             _                   \n",
    "                                            / _\\_ __   ___ | |_ __ _  ___ _ __  \n",
    "                                            \\ \\| '_ \\ / _ \\| __/ _` |/ _ \\ '_ \\ \n",
    "                                            _\\ \\ |_) | (_) | || (_| |  __/ | | |\n",
    "                                            \\__/ .__/ \\___/ \\__\\__, |\\___|_| |_|\n",
    "                                               |_|             |___/            \n"

};
            Console.WriteLine();
            Console.WriteWithGradient(log, Color.LawnGreen, Color.MediumSpringGreen, 6);
            Console.WriteLine("                                              https://github.com/samipmainali/SpotGen-Spotify-Account-Generator", Color.MediumSpringGreen);
            Console.ForegroundColor = Color.White;
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
