namespace Backend.Store.Features.Combat.Actions.RemoveCombatant
{
    public class DropStoredCombatantAction(string combatantName)
    {
        public string CombatantName { get; } = combatantName;
    }
}
