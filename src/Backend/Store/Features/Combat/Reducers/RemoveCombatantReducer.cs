using Backend.Extensions;
using Backend.Models;
using Backend.Store.Features.Combat.Actions.RemoveCombatant;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Reducers
{
    public static class RemoveCombatantReducer
    {
        [ReducerMethod]
        public static CombatState ReduceDropStoredCombatantAction(CombatState state, DropStoredCombatantAction action)
        {
            var newCombatantList = new List<Combatant>(state.Combatants);

            var combatantIndex = newCombatantList.FindIndexOf(action.CombatantName);

            // Handle race condition where multiple users attempt to remove the same combatant simultaneously
            if (combatantIndex == -1)
            {
                return new(newCombatantList, state.CurrentCombatant);
            }

            newCombatantList.RemoveAt(combatantIndex);

            var newCurrentCombatant = -1; // Special case for this being the last combatant removed from the list
            if (newCombatantList.Count > 0)
            {
                newCurrentCombatant = combatantIndex < state.CurrentCombatant ? state.CurrentCombatant - 1 : state.CurrentCombatant;
            }

            return new(newCombatantList, newCurrentCombatant);
        }
    }
}
