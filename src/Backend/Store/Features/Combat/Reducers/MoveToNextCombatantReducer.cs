using Backend.Store.Features.Combat.Actions.MoveToNextCombatant;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Reducers
{
    public class MoveToNextCombatantReducer
    {
        [ReducerMethod(typeof(MoveToNextCombatantAction))]
        public static CombatState ReduceMoveToNextCombatantAction(CombatState state)
        {
            // Nothing to cycle through if there are no combatants
            if (state.Combatants.Count == 0)
            {
                return new(new(state.Combatants), state.CurrentCombatant);
            }

            // Increment to the next combatant
            var newCurrentCombatant = state.CurrentCombatant + 1;
            if (newCurrentCombatant >= state.Combatants.Count)
            {
                // Loop back to the first combatant if previous was the last one
                newCurrentCombatant = 0;
            }

            return new(new(state.Combatants), newCurrentCombatant);
        }
    }
}
