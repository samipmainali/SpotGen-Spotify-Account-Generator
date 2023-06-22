using ProtoBuf;

namespace Spotgen.Spotify
{
    internal class Protobuf
    {
        [ProtoContract]
        public class DeviceIdentity
        {
            [ProtoMember(1)]
            public string Id { get; set; }

            [ProtoMember(2)]
            public string WindowsIdentity { get; set; }
        }

        [ProtoContract]
        public class Credentials
        {
            [ProtoMember(1)]
            public string Email { get; set; }

            [ProtoMember(2)]
            public string Password { get; set; }

            [ProtoMember(3)]
            public string Key { get; set; }
        }

        [ProtoContract]
        public class FirstMessageBody
        {
            [ProtoMember(1)]
            public DeviceIdentity DeviceIdentity { get; set; }

            [ProtoMember(101)]
            public Credentials Credentials { get; set; }
        }

        [ProtoContract]
        public class SecondMessageBody
        {
            [ProtoMember(1)]
            public DeviceIdentity deviceIdentity { get; set; }

            [ProtoMember(2)]
            public byte[] str { get; set; }

            [ProtoMember(3)]
            public MSG13 mSG3 { get; set; }

            [ProtoMember(101)]
            public Credentials credentials { get; set; }
        }

        [ProtoContract]
        internal class MSG1
        {
            [ProtoMember(2)] public long int64;

            [ProtoMember(1)] public byte[] str { get; set; }
        }

        [ProtoContract]
        public class MSG13
        {
            [ProtoMember(1)]
            public MSG12 mSG12 { get; set; }
        }

        [ProtoContract]
        public class MSG12
        {
            [ProtoMember(1)]
            public MSG11 mSG1 { get; set; }
        }

        // Define the MSG11 class
        [ProtoContract]
        public class MSG11
        {
            [ProtoMember(2)]
            public MSG0 int64 { get; set; }

            [ProtoMember(1)]
            public byte[] str { get; set; }
        }

        [ProtoContract]
        public class MSG0
        {
            [ProtoMember(2)] public long int64;
        }

        [ProtoContract]
        internal class FirstMessasgeDeserialized
        {
            [ProtoMember(3)] public MSG3 mSG3 { get; set; }

            [ProtoMember(5)] public byte[] str { get; set; }
        }

        [ProtoContract]
        internal class MSG3
        {
            [ProtoMember(1)] public MSG2 mSG2 { get; set; }
        }

        [ProtoContract]
        internal class MSG2
        {
            [ProtoMember(1)] public MSG1 mSG1 { get; set; }
        }

        [ProtoContract]
        internal class SecondMessageResponseBody
        {
            [ProtoMember(1)] public SecondMessasgeDeserialized body;
        }

        [ProtoContract]
        internal class SecondMessasgeDeserialized
        {
            [ProtoMember(1)] public string _1;

            [ProtoMember(3)] public string _3;

            [ProtoMember(4)] public int _4;

            [ProtoMember(2)] public string token;
        }

    }

   
}
