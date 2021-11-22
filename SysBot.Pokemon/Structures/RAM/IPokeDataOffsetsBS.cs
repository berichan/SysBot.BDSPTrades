namespace SysBot.Pokemon
{
    public interface IPokeDataOffsetsBS
    {
        public long[] BoxStartPokemonPointer { get; }

        public long[] LinkTradePartnerPokemonPointer { get; }
        public long[] LinkTradePartnerIDPointer { get; }
        public long[] LinkTradePartnerNIDPointer { get; }

        public long[] PlayerPositionPointer { get; }
        public long[] PlayerRotationPointer { get; }
        public long[] PlayerMovementPointer { get; }

        public long[] UnitySceneStreamPointer { get; }

        public long[] SubMenuStatePointer { get; }

        public long[] MainSavePointer { get; }
    }
}
