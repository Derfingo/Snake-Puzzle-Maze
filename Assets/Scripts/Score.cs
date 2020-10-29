using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private CollisionWithObjects collisionWithObjects;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        collisionWithObjects = GameObject.Find("Head").GetComponent<CollisionWithObjects>();
    }

    private void OnEnable()
    {
        collisionWithObjects.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        collisionWithObjects.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
    }
}
