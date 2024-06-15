namespace Backend.Store.Features.Combat.Actions.RemoveCombatant
{
    internal class RemoveCombatantAction(string combatantName)
    {
        public string CombatantName { get; } = combatantName;

        // TODO: TRACK CLIENT THAT REQUESTED COMBATANT FOR NOTIFICATION
    }
}
