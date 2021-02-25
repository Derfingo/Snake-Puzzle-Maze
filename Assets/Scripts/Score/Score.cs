using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private PlayerCollision playerCollision;
        [SerializeField] private Text scoreText;

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
