namespace Frontend.Store.Features.Combat.Actions.AddCombatant
{
    public class AddCombatantFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
