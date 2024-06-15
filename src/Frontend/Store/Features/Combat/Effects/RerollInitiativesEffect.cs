using Fluxor;
using Frontend.Services.CombatConnection;
using Frontend.Store.Features.Combat.Actions.RerollInitiative;

namespace Frontend.Store.Features.Combat.Effects
{
    internal class RerollInitiativesEffect(ILogger<RerollInitiativesEffect> logger, ICombatConnection combatConnection) : Effect<RerollInitiativeAction>
    {
        private readonly ILogger<RerollInitiativesEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(RerollInitiativeAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Rerolling Combatant initiatives");

                await _combatConnection.RerollInitiatives();

                _logger.LogInformation("Reroll of Combatant iniatives successfully requested");

                dispatcher.Dispatch(new RerollInitiativeSuccessAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error rerolling Combatant initiatives");
                dispatcher.Dispatch(new RerollInitiativeFailureAction(e.Message));
            }
        }
    }
}
