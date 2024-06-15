using Backend.Models;
using Fluxor;

namespace Backend.Store.State
{
    [FeatureState]
    public class CombatState
    {
        private CombatState() { Combatants = []; CurrentCombatant = -1; } // Required for creating initial state

        public CombatState(List<Combatant> combatants, int currentCombatant)
        {
            Combatants = combatants;
            CurrentCombatant = currentCombatant;
        }

        public List<Combatant> Combatants { get; }
        public int CurrentCombatant { get; }
    }
}
