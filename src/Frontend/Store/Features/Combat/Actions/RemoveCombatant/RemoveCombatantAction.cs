
namespace Frontend.Store.Features.Combat.Actions.RemoveCombatant
{
    public class RemoveCombatantAction(string combatantName)
    {
        public string CombatantName { get; } = combatantName;
    }
}
