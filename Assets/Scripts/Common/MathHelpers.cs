using UnityEngine;

namespace Common
{
    public static class MathHelpers
    {
        public static UnityEngine.Vector3 AsDirection(this float angle)
        {
            float radians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(radians);
            float z = Mathf.Sin(radians);
            return new UnityEngine.Vector3(x, 0, z);
        }
    }
}