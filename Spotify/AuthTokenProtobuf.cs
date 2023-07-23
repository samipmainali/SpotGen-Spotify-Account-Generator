using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotgen.Spotify
{
    internal class AuthTokenProtobuf
    {
        [ProtoContract]
        public class Loginv4_message
        {
            [ProtoContract]
            public class DeviceInfo
            {
                [ProtoMember(1)]
                public string XclientID { get; set; }

                [ProtoMember(2)]
                public string randomhex32 { get; set; }
            }

            [ProtoMember(1)]
            public DeviceInfo deviceInfo { get; set; }

            [ProtoContract]
            public class MiddleBody
            {
                [ProtoMember(1, IsPacked = true)]
                public int uints { get; set; }

                [ProtoContract]
                public class Subbody
                {
                    [ProtoMember(1)]
                    public int bool1 { get; set; }

                    [ProtoMember(2)]
                    public string callbackURL { get; set; }

                    [ProtoMember(3)]
                    public string creationID { get; set; }

                    [ProtoMember(4)]
                    public int bool2 { get; set; }
                }

                [ProtoMember(2)]
                public Subbody subbody { get; set; }
            }

            [ProtoMember(4)]
            public MiddleBody middleBody { get; set; }

            [ProtoContract]
            public class LoginTokenBody
            {
                [ProtoMember(1)]
                public string login_token { get; set; }
            }

            [ProtoMember(104)]
            public LoginTokenBody loginTokenBody { get; set; }
        }

        [ProtoContract]
        public class Login4_response
        {
            [ProtoContract]
            public class MainBody
            {
                [ProtoMember(1)]
                public string SpotifyUsername { get; set; }

                [ProtoMember(2)]
                public string unknowntoken { get; set; }

                [ProtoMember(3)]
                public string preauthtoken { get; set; }

                [ProtoMember(4)]
                public ushort expirytime { get; set; }
            }

            [ProtoMember(1)]
            public MainBody mainBody { get; set; }
        }

        [ProtoContract]
        public class Login3_authtoken_request
        {
            [ProtoContract]
            public class DeviceInfo
            {
                [ProtoMember(1)]
                public string xclientID { get; set; }

                [ProtoMember(2)]
                public string randomhex { get; set; }
            }

            [ProtoMember(1)]
            public DeviceInfo deviceInfo { get; set; }

            [ProtoContract]
            public class UsernameAndPreauthtoken
            {
                [ProtoMember(1)]
                public string spotify_username { get; set; }

                [ProtoMember(2)]
                public string pre_auth_token { get; set; }
            }

            [ProtoMember(100)]
            public UsernameAndPreauthtoken usernameAndPreauthtoken { get; set; }
        }

        [ProtoContract]
        public class Login3_token_response
        {
            [ProtoContract]
            public class MainBody
            {
                [ProtoMember(1)]
                public string spotifyusername { get; set; }

                [ProtoMember(2)]
                public string authorization_code { get; set; }

                [ProtoMember(3)]
                public string refresh_token { get; set; }

                [ProtoMember(4)]
                public ushort validtill { get; set; }
            }

            [ProtoMember(1)]
            public MainBody mainBody { get; set; }
        }
    }
}
