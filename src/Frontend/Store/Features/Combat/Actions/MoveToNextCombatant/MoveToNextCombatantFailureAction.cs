namespace Frontend.Store.Features.Combat.Actions.MoveToNextCombatant
{
    public class MoveToNextCombatantFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
