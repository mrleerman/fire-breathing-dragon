namespace Frontend.Store.Features.Combat.Actions.SetCombatants
{
    public class SetCombatantsAction(List<string> combatantNames)
    {
        public List<string> CombatantNames { get; } = combatantNames;
    }
}
