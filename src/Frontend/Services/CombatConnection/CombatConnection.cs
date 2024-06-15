using Backend.Models;
using Fluxor;
using Frontend.Exceptions;
using Frontend.Options;
using Frontend.Store.Features.Combat.Actions.SetCombatants;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;


namespace Frontend.Services.CombatConnection
{
    internal interface ICombatConnection
    {
        Task AddCombatant(string combatantName, int combatantInitiativeBonus);

        Task Connect();

        Task MoveToNextCombatant();

        Task MoveToPreviousCombatant();

        Task RemoveCombatant(string combatantName);

        Task RerollInitiatives();
    }

    internal class CombatConnection(
        ILogger<CombatConnection> logger,
        IDispatcher fluxorDispatcher,
        IOptions<ConnectionOptions> options) : ICombatConnection
    {
        private readonly ILogger<CombatConnection> _logger = logger;
        private readonly IDispatcher _fluxorDispatcher = fluxorDispatcher;
        private readonly ConnectionOptions _options = options.Value;
        
        private HubConnection? hubConnection;

        public async Task AddCombatant(string combatantName, int combatantInitiativeBonus)
        {
            if (hubConnection is null)
            {
                throw new ServerNotConnectedException();
            }

            await hubConnection.InvokeAsync(nameof(ICombatHub.AddCombatant), combatantName, combatantInitiativeBonus);
        }

        public async Task Connect()
        {
            var uriBuilder = new UriBuilder(_options.BaseUrl)
            {
                Path = _options.CombatHubRoute
            };

            hubConnection = new HubConnectionBuilder()
                .WithUrl(uriBuilder.Uri)
                .Build();

            hubConnection.On(nameof(IPlayerClient.CombatantUpdate), (List<string> combatantNames) =>
            {
                _fluxorDispatcher.Dispatch(new SetCombatantsAction(combatantNames));
            });

            await hubConnection.StartAsync();

            var combatantNames = await hubConnection.InvokeAsync<List<string>>(nameof(ICombatHub.GetCombatants));
            _fluxorDispatcher.Dispatch(new SetCombatantsAction(combatantNames));
        }

        public async Task MoveToNextCombatant()
        {
            if (hubConnection is null)
            {
                throw new ServerNotConnectedException();
            }

            await hubConnection.InvokeAsync(nameof(ICombatHub.MoveToNextCombatant));
        }

        public async Task MoveToPreviousCombatant()
        {
            if (hubConnection is null)
            {
                throw new ServerNotConnectedException();
            }

            await hubConnection.InvokeAsync(nameof(ICombatHub.MoveToPreviousCombatant));
        }

        public async Task RemoveCombatant(string combatantName)
        {
            if (hubConnection is null)
            {
                throw new ServerNotConnectedException();
            }

            await hubConnection.InvokeAsync(nameof(ICombatHub.RemoveCombatant), combatantName);
        }

        public async Task RerollInitiatives()
        {
            if (hubConnection is null)
            {
                throw new ServerNotConnectedException();
            }

            await hubConnection.InvokeAsync(nameof(ICombatHub.RerollInitiatives));
        }
    }
}
