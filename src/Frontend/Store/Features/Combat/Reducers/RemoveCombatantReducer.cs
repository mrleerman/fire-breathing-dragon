using Fluxor;
using Frontend.Store.Features.Combat.Actions.RemoveCombatant;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class RemoveCombatantReducer
    {
        [ReducerMethod(typeof(RemoveCombatantSuccessAction))]
        public static CombatState ReduceRemoveCombatantSuccessAction(CombatState state) => new(new(state.CombatantNames), null);

        [ReducerMethod]
        public static CombatState ReduceRemoveCombatantFailureAction(CombatState state, RemoveCombatantFailureAction action) => new(new(state.CombatantNames), action.ErrorMessage);
    }
}
