using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Entity.Player
{
    public class Player : LoadedEntity, IControllable
    {
        public static readonly Model MODEL = Model.Of("Tiles/Square", 6, 6, 0, 0);
        public Player(Vector2 pos) : base(pos, MODEL)
        {
            
        }

        public float getSpeed()
        {
            return 0.3f;
        }
    }
}