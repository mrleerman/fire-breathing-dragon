using Fluxor;
using Frontend.Store.Features.Combat.Actions.AddCombatant;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class AddCombatantReducer
    {
        [ReducerMethod(typeof(AddCombatantSuccessAction))]
        public static CombatState ReduceAddCombatantSuccessAction(CombatState state) => new(new(state.CombatantNames), null);

        [ReducerMethod]
        public static CombatState ReduceAddCombatantFailureAction(CombatState state, AddCombatantFailureAction action) => new(new(state.CombatantNames), action.ErrorMessage);
    }
}
