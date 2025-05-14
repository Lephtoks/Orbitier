using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Render
{
    public class ObjectRenderer : MonoBehaviour
    {
        public static readonly List<DrawableObject> DRAWABLES = new List<DrawableObject>();
        public Rect tileRect;
        public Texture tileTexture;

        private void OnRenderObject()
        {
            foreach (var drawable in DRAWABLES)
            {
                drawable.GetRenderProvider().Render();
            }
        }

        public static void HideObject(DrawableObject drawableObject)
        {
            DRAWABLES.Remove(drawableObject);
        }

        public static void ShowObject(DrawableObject drawableObject)
        {
            DRAWABLES.Add(drawableObject);
        }
    }
}