using Fluxor;
using Frontend.Store.Features.Combat.Actions.SetCombatants;
using Frontend.Store.State;

namespace Frontend.Store.Features.Combat.Reducers
{
    public static class SetCombatantsReducer
    {
        [ReducerMethod]
        public static CombatState ReduceSetCombatantsAction(CombatState state, SetCombatantsAction action) => new(new(action.CombatantNames), state.CurrentErrorMessage);
    }
}
