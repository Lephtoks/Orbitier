using Game.Scripts.Render;
using UnityEngine;

namespace Game.Scripts.Entity
{
    public class LoadedEntity : IModelOwner
    {
        private Vector2 _position;
        protected Model _model;
        protected Vector2 _last_position;

        protected LoadedEntity(Vector2 pos, Model model)
        {
            _position = pos;
            _model = model;
        }

        public Model GetModel()
        {
            return _model;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Vector2 GetModelPosition()
        {
            return _position;
        }

        public void SetPosition(Vector2 pos)
        {
            _last_position = _position;
            _position = pos;
        }
        
    }
}