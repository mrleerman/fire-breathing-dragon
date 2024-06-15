using Backend.Extensions;
using Backend.Models;
using Backend.Store.Features.Combat.Actions.AddCombatant;
using Backend.Store.Features.Combat.Actions.MoveToNextCombatant;
using Backend.Store.Features.Combat.Actions.MoveToPreviousCombatant;
using Backend.Store.Features.Combat.Actions.RemoveCombatant;
using Backend.Store.Features.Combat.Actions.RerollInitiative;
using Backend.Store.State;
using Fluxor;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    public class CombatHub(
        IState<CombatState> combatState,
        IDispatcher fluxorDispatcher) : Hub<IPlayerClient>, ICombatHub
    {
        private readonly IState<CombatState> _combatState = combatState;
        private readonly IDispatcher _fluxorDispatcher = fluxorDispatcher;

        public Task AddCombatant(string combatantName, int combatantInitiativeBonus)
        {
            _fluxorDispatcher.Dispatch(new AddCombatantAction(combatantName, combatantInitiativeBonus));

            return Task.CompletedTask;
        }

        public Task<List<string>> GetCombatants()
        {
            var combatantNames = _combatState.Value.Combatants.OrderByInitiative(_combatState.Value.CurrentCombatant);
            return Task.FromResult(combatantNames);
        }

        public Task MoveToNextCombatant()
        {
            _fluxorDispatcher.Dispatch(new MoveToNextCombatantAction());

            return Task.CompletedTask;
        }

        public Task MoveToPreviousCombatant()
        {
            _fluxorDispatcher.Dispatch(new MoveToPreviousCombatantAction());

            return Task.CompletedTask;
        }

        public Task RemoveCombatant(string combatantName)
        {
            _fluxorDispatcher.Dispatch(new RemoveCombatantAction(combatantName));

            return Task.CompletedTask;
        }

        public Task RerollInitiatives()
        {
            _fluxorDispatcher.Dispatch(new RerollInitiativeAction());

            return Task.CompletedTask;
        }
    }
}
