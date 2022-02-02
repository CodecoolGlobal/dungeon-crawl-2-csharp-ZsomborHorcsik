using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl.Actors.Items
{
    public class Inventory
    {
        private List<Item> itemList;
        public Inventory()
        {
            itemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }
    }
}
