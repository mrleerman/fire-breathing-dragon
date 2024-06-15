using Fluxor;
using Frontend.Services.CombatConnection;
using Frontend.Store.Features.Combat.Actions.RemoveCombatant;

namespace Frontend.Store.Features.Combat.Effects
{
    internal class RemoveCombatantEffect(ILogger<RemoveCombatantEffect> logger, ICombatConnection combatConnection) : Effect<RemoveCombatantAction>
    {
        private readonly ILogger<RemoveCombatantEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(RemoveCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Removing Combatant");

                await _combatConnection.RemoveCombatant(action.CombatantName);

                _logger.LogInformation("Combatant removal successfully requested");

                dispatcher.Dispatch(new RemoveCombatantSuccessAction());
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error removing Combatant");
                dispatcher.Dispatch(new RemoveCombatantFailureAction(e.Message));
            }
        }
    }
}
