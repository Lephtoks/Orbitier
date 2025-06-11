#nullable enable
using System;
using System.Collections.Generic;
using Game.Scripts.World;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.Render
{
    public class ObjectRenderer : MonoBehaviour
    {
        public static readonly List<DrawableObject> DRAWABLES = new List<DrawableObject>();
        public static WorldMap? Map;
        
        
        // Net Lines
        private Material netLineMaterial = null!;
        private Camera mainCamera = null!;

        public static ObjectRenderer instance;
        public Material Material;

        private void OnPostRender()
        {
            GL.PushMatrix();
            GL.LoadProjectionMatrix(mainCamera.projectionMatrix);
            GL.modelview = mainCamera.worldToCameraMatrix;
            foreach (var drawable in DRAWABLES)
            {
                drawable.GetRenderProvider().Render();
            }
            GL.PopMatrix();
            
            if (Map != null)
            {
                foreach (var link in Map.ActiveLinks)
                {
                    DrawDashedLine(link.From.GetPos(), link.InterpolatedEnd, link.Color.WithAlpha(0.2f), link.Color.WithAlpha(0.5f), 1, 1, 1, 0.6f);
                }
            }
        }

        private void Start()
        {
            instance = this;
            mainCamera = Camera.main ?? throw new InvalidOperationException("Main camera not set");
            Material = new Material(Shader.Find("Unlit/Texture"));
        }

        public static void HideObject(DrawableObject drawableObject)
        {
            DRAWABLES.Remove(drawableObject);
        }

        public static void ShowObject(DrawableObject drawableObject)
        {
            DRAWABLES.Add(drawableObject);
        }
        
        

        private void DrawDashedLine(Vector3 from, Vector3 to, Color mainColor, Color secondaryColor, float speed, float gapSize, float lineSize, float thickness)
        {
            if (netLineMaterial == null)
                CreateMaterial();
            
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            netLineMaterial.SetPass(0);
            GL.PushMatrix();
        
            GL.LoadIdentity();
            GL.MultMatrix(mainCamera.worldToCameraMatrix);
            GL.LoadProjectionMatrix(mainCamera.projectionMatrix);
            
            
            DrawThickLine(from, to, thickness, mainColor);
            
            var direction = (to - from).normalized;
            var gap = direction * gapSize;
            var lenght = direction * lineSize;
            var offset = from;

            offset -= direction * (-speed * Time.time % (gapSize + lineSize)) + lenght;
            
            if (direction.IsSameDirection(offset - from)) DrawThickLine(from, offset, thickness, secondaryColor);

            offset += gap;
            while (true)
            {
                var end = offset + lenght;

                if ((end - from).sqrMagnitude >= (to - from).sqrMagnitude)
                {
                    if (direction.IsSameDirection(to - offset)) DrawThickLine(offset, to, thickness, secondaryColor);
                    break;
                }
                
                DrawThickLine(offset, end, thickness, secondaryColor);
                offset += gap + lenght;
            }




            GL.PopMatrix();
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        private void DrawThickLine(Vector3 start, Vector3 end, float thickness, Color lineColor)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 direction = (end - start).normalized;
            Vector3 perpendicular = Vector3.Cross(direction, cameraForward).normalized * thickness * 0.5f;

            GL.Begin(GL.QUADS);
            netLineMaterial.SetPass(0);
            GL.Color(lineColor);
        
            GL.Vertex(start - perpendicular);
            GL.Vertex(start + perpendicular);
            GL.Vertex(end + perpendicular);
            GL.Vertex(end - perpendicular);
        
            GL.End();
        }
        
        void CreateMaterial()
        {
            var shader = Shader.Find("Hidden/Internal-Colored");
            netLineMaterial = new Material(shader)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            netLineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            netLineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            netLineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            netLineMaterial.SetInt("_ZWrite", 0);
        }
    }
}