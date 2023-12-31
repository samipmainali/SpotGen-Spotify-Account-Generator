﻿using Limilabs.Client.IMAP;
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
                Variables.ProxyType = Config.res["ProxyType"].ToString().ToUpper();
                Variables.totalfreeaccount = (int)(Int64.Parse((Config.res["Total_Account_to_be_generated"].ToString())));
                Variables.MailUsername = Config.res["Mail_Username"].ToString();
                Variables.MailDomain = Config.res["Mail_Domain"].ToString();
                Variables.MailImap = Config.res["Mail_Imap"].ToString();
                Variables.MailEmail = Config.res["Mail_Email"].ToString();
                Variables.MailPassword = Config.res["Mail_Password"].ToString();
                Variables.CustomPassword = Config.res["Custom_Password"].ToString();
                Variables.ismailcatchall = Config.res["Is_Domain_with_catchall"].ToString().ToLower();
                Variables.Enable_Email_Verify = Config.res["Enable_Mail_Verifier"].ToString().ToLower();
                Variables.Show_Error = Config.res["Show_Error"].ToString().ToLower();
                Variables.plusordotaddressing = Config.res["+ or . addressing"].ToString();
                Variables.islocalhost = Config.res["Is_Mail_Server_Localhost"].ToString().ToLower();
                Variables.localhostport = Config.res["Localhost_Port"].ToString();
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
                    "Mail_Username",
                    "xxx"
                },
                {
                    "Mail_Domain",
                    "xxx"
                },
                {
                    "Mail_Imap",
                    "xxx"
                },
                {
                    "Mail_Email",
                    "xxx"
                },
                {
                    "Mail_Password",
                    "xxx"
                },
                {
                    "Custom_Password",
                    "xxx"
                },
                {
                    "Is_Domain_with_catchall",
                    "y or n"
                },
                {
                    "Enable_Mail_Verifier",
                    "y or n"
                },
                {
                    "Show_Error",
                    "y or n"
                },
                {
                    "+ or . addressing",
                    "+ or ."
                },
                {
                    "Is_Mail_Server_Localhost",
                    "y or n"
                },
                {
                    "Localhost_Port",
                    "xxx"
                },
                {
                    "Client_Token",
                    "xxx"
                }

            }.ToString();
        }

    }
}
 