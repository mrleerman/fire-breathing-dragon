namespace Frontend.Store.Features.Combat.Actions.RerollInitiative
{
    public class RerollInitiativeFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
