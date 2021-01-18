using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class Score : MonoBehaviour
    {
        public PlayerCollision playerCollision;
        public Text scoreText;

        private void Start()
        {
            //playerCollision = GameObject.Find("Head").GetComponent<PlayerCollision>();
        }

        private void OnEnable()
        {
            playerCollision.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            playerCollision.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
