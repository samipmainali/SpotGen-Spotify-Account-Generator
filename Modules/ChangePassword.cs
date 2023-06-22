using Leaf.xNet;
using Spotgen.Spotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using static Spotgen.Spotify.AuthTokenProtobuf;
using HttpStatusCode = Leaf.xNet.HttpStatusCode;

namespace Spotgen.Modules
{
    internal class ChangePassword
    {

        public static string PasswordChange(string password, string new_password)
        {
            string result = "";
            for (; ; )
            {
                try
                {
                    using (Leaf.xNet.HttpRequest req = new Leaf.xNet.HttpRequest())
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

                        Loginv4_message loginv4_Message = new Loginv4_message
                        {
                            deviceInfo = new Loginv4_message.DeviceInfo
                            {
                                XclientID = "58bd3c95768941ea9eb4350aaa033eb3",
                                randomhex32 = Variables.randomhex32
                            },
                            middleBody = new Loginv4_message.MiddleBody
                            {
                                uints = new List<uint> { 1 },
                                subbody = new Loginv4_message.MiddleBody.Subbody
                                {
                                    bool1 = 1,
                                    callbackURL = "spotify://example/callback",
                                    creationID = Variables.myguid,
                                    bool2 = 1
                                }
                            },
                            loginTokenBody = new Loginv4_message.LoginTokenBody
                            {
                                login_token = Variables.login_token
                            }
                        };

                        var login4_request_serialized = ProtobufHelper.Serialize(loginv4_Message);

                        req.AddHeader("Content-Type", "application/x-protobuf");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("Connection", "keep-alive");
                        req.AddHeader("client-token", Variables.client_token);
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("User-Agent", "Spotify/8.8.44 iOS/16.0.2 (iPhone10,3)");
                        req.AddHeader("Content-Length", login4_request_serialized.Length.ToString());
                        req.AddHeader("Cache-Control", "no-cache, no-store, max-age=0");
                        req.AddHeader("Accept-Language", "en-AU,en;q=0.9");

                        var login4_response = req.Post("https://login5.spotify.com/v4/login", login4_request_serialized, "application/x-protobuf");

                        var login4_response_byte = login4_response.ToBytes();

                        string preauthtoken = ProtobufHelper.Deserialize<Login4_response>(login4_response_byte).mainBody.preauthtoken;

                        Login3_authtoken_request login3_Authtoken_Request = new Login3_authtoken_request
                        {
                            deviceInfo = new Login3_authtoken_request.DeviceInfo
                            {
                                xclientID = "58bd3c95768941ea9eb4350aaa033eb3",
                                randomhex = Variables.randomhex32
                            },
                            usernameAndPreauthtoken = new Login3_authtoken_request.UsernameAndPreauthtoken
                            {
                                spotify_username = Variables.spotify_username,
                                pre_auth_token = preauthtoken
                            }
                        };

                        var login3_authtoken_serialized = ProtobufHelper.Serialize(login3_Authtoken_Request);


                        req.AddHeader("Host", "login5.spotify.com");
                        req.AddHeader("Content-Type", "application/x-protobuf");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("Connection", "keep-alive");
                        req.AddHeader("client-token", Variables.client_token);
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("User-Agent", "Spotify/8.8.44 iOS/16.0.2 (iPhone10,3)");
                        req.AddHeader("Content-Length", login3_authtoken_serialized.Length.ToString());
                        req.AddHeader("Cache-Control", "no-cache, no-store, max-age=0");
                        req.AddHeader("Accept-Language", "en-AU,en;q=0.9");

                        var login3_authtoken_response = req.Post("https://login5.spotify.com/v3/login", login3_authtoken_serialized, "application/x-protobuf");

                        var authorization_code = ProtobufHelper.Deserialize<Login3_token_response>(login3_authtoken_response.ToBytes()).mainBody.authorization_code;

                        string session_transfer_payload = "{\"url\":\"https://open.spotify.com\"}";

                        req.AddHeader("Host", "spclient.wg.spotify.com");
                        req.AddHeader("Spotify-App-Version", "8.8.44.458");
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("Authorization", "Bearer " + authorization_code);
                        req.AddHeader("App-Platform", "iOS");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("Cache-Control", "no-cache, no-store, max-age=0");
                        req.AddHeader("Accept-Language", "en-GB, en;q=0.50");
                        req.AddHeader("Content-Type", "application/json");
                        req.AddHeader("Content-Length", session_transfer_payload.Length.ToString());
                        req.AddHeader("User-Agent", "Spotify/8.8.44.458 iOS/Version 16.0.2 (Build 20A380)");
                        req.AddHeader("Connection", "keep-alive");
                        req.AddHeader("client-token", Variables.client_token);

                        string session_token_request = req.Post("https://spclient.wg.spotify.com/sessiontransfer/v1/token", session_transfer_payload, "application/json").ToString();
                        string session_token = session_token_request.Substring("{\"token\":\"", "\"");

                        req.AllowAutoRedirect = true;
                        req.AddHeader("Host", "accounts.spotify.com");
                        req.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                        req.AddHeader("Accept-Language", "en-AU,en;q=0.9");
                        req.AddHeader("Connection", "keep-alive");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");

                        string csrf_token = req.Get("https://accounts.spotify.com/login/ott/v2").ToString().Substring("csrfSettings\":{\"enabled\":true,\"initialToken\":\"", "\"");

                        var ott_verify_payload = "{\"token\":\"" + session_token + "\"}";

                        req.AddHeader("Host", "accounts.spotify.com");
                        req.AddHeader("Accept", "*/*");
                        req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                        req.AddHeader("Accept-Language", "en-AU,en;q=0.9");
                        req.AddHeader("Content-Type", "text/plain;charset=UTF-8");
                        req.AddHeader("Origin", "https://accounts.spotify.com");
                        req.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                        req.AddHeader("Connection", "keep-alive");
                        req.AddHeader("Referer", "https://accounts.spotify.com/en/login/ott/v2");
                        req.AddHeader("Content-Length", ott_verify_payload.Length.ToString());
                        req.AddHeader("X-CSRF-Token", csrf_token);

                        var ott_verify = req.Post("https://accounts.spotify.com/api/login/ott/verify", ott_verify_payload, "application/json");

                        if (ott_verify.StatusCode == HttpStatusCode.OK)
                        {
                            string Change_password_csrf = req.Get("https://www.spotify.com/us/account/change-password/").ToString().Substring("\"csrfToken\":\"", "\"");
                            req.ClearAllHeaders();
                            req.AddHeader("Authority", "www.spotify.com");
                            req.AddHeader("Path", "/api/account-settings/v1/change-password");
                            req.AddHeader("Accept-Language", "en-US,en;q=0.9");
                            req.AddHeader("Accept-Encoding", "gzip, deflate, br");
                            req.AddHeader("X-Csrf-Token", Change_password_csrf);
                            req.AddHeader("Referer", "https://www.spotify.com/us/account/change-password/");
                            req.AddHeader("Origin", "https://www.spotify.com");
                            req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
                            req.AddHeader("Sec-Ch-Ua-Platform", "Windows");

                            string change_password_paylaod = "{\"old_password\":\"" + password + "\",\"new_password\":\"" + new_password + "\"}";
                            var change_password_request = req.Put("https://www.spotify.com/api/account-settings/v1/change-password", change_password_paylaod, "application/json");
                            if (change_password_request.StatusCode == HttpStatusCode.OK)
                            {

                                break;
                            }

                        }


                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());  
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
