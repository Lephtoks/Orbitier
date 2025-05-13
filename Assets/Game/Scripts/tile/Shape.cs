using System;
using UnityEngine;

namespace Game.Scripts.tile
{
    public class Shape
    {
        private readonly Vector2[] _vertices;

        public Shape(params Vector2[] position)
        {
            var vertices = new Vector2[position.Length + 1];
            Array.Copy(position, vertices, position.Length);
            vertices[^1] = position[0];
            _vertices = vertices;
        }
        public bool IsIn(Vector2 position, Vector2 point)
        {
            int intersections = 0;
            for (int i = 0; i < _vertices.Length - 1; i++)
            {
                Vector2 v1 = _vertices[i] + position;
                Vector2 v2 = _vertices[i + 1] + position;

                // Проверка, лежит ли точка на ребре
                if (IsPointOnSegment(v1, v2, point))
                    return true;

                // Проверка пересечения луча с ребром
                if ((v1.y > point.y) != (v2.y > point.y))
                {
                    float xIntersection = (point.y - v1.y) * (v2.x - v1.x) / (v2.y - v1.y) + v1.x;
                    if (point.x < xIntersection)
                    {
                        intersections++;
                    }
                }
            }
            return intersections % 2 == 1;
        }

        private bool IsPointOnSegment(Vector2 a, Vector2 b, Vector2 point)
        {
            // Проверка коллинеарности
            float cross = (point.x - a.x) * (b.y - a.y) - (point.y - a.y) * (b.x - a.x);
            if (Mathf.Abs(cross) > Mathf.Epsilon)
                return false;

            // Проверка, что точка находится между a и b
            float dot = (point.x - a.x) * (b.x - a.x) + (point.y - a.y) * (b.y - a.y);
            if (dot < 0)
                return false;

            float squaredLength = (b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y);
            if (dot > squaredLength)
                return false;

            return true;
        }
        public Vector2[] GetVertices() { return _vertices; }
    }
}