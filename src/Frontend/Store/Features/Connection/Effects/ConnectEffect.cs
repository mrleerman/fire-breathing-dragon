using Fluxor;
using Frontend.Store.Features.Connection.Actions.Connect;
using Frontend.Services.CombatConnection;

namespace Frontend.Store.Features.Connection.Effects
{
    internal class ConnectEffect(ILogger<ConnectEffect> logger, ICombatConnection combatConnection) : Effect<ConnectAction>
    {
        private readonly ILogger<ConnectEffect> _logger = logger;
        private readonly ICombatConnection _combatConnection = combatConnection;

        public override async Task HandleAsync(ConnectAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Connecting to Combat Server");

                await _combatConnection.Connect();

                _logger.LogInformation("Connection successfully established");

                dispatcher.Dispatch(new ConnectSuccessAction());
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Error connecting to Combat Server");
                dispatcher.Dispatch(new ConnectFailureAction(e.Message));
            }
        }
    }
}
