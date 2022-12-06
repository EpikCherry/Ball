using UI;
using UnityEngine;

namespace StatsManagement
{
    public class StatsManager
    {
        private static int score = 0;
        public static int Score
        {
            get => score;
            set
            {
                score = value;
                UIManager.instance.SetScore(score);
            }
        }
        
        private static float timer = 0f;
        public static float Timer
        {
            get => timer;
            set
            {
                timer = value;
                UIManager.instance.SetTime(timer);
            }
        }
    }
}