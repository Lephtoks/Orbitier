using UnityEngine;

namespace Game.Scripts.Render
{
    public interface IModelOwner : IDrawableObject
    {
        void IDrawableObject.Render()
        {
            var model = this.GetModel();
            Graphics.DrawTexture(new Rect(this.GetModelPosition()+model.Offset, model.Size), model.Texture);
        }
        public Model GetModel();

        public Vector2 GetModelPosition();
    }
}