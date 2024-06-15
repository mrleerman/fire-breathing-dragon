using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.Features.Combat.Actions.MoveToPreviousCombatant;
using Fluxor;

namespace Backend.Store.Features.Combat.Effects
{
    internal class MoveToPreviousCombatantEffect(ILogger<MoveToPreviousCombatantEffect> logger) : Effect<MoveToPreviousCombatantAction>
    {
        private readonly ILogger<MoveToPreviousCombatantEffect> _logger = logger;

        public override Task HandleAsync(MoveToPreviousCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Broadcasting Combatants after move to previous Combatant");


                dispatcher.Dispatch(new BroadcastCombatantsAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error broadcasting Combatants after move to previous Combatant");
            }

            return Task.CompletedTask;
        }
    }
}
