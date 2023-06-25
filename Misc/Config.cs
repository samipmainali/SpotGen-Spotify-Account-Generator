using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Variables.isemailverified = Config.res["Enable_Mail_Verifier"].ToString();
                Variables.ispasswordchanged = Config.res["Enable_Password_Change"].ToString();
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

    }
}
