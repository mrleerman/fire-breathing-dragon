using System;
using Backend.Models;

namespace Backend.Extensions
{
    public static class ListExtensions
    {
        public static int AddCombatant(this List<Combatant> combatants, string combatantName, int combatantInitiativeBonus)
        {
            var newCombatant = new Combatant()
            {
                Name = combatantName,
                Initiative = new Random().Next(1, 21) + combatantInitiativeBonus,
                InitiativeBonus = combatantInitiativeBonus
            };

            // TODO: Swap to a better search algorithm for locating the correct slot if analysis shows slugishness here.

            var combatantSlot = 0;
            foreach (var combatant in combatants)
            {
                if (newCombatant.Initiative > combatant.Initiative)
                {
                    break;
                }
                ++combatantSlot;
            }

            combatants.Insert(combatantSlot, newCombatant);

            return combatantSlot;
        }

        public static int FindIndexOf(this List<Combatant> combatants, string combatantName)
        {
            var combatantSlot = 0;
            foreach (var combatant in combatants)
            {
                if (string.Compare(combatant.Name, combatantName, true) == 0)
                {
                    return combatantSlot;
                }
                ++combatantSlot;
            }

            return -1;
        }

        public static List<string> OrderByInitiative(this List<Combatant> combatants, int startingAt)
        {
            var combatantNames = new List<string>(combatants.Count);

            // Combatant display list should start at combatant currently taking their turn, continue to the end of the list, then wrap around to the beginning
            if (combatants.Count > 0)
            {
                // Start with the current combatant and add everyone after them...
                for (int i = startingAt; i < combatants.Count; ++i)
                {
                    combatantNames.Add(combatants[i].Name);
                }

                // ... then append anyone that has already taken their turn
                for (int i = 0; i < startingAt; ++i)
                {
                    combatantNames.Add(combatants[i].Name);
                }
            }

            return combatantNames;
        }
    }
}
