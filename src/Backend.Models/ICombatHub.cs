namespace Backend.Models
{
    public interface ICombatHub
    {
        Task AddCombatant(string combatantName, int combatantInitiativeBonus);
        Task<List<string>> GetCombatants();
        Task MoveToNextCombatant();
        Task MoveToPreviousCombatant();
        Task RemoveCombatant(string combatantName);
        Task RerollInitiatives();
    }
}
