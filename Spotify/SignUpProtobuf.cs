using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Spotgen.Spotify
{
    internal class SignUpProtobuf
    {
        [ProtoContract]
        public class SignUpRequest
        {
            [ProtoMember(1)]
            public string Url { get; set; }

            [ProtoMember(2)]
            public UserInfo Tag2 { get; set; }

            [ProtoMember(3)]
            public DeviceInfo Tag3 { get; set; }

            [ProtoMember(4)]
            public Client Tag4 { get; set; }

            [ProtoContract]
            public class UserInfo
            {
                [ProtoMember(1)]
                public string Username { get; set; }

                [ProtoMember(2)]
                public string DOB { get; set; }

                [ProtoMember(3)]
                public int Gender { get; set; }

                [ProtoMember(4)]
                public BlankVariant Tag4 { get; set; }

                [ProtoMember(101)]
                public SignUpCredentials Tag101 { get; set; }

                [ProtoContract]
                public class BlankVariant
                {
                    [ProtoMember(1)]
                    public BlankVariantTag1 Tag1 { get; set; }

                    [ProtoMember(3)]
                    public BlankVariantTag2 Tag2 { get; set; }

                    [ProtoMember(4)]
                    public BlankVariantTag3 Tag3 { get; set; }

                    [ProtoContract]
                    public class BlankVariantTag1
                    {
                        [ProtoMember(1)]
                        public int BlankTag1 { get; set; }
                    }

                    [ProtoContract]
                    public class BlankVariantTag2
                    {
                    }

                    [ProtoContract]
                    public class BlankVariantTag3
                    {
                        
                    }
                }

                [ProtoContract]
                public class SignUpCredentials
                {
                    [ProtoMember(1)]
                    public string Signupemail { get; set; }

                    [ProtoMember(2)]
                    public string Password { get; set; }
                }
            }

            [ProtoContract]
            public class DeviceInfo
            {
                [ProtoMember(1)]
                public string ClientId { get; set; }

                [ProtoMember(2)]
                public string Os { get; set; }

                [ProtoMember(3)]
                public string Appversion { get; set; }

                [ProtoMember(4)]
                public int Stringoffset { get; set; }

                [ProtoMember(5)]
                public string RandomHex32 { get; set; }
            }

            [ProtoContract]
            public class Client
            {
                [ProtoMember(1)]
                public string ClientMobile { get; set; }
            }
        }

        [ProtoContract]
        public class SignUpResponse
        {
            [ProtoContract]
            public class UsernameAndLogin
            {
                [ProtoMember(1)]
                public string Username { get; set; }

                [ProtoMember(2)]
                public string LoginToken { get; set; }
            }

            [ProtoMember(1)]
            public UsernameAndLogin usernameAndLogin { get; set; }

            [ProtoMember(4)]
            public string CreationId { get; set; }
        }
    }
}
