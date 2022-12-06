using UnityEngine;

namespace Limits
{
    [System.Serializable]
    public class LimitFloat : LimitGeneric<float>
    {
        public float Min => minBound;
        public float Max => maxBound;
        
        public override float RandomValue()
        {
            return Random.Range(minBound, maxBound);
        }
    }
}