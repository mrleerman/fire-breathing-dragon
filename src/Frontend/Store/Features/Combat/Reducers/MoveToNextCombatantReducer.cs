using Fluxor;
using Frontend.Store.Features.Combat.Actions.MoveToNextCombatant;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class MoveToNextCombatantReducer
    {
        [ReducerMethod(typeof(MoveToNextCombatantSuccessAction))]
        public static CombatState ReduceMoveToNextCombatantSuccessAction(CombatState state) => new(new(state.CombatantNames), null);

        [ReducerMethod]
        public static CombatState ReduceMoveToNextCombatantFailureAction(CombatState state, MoveToNextCombatantFailureAction action) => new(new(state.CombatantNames), action.ErrorMessage);
    }
}
