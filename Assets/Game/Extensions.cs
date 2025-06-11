using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    public static class Extensions
    {
        [Pure]
        
        public static bool IsSameDirection(this Vector3 a, Vector3 b)
        {
            if (a.sqrMagnitude <= Vector3.kEpsilon || b.sqrMagnitude <= Vector3.kEpsilon)
                return false;
        
            Vector3 normA = a.normalized;
            Vector3 normB = b.normalized;
        
            float dot = Vector3.Dot(normA, normB);
        
            return dot >= 1f - Vector3.kEpsilon;
        }
        
    }
}