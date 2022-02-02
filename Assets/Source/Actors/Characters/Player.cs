using UnityEngine;
using DungeonCrawl.Core;
using DungeonCrawl.Actors.Items;
using System.Collections.Generic;
using Assets.Source.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Player()
        {
            Inventory = new List<Item>();
            Health = 100;
            Damage = 30;
            MedsCount = 0;
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

            if (Input.GetKeyDown(KeyCode.H))
            {
                UseMeds();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //pick up item method
            }
        }

        public override bool OnCollision(Character anotherActor) => false;

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }
        private void UseMeds()
        {
            if (MedsCount > 0 && this.Health != 100)
            {
                Health += 20;
                MedsCount -= 1;
            }
            MedsCount -= 1;
        }
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
