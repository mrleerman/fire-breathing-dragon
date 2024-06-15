using Backend.Store.Features.Combat.Actions.MoveToPreviousCombatant;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Reducers
{
    public class MoveToPreviousCombatantReducer
    {
        [ReducerMethod(typeof(MoveToPreviousCombatantAction))]
        public static CombatState ReduceMoveToPreviousCombatantAction(CombatState state)
        {
            // Nothing to cycle through if there are no combatants
            if (state.Combatants.Count == 0)
            {
                return new(new(state.Combatants), state.CurrentCombatant);
            }

            // Decrement to the previous combatant
            var newCurrentCombatant = state.CurrentCombatant - 1;
            if (newCurrentCombatant < 0)
            {
                // Loop back to the last combatant if previous was the first one
                newCurrentCombatant = state.Combatants.Count - 1;
            }

            return new(new(state.Combatants), newCurrentCombatant);
        }
    }
}
