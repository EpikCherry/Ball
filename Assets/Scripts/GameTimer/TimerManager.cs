using StatsManagement;
using UnityEngine;

namespace GameTimer
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private float updateInterval = 0.5f;
        
        private static float _timeNow;
        private static float _lastInterval;

        private void Update()
        {
            _timeNow += Time.deltaTime;
            
            if (_timeNow > _lastInterval + updateInterval)
            {
                _lastInterval = _timeNow;
                StatsManager.Timer = _lastInterval;
            }
        }

        public static void ResetTimer()
        {
            _timeNow = 0;
            _lastInterval = 0;
        }
    }
}