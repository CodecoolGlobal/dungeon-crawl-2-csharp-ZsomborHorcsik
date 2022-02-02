using DungeonCrawl.Core;
using DungeonCrawl.Actors.Items;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; set; }
        public int Damage { get; set; }

        public void ApplyDamage(int damageByEnemy)
        {
            Health -= damageByEnemy;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        public void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                Position = targetPosition;
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    Position = targetPosition;
                    if (actorAtTargetPosition is Item)
                    {
                        // need to reach player's inventory to add Item
                        ActorManager.Singleton.DestroyActor(actorAtTargetPosition);
                    }
                }
            }
        }
    }
}
