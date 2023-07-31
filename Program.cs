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
                    if (Variables.totalfreeaccount == 0)
                    {
                        Console.Clear();
                        Console.Title = $"Spotgen - Invalid Config! | By: Demon.#5513, pami#7674";
                        Logo.Print();
                        Prefix.Print("*", "Invalid config file detected.\n");
                        Prefix.Print("!", "Please make sure that you configured it properly.\n");
                        Thread.Sleep(4000);
                        Main();
                    }
                    Console.Clear();
                    Console.Title = $"Spotgen - Setup | By: Demon.#5513, pami#7674";
                    Logo.Print();
                    Variables.Name = "Gen";
                    Console.Clear();
                    Logo.Print();
                    Console.Title = $"Spotgen - Setup | By: Demon.#5513, pami#7674";
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
            Prefix.Print("4", "Mail Username: " + Variables.MailUsername + "\n");
            Prefix.Print("5", "Mail Domain: " + Variables.MailDomain + "\n");
            Prefix.Print("6", "Mail Domain: " + Variables.MailImap + "\n");
            Prefix.Print("7", "Mail Email: " + Variables.MailEmail + "\n");
            Prefix.Print("8", "Mail Password: " + Variables.MailPassword + "\n");
            Prefix.Print("9", "Custom Password: " + Variables.CustomPassword + "\n");
            Prefix.Print("10", "Is Mail With Catchall: " + Variables.ismailcatchall + "\n");
            Prefix.Print("11", "Enable Email Verify: " + Variables.Enable_Email_Verify + "\n");
            Prefix.Print("12", "Show Error: " + Variables.Show_Error + "\n");
            Prefix.Print("13", "+ or . Addressing: " + Variables.plusordotaddressing + "\n");
            Prefix.Print("14", "Is Mail Server Localhost: " + Variables.islocalhost + "\n");
            Prefix.Print("15", "Localhost Port: " + Variables.localhostport + "\n");
            Prefix.Print("16", "Client Token: " + Variables.client_token + "\n");
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
