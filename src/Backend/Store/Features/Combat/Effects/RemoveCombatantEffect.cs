using Backend.Store.Features.Combat.Actions.RemoveCombatant;
using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.State;
using Fluxor;
using Backend.Extensions;

namespace Backend.Store.Features.Combat.Effects
{
    internal class RemoveCombatantEffect(ILogger<RemoveCombatantEffect> logger, IState<CombatState> combatState) : Effect<RemoveCombatantAction>
    {
        private readonly ILogger<RemoveCombatantEffect> _logger = logger;

        public IState<CombatState> CombatState { get; } = combatState;

        public override Task HandleAsync(RemoveCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Removing Combatant");

                var existingCombatantIndex = CombatState.Value.Combatants.FindIndexOf(action.CombatantName);
                if (existingCombatantIndex == -1)
                {
                    _logger.LogInformation("Combatant '{CombatantName}' does not exist", action.CombatantName);

                    // TODO: Notify requester of failed remove

                    return Task.CompletedTask;
                }

                dispatcher.Dispatch(new DropStoredCombatantAction(action.CombatantName));

                dispatcher.Dispatch(new BroadcastCombatantsAction());

                // TODO: Notify requester of successful removal

                _logger.LogInformation("Combatant successfully removed");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error removing Combatant");

                // TODO: Notify requester of failed remove
            }

            return Task.CompletedTask;
        }
    }
}
