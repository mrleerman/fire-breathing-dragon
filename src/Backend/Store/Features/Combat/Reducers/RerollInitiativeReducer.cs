using Backend.Extensions;
using Backend.Models;
using Backend.Store.Features.Combat.Actions.RerollInitiative;
using Backend.Store.State;
using Fluxor;

namespace Backend.Store.Features.Combat.Reducers
{
    public static class RerollInitiativeReducer
    {
        [ReducerMethod(typeof(RerollInitiativeAction))]
        public static CombatState ReduceRerollInitiativeAction(CombatState state)
        {
            var newCombatants = new List<Combatant>(state.Combatants.Count);

            foreach(var combatant in state.Combatants)
            {
                newCombatants.AddCombatant(combatant.Name, combatant.InitiativeBonus);
            }

            return new(newCombatants, 0);
        }
    }
}
