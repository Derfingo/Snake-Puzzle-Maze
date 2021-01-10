using UnityEngine;
using UnityEngine.Events;
using Snake;
using Food;
using UI;

public class CollisionWithObjects : MonoBehaviour
{
    public UnityEvent OnEat;
    public MenuManager MenuManager;
    public event UnityAction<int> ScoreChanged;

    [SerializeField] protected SnakeTail tail;
    [SerializeField] protected Movement velocitySnake;

    private int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            scoreValue++;
            ScoreChanged?.Invoke(scoreValue);
            collision.GetComponent<IsEating>().OnHit();
            tail.AddNode();
            Movement.speed += 0.1f;

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.GetComponent<CompositeCollider2D>())
        {
            MenuManager.OnGameOver();
        }

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            MenuManager.OnGameOver();
        }

        if (collision.gameObject.GetComponent<CapsuleCollider2D>())
        {
            //Debug.Log("Collision");
        }
    }
}
