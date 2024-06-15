namespace Frontend.Store.Features.Connection.Actions.Connect
{
    public class ConnectFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
