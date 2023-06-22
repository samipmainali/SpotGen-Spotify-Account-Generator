using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Spotgen
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Config.Read();
            Console.Clear();
            Console.Title = "Spotgen - Menu | By: Demon.#5513, pami#7674";
            Logo.Print();
            Prefix.Print("1", "Start\n");
            Prefix.Print("2", "Settings\n");
            Prefix.Print("3", "About\n");
            Prefix.Print("4", "Exit\n\n");
            Prefix.Print(">", "");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Config.Read();
                    Console.Clear();
                    Console.Title = $"Spot - Setup | By: Demon.#5513, pami#7674";
                    Logo.Print();
                    Variables.Name = "Gen";
                    Threading.smethod_0();
                    Threading.list_0.Clear();
                    Threading.list_0.Add("Gen");
                    Console.Clear();
                    Logo.Print();
                    Console.Title = $"Spotgen - | Demon.#5513, pami#7674";
                    Combo.EmptyLoad();
                    if (Variables.ProxyType == "PROXYLESS")
                    {

                    }
                    else
                    {
                        Thread.Sleep(200);
                        Console.Clear();
                        Logo.Print();
                        Prefix.Print("2", "Load your Proxy List: ");
                        Variables.proxies = Proxy.Load().ToList<string>();
                        Thread.Sleep(200);
                    }

                    Console.Clear();
                    Logo.Print();
                    Prefix.Print("+", "Starting Threading System...");
                    Thread.Sleep(300);
                    Threading.Start();
                    break;
                case '2':
                    Settings();
                    break;
                case '3':
                    About();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    Main();
                    break;
            }
            
        }

        static void Settings()
        {
            Config.Read();
            Console.Clear();
            Console.Title = "Spotgen - Settings | By: Demon.#5513, pami#7674";
            Logo.Print();
            Prefix.Print("1", "Threads: " + Variables.Threads + "\n");
            Prefix.Print("2", "Proxy Type: " + Variables.ProxyType + "\n");
            Prefix.Print("3", "Total Account to be generated: " + Variables.totalfreeaccount + "\n");
            Prefix.Print("4", "Zoho Mail Username: " + Variables.zohoMailUsername + "\n");
            Prefix.Print("5", "Zoho Mail Domain: " + Variables.zohoMailDomain + "\n");
            Prefix.Print("6", "Zoho Mail Domain: " + Variables.zohoMailImap + "\n");
            Prefix.Print("7", "Zoho Password: " + Variables.zohoPassword + "\n");
            Prefix.Print("8", "Client Token: " + Variables.client_token + "\n");
            Prefix.Print("!", "Edit config.json!\n");
            Prefix.Print("B", "Back\n\n");
            Prefix.Print(">", "");
            switch (Console.ReadKey(true).KeyChar)
            {                
                case 'b':
                    Main();
                    break;
                default:
                    Settings();
                    break;
            }

        }

        static void About()
        {
            Console.Clear();
            Console.Title = "Spotgen - Menu | By: Demon.#5513, pami#7674";
            Logo.Print();
            Prefix.Print("1", "This tool is meant to be opensource, free and avaible for anyone\n");
            Prefix.Print("2", "Visit this tool's github page: https://github.com/samipmainali/SpotGen-Spotify-Account-Generator\n");
            Prefix.Print("3", "Main dev: Demon.\n");
            Prefix.Print("B", "Back\n\n");
            Prefix.Print(">", "");
            switch (Console.ReadKey(true).KeyChar)
            {               
                case 'b':
                    Main();
                    break;
                default:
                    About();
                    break;
            }

        }
    }
}
