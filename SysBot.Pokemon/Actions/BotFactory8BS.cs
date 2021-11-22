using System;
using PKHeX.Core;

namespace SysBot.Pokemon
{
    public sealed class BotFactory8BS : BotFactory<PB8>
    {
        public override PokeRoutineExecutorBase CreateBot(PokeTradeHub<PB8> Hub, PokeBotState cfg) => cfg.NextRoutineType switch
        {
            PokeRoutineType.BDSPFlexTrade or PokeRoutineType.Idle
            or PokeRoutineType.BDSPClone
            or PokeRoutineType.BDSPLinkTrade
            or PokeRoutineType.BDSPSpecialRequest
            => new PokeTradeBotBS(Hub, cfg),

            _ => throw new ArgumentException(nameof(cfg.NextRoutineType)),
        };
    }
}
