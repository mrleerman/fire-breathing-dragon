using Backend.Extensions;
using Backend.Models;
using Backend.Store.Features.Combat.Actions.AddCombatant;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Reducers
{
    public static class AddCombatantReducer
    {
        [ReducerMethod]
        public static CombatState ReduceStoreUniqueCombatantAction(CombatState state, StoreUniqueCombatantAction action)
        {
            var newCombatantList = new List<Combatant>(state.Combatants);

            // Handle race condition where multiple users attempt to add the same combatant simultaneously
            if (newCombatantList.FindIndexOf(action.CombatantName) != -1)
            {
                return new(newCombatantList, state.CurrentCombatant);
            }

            var combatantSlot = newCombatantList.AddCombatant(action.CombatantName, action.CombatantInitiativeBonus);

            var newCurrentCombatant = 0; // Special case for this being the first combatant added to the list
            if (newCombatantList.Count > 1)
            {
                newCurrentCombatant = combatantSlot <= state.CurrentCombatant ? state.CurrentCombatant + 1 : state.CurrentCombatant;
            }

            return new(newCombatantList, newCurrentCombatant);
        }
    }
}
