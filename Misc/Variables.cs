using Leaf.xNet;
using Spotgen.Spotify;
using System.Collections.Generic;

namespace Spotgen
{
    internal class Variables
    {
        //INTS
        public static int Hit = 0;
        public static int Free = 0;
        public static int Generated = 0;
        public static int Invalid = 0;
        public static int Error = 0;
        public static int Cpm = 0;
        public static int Total = 0;
        public static int Checked = 0;


        //STRINGS

        public static string Name = "";
        public static string Type = "";
        public static string ElapedTime = "";
        public static string Version = "1.3";
        public static string randomhex32;
        public static string login_token;
        public static string spotify_username;
        public static string myguid;


        //CONFIG SHITS

        public static string Threads = "";
        public static string ProxyType = "";
        public static string DisplayType = "";
        public static string Show_Invalid = "";
        public static string Show_Free = "";
        public static string Show_Twofa = "";
        public static string Enable_RPC = "";
        public static string Enable_Webhook = "";
        public static string Webhook = "";

        //FOR ZOHO MAIL

        public static string zohoMailUsername;
        public static string zohoMailDomain;
        public static string zohoMailImap;
        public static string zohoPassword;
        public static string client_token;
        public static int totalfreeaccount;
        public static string isemailverified;
        public static string ispasswordchanged;

        //FOR SPOTIFY

        public static Protobuf.FirstMessasgeDeserialized deserializedDataFirstResponse;
        public static byte[] serializedDataSecondRequest;
        public static Protobuf.SecondMessasgeDeserialized deserializedDataSecondResponse;
        public static byte[] FirstResponseByte;
        public static byte[] SecondResponseByte;

        //FOR CHECKING OR IDK

        public static List<ProxyClient> ProxyList = new List<ProxyClient>();
        public static List<string> accounts = new List<string>();
        public static List<string> proxies = new List<string>();

    }
}
