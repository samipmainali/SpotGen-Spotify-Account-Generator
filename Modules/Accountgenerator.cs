using Leaf.xNet;
using MlkPwgen;
using Spotgen.Spotify;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static Spotgen.Spotify.SignUpProtobuf;
using Random = System.Random;
using Console = Colorful.Console;
using RandomNameGenerator;

namespace Spotgen.Modules
{
    internal class Accountgenerator
    {
        public static void Check()
        {
            Thread.Sleep(300);
            for (; ; )
            {
                if (Variables.Generated >= Variables.totalfreeaccount)
                {   
                    Threading.stop();
                    break;
                }
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
                        Guid guid = Guid.NewGuid();
                        string myguid = guid.ToString();
                        string xclientid = myguid.Replace("-","");
                        string randomhex32 = PasswordGenerator.Generate(32, "0123456789abcdef");
                        var day = "0" + PasswordGenerator.Generate(1, "123456789");
                        var month = "0" + PasswordGenerator.Generate(1, "123456789");
                        var yeartwodigit = PasswordGenerator.Generate(2, "789");
                        var year = ("19" + yeartwodigit);
                        var birthday = year + "-" + month + "-" + day;
                        var genderlist = new List<int> { 1, 2 };
                        Random random = new Random();
                        int index = random.Next(genderlist.Count);
                        int gender = genderlist[index];
                        string username;
                        if (gender == 1)
                        {
                            username = NameGenerator.Generate(Gender.Male).ToLower();
                        }
                        else
                        {
                            username = NameGenerator.Generate(Gender.Female).ToLower();
                        }
                        string accountHolderName = username.Replace(".", "").Replace("-", "").Replace("_", "").Replace(" ","");
                        
                        string email;
                        if(Variables.ismailcatchall == "y")
                        {
                            email = accountHolderName + "@" + Variables.MailDomain;
                        }
                        else
                        {
                            email = Variables.MailUsername + "+" + accountHolderName + "@" + Variables.MailDomain;
                        }
                        string password;
                        if(Variables.CustomPassword.Length >= 8)
                        {
                            password = Variables.CustomPassword;
                        }
                        else
                        {
                            password = PasswordGenerator.Generate(12, "0123456789abcdefghijklmnopqrstuvwxyz");
                        }

                        SignUpRequest signUpRequest = new SignUpRequest
                        {
                            Url = "https://auth-callback.spotify.com/r/ios/music/signup",
                            Tag2 = new SignUpRequest.UserInfo
                            {
                                Username = username,
                                DOB = birthday,
                                Gender = gender,
                                Tag4 = new SignUpRequest.UserInfo.BlankVariant
                                {
                                    Tag1 = new SignUpRequest.UserInfo.BlankVariant.BlankVariantTag1
                                    {
                                        BlankTag1 = 1
                                    },
                                    Tag2 = new SignUpRequest.UserInfo.BlankVariant.BlankVariantTag2
                                    {

                                    },
                                    Tag3 = new SignUpRequest.UserInfo.BlankVariant.BlankVariantTag3
                                    {

                                    }
                                },
                                Tag101 = new SignUpRequest.UserInfo.SignUpCredentials
                                {
                                    Signupemail = email,
                                    Password = password
                                }
                            },
                            Tag3 = new SignUpRequest.DeviceInfo
                            {
                                ClientId = "bff58e9698f40080ec4f9ad97a2f21e0",
                                Os = "iOS-ARM",
                                Appversion = "8.8.54",
                                Stringoffset = 1,
                                RandomHex32 = randomhex32
                            },
                            Tag4 = new SignUpRequest.Client
                            {
                                ClientMobile = "client_mobile"
                            }
                        };

                        byte[] signupSerialized = ProtobufHelper.Serialize(signUpRequest);

                        req.AddHeader("Accept", "application/protobuf");
                        req.AddHeader("Accept-Encoding", "gzip,deflate,br");
                        req.AddHeader("Accept-Language", "en-GB,en;q=0.50");
                        req.AddHeader("App-Platform", "iOS");
                        req.AddHeader("Content_length", signupSerialized.Length.ToString());
                        req.AddHeader("Connection", "Keep-Alive");
                        req.AddHeader("Host", "spclient.wg.spotify.com");
                        req.AddHeader("User-Agent", "Spotify/8.8.54iOS/16.0.2(iPhone10,3)");
                        req.AddHeader("Spotify-App-Version", "8.8.54.544");
                        req.AddHeader("X-Client-Id", "58bd3c95768941ea9eb4350aaa033eb3");
                        req.AddHeader("Client-Token", Variables.client_token);

                        var genrequest = req.Post("https://spclient.wg.spotify.com/signup/public/v2/account/create", signupSerialized,
                            "application/protobuf");
                        var genrequest_byte = genrequest.ToBytes();
                        if (genrequest.StatusCode == HttpStatusCode.OK && genrequest_byte.Length == 94)
                        {
                            string login_token = ProtobufHelper.Deserialize<SignUpResponse>(genrequest_byte).usernameAndLogin.LoginToken;
                            string spotify_username = ProtobufHelper.Deserialize<SignUpResponse>(genrequest_byte).usernameAndLogin.Username;
                            
                            string sender = "no-reply@spotify.com";
                            string receiver = email;
                            
                            if (Variables.Enable_Email_Verify.ToLower() == "y")
                            {
                                AccountEmailVerify emailVerifier = new AccountEmailVerify(sender, receiver);
                                emailVerifier.VerifyEmail();

                                Save.Hit(email + ":" + password);
                                Variables.Checked++;
                                Variables.Cpm++;
                                Variables.Generated++;
                                Console.WriteLine("[+] ~ " + email + ":" + password, Color.Green);
                            }
                        }
                        else
                        {
                            Variables.Error++;
                        }
                    }
                }
                catch(Exception e)
                {
                    Variables.Error++;
                }
            }
        }
        public static void SetUtils(Leaf.xNet.HttpRequest req, bool usessl = true)
        {

            req.SslCertificateValidatorCallback += (RemoteCertificateValidationCallback)((obj, cert, ssl, error) => (cert as X509Certificate2).Verify());
            req.IgnoreProtocolErrors = true;
            req.KeepAlive = true;
            req.AllowAutoRedirect = true;
            req.ConnectTimeout = 10000;
            req.KeepAliveTimeout = 10000;
            req.ReadWriteTimeout = 10000;
        }
    }
}
