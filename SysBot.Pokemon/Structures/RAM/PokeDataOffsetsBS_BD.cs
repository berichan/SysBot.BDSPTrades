using System;

namespace SysBot.Pokemon
{
    /// <summary>
    /// Brilliant Diamond Pointers
    /// </summary>
    public class PokeDataOffsetsBS_BD : BasePokeDataOffsetsBS
    {
        public override long[] BoxStartPokemonPointer => new long[] { 0x4C12B78, 0xB8, 0x170, 0x20, 0x20, 0x20 };

        public override long[] LinkTradePartnerPokemonPointer => new long[] { 0x473F210, 0xB8, 0x08, 0x20 }; // requires badexpr check
        public override long[] LinkTradePartnerIDPointer => new long[] { 0x4C192B8, 0xB8, 0x08, 0x20 }; // sidtid[4] gamever[1] ot[11(?)] 
        public override long[] LinkTradePartnerNIDPointer => new long[] { 0x4FFC888, 0x20, 0x78, 0x08, 0x35C010 };

        public override long[] PlayerPositionPointer => new long[] { 0x4C0E608, 0x90, 0x118, 0x120 }; // Will be zero until game boots up
        public override long[] PlayerRotationPointer => new long[] { 0x4C0E608, 0x90, 0x118, 0x130 };
        public override long[] PlayerMovementPointer => new long[] { 0x4C12B78, 0xB8, 0x10 };

        public override long[] UnitySceneStreamPointer => new long[] { 0x4C2AAA0, 0xA0 }; // 0x01 for large scenes, 0x09 for local union room >0x20 for pokecenter

        public override long[] SubMenuStatePointer => new long[] { 0x4C1A980, 0x200, 0xE0, 0x28, 0x240, 0x00 }; // 0x41 title screen, 0x46 nonbox, 0x47 pokemon menu, 0x79 box

        public override long[] MainSavePointer => new long[] { 0x4D17AB0, 0x20 };
    }
}
