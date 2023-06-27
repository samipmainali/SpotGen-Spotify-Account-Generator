using Limilabs.Client.IMAP;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Spotgen
{
    internal class Config
    {
        private static string json;
        public static JObject res;
        public static void Start()
        {
            if (File.Exists("Configuration.json"))
            {
                Config.json = File.ReadAllText("Configuration.json");
            }
            else
            {
                Create();
                File.WriteAllText("Configuration.json", Config.res.ToString());
            }

        }

        public static void Read()
        {
            try
            {
                Config.json = File.ReadAllText("Configuration.json");
            }
            catch
            {
                if (File.Exists("Configuration.json"))
                {
                    File.Delete("Configuration.json");
                }
                Config.json = Config.Create();
                File.WriteAllText("Configuration.json", Config.json);
            }
            try
            {
                Config.res = JObject.Parse(Config.json);
                Variables.Threads = Config.res["Threads"].ToString();
                Variables.ProxyType = Config.res["ProxyType"].ToString();
                Variables.totalfreeaccount = (int)(Int64.Parse((Config.res["Total_Account_to_be_generated"].ToString())));
                Variables.zohoMailUsername = Config.res["Zoho_Mail_Username"].ToString();
                Variables.zohoMailDomain = Config.res["Zoho_Mail_Domain"].ToString();
                Variables.zohoMailImap = Config.res["Zoho_Mail_Imap"].ToString();
                Variables.zohoPassword = Config.res["Zoho_Password"].ToString();
                Variables.Enable_Email_Verify = Config.res["Enable_Mail_Verifier"].ToString();
                Variables.Enable_Password_Change = Config.res["Enable_Password_Change"].ToString();
                Variables.client_token = Config.res["Client_Token"].ToString();
            }
            catch
            {
                if (File.Exists("Configuration.json"))
                {
                    File.Delete("Configuration.json");
                }
                Config.json = Config.Create();
                File.WriteAllText("Configuration.json", Config.json);
            }



        }

        public static string Create()
        {
            return new JObject
            {
                {
                    "Threads",
                    "1"
                },
                {
                    "ProxyType",
                    "PROXYLESS"
                },
                {
                    "Total_Account_to_be_generated",
                    "0"
                },
                {
                    "Zoho_Mail_Username",
                    "xxx"
                },
                {
                    "Zoho_Mail_Domain",
                    "xxx"
                },
                {
                    "Zoho_Mail_Imap",
                    "xxx"
                },
                {
                    "Zoho_Password",
                    "xxx"
                },
                {
                    "Enable_Mail_Verifier",
                    "y or n"
                },
                {
                    "Enable_Password_Change",
                    "y or n"
                },
                {
                    "Client_Token",
                    "xxx"
                }

            }.ToString();
        }

        public static void Renew(int threads, string proxytype, int total_account, string username, string domain, string imap, string password, string verifier, string passchange, string client_token)
        {
            File.Delete("Configuration.json");
            Config.json = Config.New(threads, proxytype, total_account, username, domain, imap, password, verifier, passchange, client_token);
            File.WriteAllText("Configuration.json", Config.json);

            try
            {
                Config.res = JObject.Parse(Config.json);
                Variables.Threads = Config.res["Threads"].ToString();
                Variables.ProxyType = Config.res["ProxyType"].ToString();
                Variables.totalfreeaccount = (int)(Int64.Parse((Config.res["Total_Account_to_be_generated"].ToString())));
                Variables.zohoMailUsername = Config.res["Zoho_Mail_Username"].ToString();
                Variables.zohoMailDomain = Config.res["Zoho_Mail_Domain"].ToString();
                Variables.zohoMailImap = Config.res["Zoho_Mail_Imap"].ToString();
                Variables.zohoPassword = Config.res["Zoho_Password"].ToString();
                Variables.Enable_Email_Verify = Config.res["Enable_Mail_Verifier"].ToString();
                Variables.Enable_Password_Change = Config.res["Enable_Password_Change"].ToString();
                Variables.client_token = Config.res["Client_Token"].ToString();
            }
            catch
            {
                if (File.Exists("Configuration.json"))
                {
                    File.Delete("Configuration.json");
                }
                Config.json = Config.New(threads, proxytype, total_account, username, domain, imap, password, verifier, passchange, client_token);
                File.WriteAllText("Configuration.json", Config.json);
            }

        }
        public static string New(int threads, string proxytype, int total_account, string username, string domain, string imap, string password, string verifier, string passchange, string client_token)
        {
            return new JObject
            {
                {
                    "Threads",
                    threads
                },
                {
                    "ProxyType",
                    proxytype
                },
                {
                    "Total_Account_to_be_generated",
                    total_account
                },
                {
                    "Zoho_Mail_Username",
                    username
                },
                {
                    "Zoho_Mail_Domain",
                    domain
                },
                {
                    "Zoho_Mail_Imap",
                    imap
                },
                {
                    "Zoho_Password",
                    password
                },
                {
                    "Enable_Mail_Verifier",
                    verifier
                },
                {
                    "Enable_Password_Change",
                    passchange
                },
                {
                    "Client_Token",
                    client_token
                }

            }.ToString();
        }

    }
}
 