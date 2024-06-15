using Fluxor;
using Frontend.Store.Features.Combat.Actions.MoveToPreviousCombatant;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class MoveToPreviousCombatantReducer
    {
        [ReducerMethod(typeof(MoveToPreviousCombatantSuccessAction))]
        public static CombatState ReduceMoveToPreviousCombatantSuccessAction(CombatState state) => new(new(state.CombatantNames), null);

        [ReducerMethod]
        public static CombatState ReduceMoveToPreviousCombatantFailureAction(CombatState state, MoveToPreviousCombatantFailureAction action) => new(new(state.CombatantNames), action.ErrorMessage);
    }
}
