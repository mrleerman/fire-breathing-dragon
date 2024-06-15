using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.Features.Combat.Actions.RerollInitiative;
using Fluxor;

namespace Backend.Store.Features.Combat.Effects
{
    internal class RerollInitiativeEffect(ILogger<RerollInitiativeEffect> logger) : Effect<RerollInitiativeAction>
    {
        private readonly ILogger<RerollInitiativeEffect> _logger = logger;

        public override Task HandleAsync(RerollInitiativeAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Broadcasting Combatants after reroll of all Combatants' initiative");


                dispatcher.Dispatch(new BroadcastCombatantsAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error broadcasting Combatants after reroll of all Combatants' initiative");
            }

            return Task.CompletedTask;
        }
    }
}
