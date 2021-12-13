using System;
using System.Collections.Generic;

namespace SysBot.Pokemon
{
    /// <summary>
    /// Brilliant Diamond Pointers
    /// </summary>
    public class PokeDataOffsetsBS_BD : BasePokeDataOffsetsBS
    {
        public override IReadOnlyList<long> BoxStartPokemonPointer { get; } = new long[] { 0x4E29C50, 0xB8, 0x170, 0x20, 0x20, 0x20 };

        public override IReadOnlyList<long> LinkTradePartnerPokemonPointer { get; } = new long[] { 0x4E30428, 0xB8, 0x8, 0x20 };
        public override IReadOnlyList<long> LinkTradePartnerNamePointer { get; } = new long[] { 0x4E358B0, 0xB8, 0x30, 0x108, 0x28, 0x90, 0x18, 0x0 };
        public override IReadOnlyList<long> LinkTradePartnerIDPointer { get; } = new long[] { 0x4E358B0, 0xB8, 0x30, 0x108, 0x28, 0x90, 0x10 };
        public override IReadOnlyList<long> LinkTradePartnerParamPointer { get; } = new long[] { 0x4E358B0, 0xB8, 0x30, 0x108, 0x28, 0x90 };
        public override IReadOnlyList<long> LinkTradePartnerNIDPointer { get; } = new long[] { 0x4FFE810, 0x70, 0x168, 0x40 };

        public override IReadOnlyList<long> PlayerPositionPointer { get; } = new long[] { 0x4C0F578, 0x90, 0x118, 0x120 }; // Will be zero until game boots up
        public override IReadOnlyList<long> PlayerRotationPointer { get; } = new long[] { 0x4C0F578, 0x90, 0x118, 0x130 };
        public override IReadOnlyList<long> PlayerMovementPointer { get; } = new long[] { 0x4E29C50, 0xB8, 0x10 };

        public override IReadOnlyList<long> UnitySceneStreamPointer { get; } = new long[] { 0x4E41B78, 0xA0 }; // 0x01 for large scenes, 0x09 for local union room >0x20 for pokecenter. View base class for more info
        public override IReadOnlyList<long> SubMenuStatePointer { get; } = new long[] { 0x4E28F38, 0xB8, 0x00, 0x250, 0x240, 0x00 }; // 0x41 title screen, 0x46 nonbox, 0x47 pokemon menu, 0x79 box

        public override IReadOnlyList<long> SceneIDPointer { get; } = new long[] { 0x4E29C48, 0xB8, 0x18 };

        // Union Work - Detects states in the Union Room
        public override IReadOnlyList<long> UnionWorkIsGamingPointer { get; } = new long[] { 0x4E29D80, 0xB8, 0x3C }; // 1 when loaded into Union Room, 0 otherwise
        public override IReadOnlyList<long> UnionWorkIsTalkingPointer { get; } = new long[] { 0x4E29D80, 0xB8, 0x81 };  // 1 when talking to another player or in box, 0 otherwise
        public override IReadOnlyList<long> UnionWorkPenaltyPointer { get; } = new long[] { 0x4E29D80, 0xB8, 0x8C }; // 0 when no penalty, float value otherwise.

        public override IReadOnlyList<long> MainSavePointer { get; } = new long[] { 0x4C964E8, 0x20 };
        public override IReadOnlyList<long> ConfigPointer { get; } = new long[] { 0x4E34DD0, 0xB8, 0x10, 0xA8 };
    }
}
