using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public abstract class Item : Actor
    {
        public int Damage { get; private set; }
    }
}
