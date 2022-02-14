﻿using System.Collections.Generic;

namespace DungeonCrawl.Actors.Items
{
    public class Inventory
    {
        public List<Item> itemList;
        public Inventory()
        {
            itemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }
        public void RemoveItem(Item item)
        {
            itemList.Remove(item);
        }
    }
}
