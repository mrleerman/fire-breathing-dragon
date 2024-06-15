namespace Backend.Store.Features.Combat.Actions.AddCombatant
{
    public class StoreUniqueCombatantAction(string combatantName, int combatantInitiativeBonus)
    {
        public string CombatantName { get; } = combatantName;
        public int CombatantInitiativeBonus { get; } = combatantInitiativeBonus;
    }
}
