using Fluxor;
using Frontend.Services.CombatConnection;
using Frontend.Store.Features.Combat.Actions.AddCombatant;

namespace Frontend.Store.Features.Combat.Effects
{
    internal class AddCombatantEffect(ILogger<AddCombatantEffect> logger, ICombatConnection combatConnection) : Effect<AddCombatantAction>
    {
        private readonly ILogger<AddCombatantEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(AddCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Adding Combatant");

                await _combatConnection.AddCombatant(action.CombatantName, action.CombatantInitiativeBonus);

                _logger.LogInformation("Combatant addition successfully requested");

                dispatcher.Dispatch(new AddCombatantSuccessAction());
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error adding Combatant");
                dispatcher.Dispatch(new AddCombatantFailureAction(e.Message));
            }
        }
    }
}
