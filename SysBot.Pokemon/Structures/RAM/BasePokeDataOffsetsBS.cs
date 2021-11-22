using System;
using System.Collections.Generic;
using System.Text;

namespace SysBot.Pokemon
{
    public abstract class BasePokeDataOffsetsBS : IPokeDataOffsetsBS
    {
        public const string ShiningPearlID = "010018E011D92000";
        public const string BrilliantDiamondID = "0100000011D90000";

        public abstract long[] BoxStartPokemonPointer { get; }
        public abstract long[] LinkTradePartnerPokemonPointer { get; }
        public abstract long[] LinkTradePartnerIDPointer { get; }
        public abstract long[] LinkTradePartnerNIDPointer { get; }
        public abstract long[] PlayerPositionPointer { get; }
        public abstract long[] PlayerRotationPointer { get; }
        public abstract long[] PlayerMovementPointer { get; }
        public abstract long[] UnitySceneStreamPointer { get; }
        public abstract long[] SubMenuStatePointer { get; }
        public abstract long[] MainSavePointer { get; }

        public const byte UnitySceneStream_LocalUnionRoom = 0x09;
        public const byte UnitySceneStream_PokeCentreUpstairsLocal = 0x26;
        public const byte UnitySceneStream_PokeCentreMain = 0x22;
        public const byte UnitySceneStream_PokeCentreDownstairsGlobal = 0x24;
        public const byte UnitySceneStream_FullScene = 0x01;

        public const byte SubMenuState_TitleScreen = 0x41;
        public const byte SubMenuState_NonBox = 0x46;
        public const byte SubMenuState_PauseMenu = 0x47;
        public const byte SubMenuState_Box = 0x79;

        public const int BoxFormatSlotSize = 0x158;

        public static readonly Vector3 LocalUnionRoomCenter = new(-7f, 0, 5.5f);
        public static readonly Vector3 GlobalUnionRoomCenter = new(-14.5f, 0, 10.5f);

        public BasePokeDataOffsetsBS() { }

        public static SubMenuState GetSubMenuState(byte val)
        {
            return val switch
            {
                SubMenuState_TitleScreen => SubMenuState.TitleScreen,
                SubMenuState_NonBox => SubMenuState.NonBox,
                SubMenuState_Box => SubMenuState.Box,
                _ => SubMenuState.Unknown,
            };
        }

        public static UnitySceneStream GetUnitySceneStream(byte val)
        {
            return val switch
            {
                UnitySceneStream_LocalUnionRoom => UnitySceneStream.LocalUnionRoom,
                UnitySceneStream_PokeCentreUpstairsLocal => UnitySceneStream.PokeCentreUpstairsLocal,
                UnitySceneStream_PokeCentreDownstairsGlobal => UnitySceneStream.PokeCentreDownstairsGlobal,
                UnitySceneStream_FullScene => UnitySceneStream.FullScene,
                _ => UnitySceneStream.Unknown,
            };
        }

        public static Vector3 GetUnionRoomCenter(UnitySceneStream destination)
        {
            return destination switch
            {
                UnitySceneStream.PokeCentreUpstairsLocal => LocalUnionRoomCenter,
                UnitySceneStream.PokeCentreDownstairsGlobal => GlobalUnionRoomCenter,
                _ => new Vector3(),
            };
        }
    }

    public enum SubMenuState : byte
    {
        TitleScreen,
        NonBox,
        Box,
        Unknown
    }

    public enum UnitySceneStream : byte
    {
        LocalUnionRoom,
        PokeCentreUpstairsLocal,
        PokeCentreDownstairsGlobal,
        FullScene,
        Unknown
    }
}
