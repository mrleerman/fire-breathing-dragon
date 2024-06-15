using Fluxor;
using Frontend.Models;
using Frontend.Store.Features.Connection.Actions.Connect;
using Frontend.Store.State;

namespace Frontend.Store.Features.Connection.Reducers
{
    public static class ConnectActionsReducer
    {
        [ReducerMethod(typeof(ConnectAction))]
        public static ConnectionState ReduceConnectAction(ConnectionState _) => new(ClientState.Connecting, null);

        [ReducerMethod(typeof(ConnectSuccessAction))]
        public static ConnectionState ReduceConnectSuccessAction(ConnectionState _) => new(ClientState.Connected, null);

        [ReducerMethod]
        public static ConnectionState ReduceConnectFailureAction(ConnectionState _, ConnectFailureAction action) => new(ClientState.Connecting, action.ErrorMessage);
    }
}
