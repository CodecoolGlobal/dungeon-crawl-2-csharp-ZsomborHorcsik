using UnityEngine;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Items;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Player()
        {
            Inventory = new Dictionary<Item, int>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                UseMeds();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }
        private void UseMeds()
        {
            if(MedsCount > 0 && this.Health != 100)
            {
                Health += 20;
                MedsCount -= 1;
            }
            MedsCount -= 1;
        }
        public Dictionary<Item, int> Inventory;
        public int MedsCount;
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
