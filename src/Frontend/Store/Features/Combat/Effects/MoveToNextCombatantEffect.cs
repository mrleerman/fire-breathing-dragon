using Fluxor;
using Frontend.Services.CombatConnection;
using Frontend.Store.Features.Combat.Actions.MoveToNextCombatant;

namespace Frontend.Store.Features.Combat.Effects
{
    internal class MoveToNextCombatantEffect(ILogger<MoveToNextCombatantEffect> logger, ICombatConnection combatConnection) : Effect<MoveToNextCombatantAction>
    {
        private readonly ILogger<MoveToNextCombatantEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(MoveToNextCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Moving to next Combatant");

                await _combatConnection.MoveToNextCombatant();

                _logger.LogInformation("Move to next Combatant successfully requested");

                dispatcher.Dispatch(new MoveToNextCombatantSuccessAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error moving to next Combatant");
                dispatcher.Dispatch(new MoveToNextCombatantFailureAction(e.Message));
            }
        }
    }
}
