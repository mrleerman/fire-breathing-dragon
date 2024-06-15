namespace Backend.Store.Features.Combat.Actions.AddCombatant
{
    internal class AddCombatantAction(string combatantName, int combatantInitiativeBonus)
    {
        public string CombatantName { get; } = combatantName;
        public int CombatantInitiativeBonus { get; } = combatantInitiativeBonus;

        // TODO: TRACK CLIENT THAT REQUESTED COMBATANT FOR NOTIFICATION
    }
}
