using System;
using System.Collections.Generic;
using System.Text;

namespace SysBot.Pokemon
{
    public class TradePartnerBS
    {
        public uint IDHash { get; }
        public uint SID { get; }
        public uint TID { get; }
        public byte GameVersion { get; }
        public string TrainerName { get; }

        public TradePartnerBS(byte[] bytes)
        {
            IDHash = BitConverter.ToUInt32(bytes, 0);

            // lmao what is bitmath
            var sidtid = IDHash.ToString("0000000000");
            SID = uint.Parse(sidtid[..4]);
            TID = uint.Parse(sidtid[4..10]);
            GameVersion = bytes[4];
            TrainerName = Encoding.UTF8.GetString(bytes, 5, bytes.Length-6).TrimEnd('\0');
        }
    }
}
