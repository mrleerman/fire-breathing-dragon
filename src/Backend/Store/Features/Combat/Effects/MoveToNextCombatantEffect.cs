using Backend.Store.Features.Combat.Actions.BroadcastCombatants;
using Backend.Store.Features.Combat.Actions.MoveToNextCombatant;
using Fluxor;

namespace Backend.Store.Features.Combat.Effects
{
    internal class MoveToNextCombatantEffect(ILogger<MoveToNextCombatantEffect> logger) : Effect<MoveToNextCombatantAction>
    {
        private readonly ILogger<MoveToNextCombatantEffect> _logger = logger;

        public override Task HandleAsync(MoveToNextCombatantAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Broadcasting Combatants after move to next Combatant");


                dispatcher.Dispatch(new BroadcastCombatantsAction());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error broadcasting Combatants after move to next Combatant");
            }

            return Task.CompletedTask;
        }
    }
}
