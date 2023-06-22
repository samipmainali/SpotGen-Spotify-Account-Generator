using ProtoBuf;
using System.Collections.Generic;

namespace Spotgen.Spotify
{
    internal class ClientTokenProtobuf
    {
        [ProtoContract]
        public class ClientTokenFirstRequest
        {
            [ProtoMember(1)]
            public ushort IsClient { get; set; }

            [ProtoMember(2)]
            public DeviceInfo deviceInfo { get; set; }

            [ProtoContract]
            public class DeviceInfo
            {
                [ProtoMember(1)]
                public string AppVersion { get; set; }

                [ProtoMember(2)]
                public string ClientID { get; set; }

                [ProtoMember(3)]
                public DeviceModelMain deviceModelMain { get; set; }

                [ProtoContract]
                public class DeviceModelMain
                {
                    [ProtoMember(1)]
                    public DeviceModelSub deviceModelSub { get; set; }

                    [ProtoMember(2)]
                    public string Random32Hex { get; set; }

                    [ProtoContract]
                    public class DeviceModelSub
                    {
                        [ProtoMember(2)]
                        public DeviceModelInfo deviceModelInfo { get; set; }

                        [ProtoContract]
                        public class DeviceModelInfo
                        {
                            [ProtoMember(3)]
                            public string DeviceName { get; set; }

                            [ProtoMember(4)]
                            public string IOSVersion { get; set; }
                        }
                    }
                }
            }
        }
        [ProtoContract]
        public class ClientTokenFirstResponse
        {
            [ProtoMember(1)]
            public ushort RandomInt { get; set; }

            [ProtoMember(3)]
            public Mainbody mainbody { get; set; }

            [ProtoContract]
            public class Mainbody
            {
                [ProtoMember(1)]
                public string Token { get; set; }

                [ProtoMember(2)]
                public LowerbodyMain lowerbodyMain { get; set; }
            }

            [ProtoContract]
            public class LowerbodyMain
            {
                [ProtoMember(4)]
                public Lowerbody lowerbody { get; set; }
            }

            [ProtoContract]
            public class Lowerbody
            {
                [ProtoMember(1)]
                public ushort RandomInt { get; set; }

                [ProtoMember(2)]
                public string RandomHex32 { get; set; }
            }
        }

        [ProtoContract]
        public class ClientTokenSecondRequest
        {
            [ProtoMember(1)]
            public ushort RandomInt { get; set; }

            [ProtoMember(3)]
            public MainBody mainBody { get; set; }

            [ProtoContract]
            public class MainBody
            {
                [ProtoMember(1)]
                public string Token { get; set; }

                [ProtoMember(2)]
                public LowerBodyMain lowerBodyMain { get; set; }
            }

            [ProtoContract]
            public class LowerBodyMain
            {
                [ProtoMember(1)]
                public ushort Randomint { get; set; }

                [ProtoMember(4)]
                public LowerBody lowerBody { get; set; }
            }

            [ProtoContract]
            public class LowerBody
            {
                [ProtoMember(1)]
                public string RandomHex32 { get; set; }
            }
        }

        [ProtoContract]
        public class ClientTokenSecondResponse
        {
            [ProtoMember(1)]
            public ushort IsTrue { get; set; }

            [ProtoMember(2)]
            public MainBody mainBody { get; set; }

            [ProtoContract]
            public class MainBody
            {
                [ProtoMember(1)]
                public string ClientToken { get; set; }

                [ProtoMember(2)]
                public ushort ValidTill { get; set; }

                [ProtoMember(3)]
                public ushort Validity { get; set; }

                [ProtoMember(4)]
                public List<Website> TokenOffset { get; set; }

                [ProtoContract]
                public class Website
                {
                    [ProtoMember(1)]
                    public string website { get; set; }
                }
            }
        }
    }
}
