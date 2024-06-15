using Backend.Extensions;
using Backend.Hubs;
using Backend.Models;
using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.State;
using Fluxor;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Store.Features.Combat.Effects
{
    public class BroadcastCombatantsEffect(ILogger<BroadcastCombatantsEffect> logger, IState<CombatState> combatState, IHubContext<CombatHub, IPlayerClient> hub) : Effect<BroadcastCombatantsAction>
    {
        private readonly ILogger<BroadcastCombatantsEffect> _logger = logger;
        private readonly IState<CombatState> _combatState = combatState;
        private readonly IHubContext<CombatHub, IPlayerClient> _hub = hub;

        public override async Task HandleAsync(BroadcastCombatantsAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Broadcasting Combatant information to all clients");

                var combatantNames = _combatState.Value.Combatants.OrderByInitiative(_combatState.Value.CurrentCombatant);
                await _hub.Clients.All.CombatantUpdate(combatantNames);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error broadcasting combatants to listeners");
            }
        }
    }
}
