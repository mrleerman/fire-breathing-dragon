namespace Backend.Models
{
    public interface IPlayerClient
    {
        Task CombatantUpdate(List<string> combatantNames);
    }
}
