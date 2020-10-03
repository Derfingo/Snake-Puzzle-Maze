using UnityEngine;
using UnityEngine.Events;

public class CollisionWithObjects : MonoBehaviour
{
    public UnityEvent OnEat;
    public event UnityAction<int> ScoreChanged;

    [SerializeField] protected SnakeTail tail;
    [SerializeField] protected SnakeMovement velocitySnake;

    private int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            scoreValue++;
            ScoreChanged?.Invoke(scoreValue);
            collision.GetComponent<IsEating>().OnHit();
            tail.AddNode();
            velocitySnake.IncreaseVelocitySnake();

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.GetComponent<BoxCollider2D>())
        {
            MenuManager.FailGame();
        }

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            MenuManager.FailGame();
        }
    }
}
