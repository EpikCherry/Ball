using UnityEngine;

namespace Limits
{
    [System.Serializable]
    public abstract class LimitGeneric<T>
    {
        [SerializeField] protected T minBound;
        [SerializeField] protected T maxBound;

        public abstract T RandomValue();
    }
}