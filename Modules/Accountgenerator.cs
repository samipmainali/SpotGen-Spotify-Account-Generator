
using Google.Protobuf;
using Leaf.xNet;
using MlkPwgen;
using ProtoBuf;
using Spotgen.Spotify;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static Spotgen.Spotify.AuthTokenProtobuf;
using static Spotgen.Spotify.SignUpProtobuf;
using Random = System.Random;

namespace Spotgen.Modules
{
    internal class Accountgenerator
    {
        public static string Check(string array0, string array1)
        {
            Thread.Sleep(300);
            


            string result = "";
            for (; ; )
            {
                if (Variables.Generated >= Variables.totalfreeaccount)
                {
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
                        Variables.myguid = guid.ToString();
                        string Xclientid = Variables.myguid.Replace("-", "");
                        Variables.randomhex32 = PasswordGenerator.Generate(32, "0123456789abcdef");
                        var day = "0" + PasswordGenerator.Generate(1, "123456789");
                        var month = "0" + PasswordGenerator.Generate(1, "123456789");
                        var yeartwodigit = PasswordGenerator.Generate(2, "789");
                        var year = ("19" + yeartwodigit);
                        var birthday = year + "-" + month + "-" + day;
                        var genderlist = new List<int> { 1, 2 };
                        Random random = new Random();
                        int index = random.Next(genderlist.Count);
                        int gender = genderlist[index];
                        string username = PasswordGenerator.Generate(12, "abcdefghijklmnopqrstuvwxyz");
                        string accountHolderName = username.Replace(".", "").Replace("-", "").Replace("_", "");
                        var password = PasswordGenerator.Generate(12, "0123456789abcdefghijklmnopqrstuvwxyz");
                        var email = Variables.zohoMailUsername + "+" + accountHolderName + "@" + Variables.zohoMailDomain;
                        var new_password = PasswordGenerator.Generate(12, "0123456789abcdefghijklmnopqrstuvwxyz");

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
                                        BlankTag1 = 42
                                    },
                                    emptytag3 = Array.Empty<byte>(),
                                    emptyTag4 = Array.Empty<byte>()
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
                                Appversion = "8.8.44",
                                Stringoffset = new List<uint> { 1, 2, 3 },
                                RandomHex32 = Variables.randomhex32
                            },
                            Tag4 = new SignUpRequest.Client
                            {
                                ClientMobile = "client_mobile"
                            }
                        };

                        byte[] signupSerialized = ProtobufHelper.Serialize(signUpRequest);

                        req.AddHeader("accept", "application/x-protobuf");
                        req.AddHeader("accept-Encoding", "gzip");
                        req.AddHeader("accept-Language", "en-US;q=0.5");
                        req.AddHeader("app-Platform", "iOS");
                        req.AddHeader("connection", "Keep-Alive");
                        req.AddHeader("host", "spclient.wg.spotify.com");
                        req.AddHeader("origin", "https://www.spotify.com");
                        req.AddHeader("user-agent", "Spotify/8.8.44 iOS/16.0.2 (iPhone10,3)");
                        req.AddHeader("spotify-app-version", "8.8.44.458");
                        req.AddHeader("x-client-id", Xclientid);
                        req.AddHeader("client-token", Variables.client_token);

                        var genrequest = req.Post("https://spclient.wg.spotify.com/signup/public/v2/account/create", signupSerialized,
                            "application/x-protobuf");
                        var genrequest_byte = genrequest.ToBytes();
                        if (genrequest.StatusCode == HttpStatusCode.OK && genrequest_byte.Length > 90)
                        {
                            Variables.login_token = ProtobufHelper.Deserialize<SignUpResponse>(genrequest_byte).usernameAndLogin.LoginToken;
                            Variables.spotify_username = ProtobufHelper.Deserialize<SignUpResponse>(genrequest_byte).usernameAndLogin.Username;
                            
                            string sender = "no-reply@spotify.com";
                            string receiver = email;

                            if(Variables.isemailverified.ToLower() == "y")
                            {
                                AccountEmailVerify emailVerifier = new AccountEmailVerify(Variables.zohoMailUsername, Variables.zohoPassword, sender, receiver);
                                Thread.Sleep(10000);
                                emailVerifier.VerifyEmail();
                            }
                            if(Variables.ispasswordchanged.ToLower() == "y")
                            {
                                ChangePassword.PasswordChange(password, new_password);
                                result = "| " + email + ":" + new_password;
                                break;
                            }

                            result = "| " + email + ":" + password; 
                            break;

                        }
                        else
                        {
                            result = "Invalid";
                            break;
                            

                        }



                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Variables.Error++;
                }
            }
            return result;
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
