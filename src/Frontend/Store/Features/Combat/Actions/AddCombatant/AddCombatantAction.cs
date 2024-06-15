
namespace Frontend.Store.Features.Combat.Actions.AddCombatant
{
    public class AddCombatantAction(string combatantName, int combatantInitiativeBonus)
    {
        public string CombatantName { get; } = combatantName;
        public int CombatantInitiativeBonus { get; } = combatantInitiativeBonus;
    }
}
