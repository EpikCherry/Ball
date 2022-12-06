using GameTimer;
using InvokeSystem;
using ObjectPoolSystem;
using StatsManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour, IInvoke
    {
        public static UIManager instance;

        [SerializeField] private TextMeshProUGUI scoreLabel;
        [SerializeField] private TextMeshProUGUI timeLabel;
        
        [SerializeField] private Button buttonPause;
        [SerializeField] private Button buttonNewGame;
        [SerializeField] private GameObject pausePlane;

        private bool _isPaused;
        
        public void SetUp()
        {
            instance = this;
            
            buttonPause.onClick.AddListener(Pause); 
            buttonNewGame.onClick.AddListener(NewGame); 
        }

        public void SetScore(int points)
        {
            scoreLabel.text = points.ToString();
        }

        public void SetTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            
            timeLabel.text = $"{minutes:0}:{seconds:00}";
        }
        
        private void Pause()
        {
            _isPaused = !_isPaused;
            
            pausePlane.SetActive(_isPaused);
            Time.timeScale = _isPaused ? 0 : 1;
        }

        private void NewGame()
        {
            TimerManager.ResetTimer();
            
            StatsManager.Score = 0;
            StatsManager.Timer = 0;

            ObjectPool.instance.ResetAllPools();
        }
    }
}