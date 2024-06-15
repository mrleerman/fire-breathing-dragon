using Fluxor;
using Frontend.Store.Features.Combat.Actions.RerollInitiative;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class RerollInitiativeReducer
    {
        [ReducerMethod(typeof(RerollInitiativeSuccessAction))]
        public static CombatState ReduceRerollInitiativeSuccessAction(CombatState state) => new(new(state.CombatantNames), null);

        [ReducerMethod]
        public static CombatState ReduceRerollInitiativeFailureAction(CombatState state, RerollInitiativeFailureAction action) => new(new(state.CombatantNames), action.ErrorMessage);
    }
}
