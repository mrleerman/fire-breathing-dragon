using Backend.Extensions;
using Backend.Store.Features.Combat.Actions.AddCombatant;
using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Effects
{
    internal class AddCombatantEffect(ILogger<AddCombatantEffect> logger, IState<CombatState> combatState) : Effect<AddCombatantAction>
    {
        private readonly ILogger<AddCombatantEffect> _logger = logger;

        public IState<CombatState> CombatState { get; } = combatState;

        public override Task HandleAsync(AddCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Adding Combatant");

                var existingCombatantIndex = CombatState.Value.Combatants.FindIndexOf(action.CombatantName);
                if (existingCombatantIndex != -1)
                {
                    _logger.LogInformation("Combatant '{CombatantName}' already exists", action.CombatantName);

                    // TODO: Notify requester of failed add
                    return Task.CompletedTask;
                }

                dispatcher.Dispatch(new StoreUniqueCombatantAction(action.CombatantName, action.CombatantInitiativeBonus));

                dispatcher.Dispatch(new BroadcastCombatantsAction());

                // TODO: Notify requester of successful add

                _logger.LogInformation("Combatant successfully added");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding Combatant");

                // TODO: Notify requester of failed add
            }

            return Task.CompletedTask;
        }
    }
}
