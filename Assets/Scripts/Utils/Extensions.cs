using UnityEngine;

namespace Utils
{
    public static class Extensions
    {
        public static Vector3Int FlipXZ(this Vector3Int vector)
        {
            return new Vector3Int(vector.z, vector.y, vector.x);
        }
    }
}