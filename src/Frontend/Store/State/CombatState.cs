using Fluxor;

namespace Frontend.Store.State
{
    [FeatureState]
    public class CombatState
    {
        private CombatState() { CombatantNames = [];  } // Required for creating initial state

        public CombatState(List<string> combatantNames, string? currentErrorMessage)
        {
            CombatantNames = combatantNames;
            CurrentErrorMessage = currentErrorMessage;
        }

        public List<string> CombatantNames { get; }

        public string? CurrentErrorMessage { get; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
    }
}
