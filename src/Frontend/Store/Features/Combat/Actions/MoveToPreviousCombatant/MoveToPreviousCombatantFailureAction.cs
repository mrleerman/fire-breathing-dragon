namespace Frontend.Store.Features.Combat.Actions.MoveToPreviousCombatant
{
    public class MoveToPreviousCombatantFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
