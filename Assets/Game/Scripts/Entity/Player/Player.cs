using Game.Scripts.data;
using Game.Scripts.Registry;
using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Entity.Player
{
    public class Player : LoadedEntity, IControllable
    {
        public static readonly Model MODEL = OrbitierAssets.GetModel(Identifier.OfVanilla("entities/player"));
        public Player(Vector2 pos) : base(pos, MODEL)
        {
            
        }

        public float getSpeed()
        {
            return 0.3f;
        }
    }
}