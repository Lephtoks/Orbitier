using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Render
{
    public class ObjectRenderer : MonoBehaviour
    {
        public static readonly List<IDrawableObject> DRAWABLES = new List<IDrawableObject>();
        public Rect tileRect;
        public Texture tileTexture;

        private void OnRenderObject()
        {
            foreach (var drawable in DRAWABLES)
            {
                drawable.Render();
            }
        }

        public static void HideObject(IDrawableObject drawableObject)
        {
            DRAWABLES.Remove(drawableObject);
        }

        public static void ShowObject(IDrawableObject drawableObject)
        {
            DRAWABLES.Add(drawableObject);
        }
    }
}