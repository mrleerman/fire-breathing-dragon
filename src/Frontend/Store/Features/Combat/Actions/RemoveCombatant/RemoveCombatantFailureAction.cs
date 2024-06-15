namespace Frontend.Store.Features.Combat.Actions.RemoveCombatant
{
    public class RemoveCombatantFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
