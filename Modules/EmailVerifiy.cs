using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System.Net.Security;

namespace Spotgen.Modules
{
    internal class AccountEmailVerify
    {
        private string zohomailusername;
        private string zohopassword;
        private string sender;
        private string receiver;

        public AccountEmailVerify(string username, string password, string sender, string receiver)
        {
            zohomailusername = username;
            zohopassword = password;
            this.sender = sender;
            this.receiver = receiver;

        }

        public void VerifyEmail()
        {
            bool connected = false;

            while (!connected)
            {
                try
                {
                    // Connect to the IMAP server
                    using (Imap imap = new Imap())
                    {
                        imap.ConnectSSL(Variables.zohoMailImap);
                        imap.Login(zohomailusername + "@" + Variables.zohoMailDomain, zohopassword);

                        // Specify the folder to search for the verification email
                        string folderName = "Spotify";

                        bool emailFound = false;

                        while (!emailFound)
                        {
                            // Open the specified folder
                            imap.Select(folderName);

                            // Get all message UIDs in the folder
                            List<long> uidList = imap.Search(Flag.All);

                            foreach (long uid in uidList)
                            {
                                IMail email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid));

                                // Check if the email matches the criteria
                                if (IsVerificationEmail(email))
                                {
                                    // Extract the verification link from the email
                                    string verificationLink = ExtractVerificationLink(email);

                                    // Perform verification logic for the email
                                    Performverification(verificationLink);

                                    emailFound = true;
                                    break;
                                }
                            }

                            if (!emailFound)
                            {
                                Thread.Sleep(10000);
                            }
                        }

                        // Close the IMAP connection
                        imap.Close();

                        connected = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to IMAP server: {ex.Message}");
                    Console.WriteLine("Retrying after 5 seconds...");
                    Thread.Sleep(5000);
                }
            }
        }

        private bool IsVerificationEmail(IMail email)
        {

            string fromAddress = email.From.ToString();
            string toAddress = email.To.ToString();

            return fromAddress.Contains(sender) && toAddress.Contains(receiver);
        }


        private string ExtractVerificationLink(IMail email)
        {
            string body = email.Text;

            // Extract the URL substring
            string verificationLink = body.Substring("CONFIRM YOUR ACCOUNT ( ", " )");

            return verificationLink;
        }

        public static string Performverification(string verificationLink)
        {
            for (; ; )
            {
                try
                {
                    using (HttpRequest req = new HttpRequest())
                    {
                        if (Variables.ProxyType == "PROXYLESS")
                        {

                        }
                        else
                        {
                            string[] array00 = Variables.proxies[new Random().Next(Variables.proxies.Count<string>())].Split(new char[]
                                {
                                    ':'
                                });
                            ProxyClient proxyClient = (Variables.ProxyType == "SOCKS5") ? new Socks5ProxyClient(array00[0], int.Parse(array00[1])) : ((Variables.ProxyType == "SOCKS4") ? new Socks4ProxyClient(array00[0], int.Parse(array00[1])) : new HttpProxyClient(array00[0], int.Parse(array00[1])));
                            if (array00.Length == 4)
                            {
                                proxyClient.Username = array00[2];
                                proxyClient.Password = array00[3];
                            }
                            req.Proxy = proxyClient;
                        }

                        SetUtils(req);
                        req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0");
                        req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                        req.AddHeader("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.5,en;q=0.3");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("DNT", "1");
                        req.AddHeader("Connection", "Keep-alive");
                        req.AddHeader("Upgrade-Insecure-Requests", "1");
                        req.AllowAutoRedirect = true;

                        var getHeader = req.Get(verificationLink);

                        string header = getHeader.ToString();
                        if (getHeader.StatusCode == HttpStatusCode.OK)
                        {
                            string token = header.Substring("\"query\":{\"t\":\"", "\"");
                            string payload = "{\"token\":\"" + token + "\"}";
                            string confirmverify = req.Post("https://www.spotify.com/api/email-verify/v1/verify", payload, "application/json").ToString();

                            if (confirmverify.Contains("\"success\":true"))
                            {
                                break;
                            }
                        }



                    }
                }
                catch(Exception ex) 
                {
                    
                    Variables.Error++;
                }
                
                
            }
            return "asd";
        }
        public static void SetUtils(Leaf.xNet.HttpRequest req, bool usessl = true)
        {

            req.IgnoreProtocolErrors = true;
            req.KeepAlive = true;
            req.AllowAutoRedirect = true;
            req.ConnectTimeout = 10000;
            req.KeepAliveTimeout = 10000;
            req.ReadWriteTimeout = 10000;
        }


        
    }
}
