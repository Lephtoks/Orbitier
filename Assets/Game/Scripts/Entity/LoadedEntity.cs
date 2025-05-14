using Game.Scripts.Render;
using Game.Scripts.Render.renderProviders;
using UnityEngine;

namespace Game.Scripts.Entity
{
    public class LoadedEntity : DrawableObject
    {
        private Vector2 _position;
        protected Model _model;
        protected Vector2 _last_position;

        protected override RenderProvider renderProvider => new ModelRenderProvider(_model, this.GetPosition);

        protected LoadedEntity(Vector2 pos, Model model)
        {
            _position = pos;
            _model = model;
        }

        public Vector2 GetPosition()
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