using System;

namespace SysBot.Pokemon
{
    /// <summary>
    /// Shining Pearl Pointers
    /// </summary>
    public class PokeDataOffsetsBS_SP : BasePokeDataOffsetsBS
    {
        public override long[] BoxStartPokemonPointer => new long[] { 0x4E29C50, 0xB8, 0x170, 0x20, 0x20, 0x20 };

        public override long[] LinkTradePartnerPokemonPointer => new long[] { 0x4740040, 0xB8, 0x08, 0x20 }; // requires badexpr check
        public override long[] LinkTradePartnerIDPointer => new long[] { 0x473FF50, 0xB8, 0x08, 0x20 }; // sidtid[4] gamever[1] ot[11(?)] 
        public override long[] LinkTradePartnerNIDPointer => new long[] { 0x4FFC888, 0x20, 0x78, 0x08, 0x35C010 }; 

        public override long[] PlayerPositionPointer => new long[] { 0x4C0F578, 0x90, 0x118, 0x120 }; // Will be zero until game boots up
        public override long[] PlayerRotationPointer => new long[] { 0x4C0F578, 0x90, 0x118, 0x130 };
        public override long[] PlayerMovementPointer => new long[] { 0x4E29C50, 0xB8, 0x10 };

        public override long[] UnitySceneStreamPointer => new long[] { 0x4E41B78, 0xA0 }; // 0x01 for large scenes, 0x09 for local union room >0x20 for pokecenter. View base class for more info

        public override long[] SubMenuStatePointer => new long[] { 0x4E28F38, 0xB8, 0x00, 0x250, 0x240, 0x00 }; // 0x41 title screen, 0x46 nonbox, 0x47 pokemon menu, 0x79 box

        public override long[] MainSavePointer => new long[] { 0x4C964E8, 0x20 };
    }
}
