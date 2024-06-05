using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private int playerLives = 3;
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int gameScore = 0;

        void Awake()
        {
            int numGameSessions = FindObjectsOfType<GameSession>().Length;
            if (numGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
            livesText.text = playerLives.ToString();
            scoreText.text = gameScore.ToString();
        }

        public void ProcessPlayerDeath()
        {
            if (playerLives > 1)
            {
                TakeLife();
            }
            else
            {
                LoadGameOverScene();
            }
        }

        private void LoadGameOverScene()
        {
            SceneManager.LoadScene("GameOver");
        }

        private void TakeLife()
        {
            playerLives--;
            livesText.text = playerLives.ToString();
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void AddToScore(int pointsToAdd)
        {
            gameScore += pointsToAdd;
            scoreText.text = gameScore.ToString();
        }

        public void AddLife()
        {
            playerLives++;
            livesText.text = playerLives.ToString();
        }
    }
}