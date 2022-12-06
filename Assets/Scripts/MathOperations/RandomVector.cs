using UnityEngine;

namespace MathOperations
{
    public static class RandomVector
    {
        public static Vector3 Range(Vector3 first, Vector3 second)
        {
            return new Vector3(
                Random.Range(first.x, second.x), 
                Random.Range(first.y, second.y),
                Random.Range(first.z, second.z));
        }
    }
}