using Fluxor;
using Frontend.Services.CombatConnection;
using Frontend.Store.Features.Combat.Actions.MoveToPreviousCombatant;

namespace Frontend.Store.Features.Combat.Effects
{
    internal class MoveToPreviousCombatantEffect(ILogger<MoveToPreviousCombatantEffect> logger, ICombatConnection combatConnection) : Effect<MoveToPreviousCombatantAction>
    {
        private readonly ILogger<MoveToPreviousCombatantEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(MoveToPreviousCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Moving to previous Combatant");

                await _combatConnection.MoveToPreviousCombatant();

                _logger.LogInformation("Move to previous Combatant successfully requested");

                dispatcher.Dispatch(new MoveToPreviousCombatantSuccessAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error moving to previous Combatant");
                dispatcher.Dispatch(new MoveToPreviousCombatantFailureAction(e.Message));
            }
        }
    }
}
