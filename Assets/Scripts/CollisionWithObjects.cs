using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.WSA.Input;

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
            velocitySnake.IncreaseRunSnake();

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.GetComponent<BoxCollider2D>())
        {
            MenuManager.OnGameOver();
        }

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            MenuManager.OnGameOver();
        }

        if (collision.gameObject.GetComponent<CapsuleCollider2D>())
        {
            Debug.Log("Collision");
        }
    }
}
