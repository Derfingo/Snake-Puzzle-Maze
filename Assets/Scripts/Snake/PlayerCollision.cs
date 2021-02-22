using UnityEngine;
using UnityEngine.Events;
using Snake;
using Food;
using UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private SnakeTail SnakeTail;
    [SerializeField] private Movement Movement;

    public UnityEvent OnEat;

    public event UnityAction<int> ScoreChanged;

    private int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            scoreValue++;
            ScoreChanged?.Invoke(scoreValue);
            collision.GetComponent<IsEating>().OnHit();
            SnakeTail.MakeNode();
            Movement.Speed += 0.025f;

            if (OnEat != null)    //OnEat?.Invoke();
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.GetComponent<CompositeCollider2D>())
        {
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<BoxCollider2D>())
        {
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<LevelComplete>())
        {
            MenuManager.Instance.GameWon();
        }
    }
}
