using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public TextMeshProUGUI gameTimerUI;
        public TextMeshProUGUI scoreUI;

        public FadePanel fadePanel;
        public GameObject gameoverUI;

        public bool isPlay = false;
        private float playTime;

        public int clearScore = 5;
        private int score = 0;
        public int Score
        {
            get { return score; }
            set { 
                score = value;
                scoreUI.text = $"X {score}";

                if (score >= clearScore)
                {
                    isPlay = false;
                    GameClear();
                }
            }
        }
        
        public void GameClear()
        {
            fadePanel.OnFade(1f, Color.white);
        }

        public void GameOver()
        {
            fadePanel.OnFade(1f, Color.black);
            gameoverUI.SetActive(true);
        }
        

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            Score = 0;
        }

        void Update()
        {
            
            PlayTimerSet();
        }

        private void PlayTimerSet()
        {
            if (!isPlay) return;

            playTime += Time.deltaTime;
            gameTimerUI.text = $"{(int)(playTime / 60):00}:{(int)(playTime % 60):00}";
        }
    }
}
