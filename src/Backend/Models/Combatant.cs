namespace Backend.Models
{
    public class Combatant
    {
        public required string Name { get; set; }
        public int Initiative { get; set; }
        public int InitiativeBonus { get; set; }
    }
}
