using Fluxor;
using Frontend.Models;

namespace Frontend.Store.State
{
    [FeatureState]
    public class ConnectionState
    {
        private ConnectionState() {} // Required for creating initial state

        public ConnectionState(ClientState clientState, string? currentErrorMessage)
        {
            ClientState = clientState;
            CurrentErrorMessage = currentErrorMessage;
        }

        public ClientState ClientState { get; }
        public string? CurrentErrorMessage { get; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
    }
}
