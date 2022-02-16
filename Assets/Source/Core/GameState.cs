using System.Collections.Generic;
using DungeonCrawl.Actors.Items;

namespace DungeonCrawl.Core
{
    public class GameState
    {
        public int PlayerHealth { get; set; }
        public int PlayerDamage { get; set; }
        public Dictionary<string, int> SavedInventory { get; set; }
        public (int x, int y) SavedPosition { get; set; }
        public GameState(int damage, int health, (int, int) LastPosition, Dictionary<string, int> inventory)
        {
            PlayerHealth = health;
            PlayerDamage = damage;
            SavedPosition = LastPosition;
            SavedInventory = inventory;
        }
    }
}
