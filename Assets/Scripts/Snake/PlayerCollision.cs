using UnityEngine;
using UnityEngine.Events;
using Snake;
using Food;
using UI;

public class PlayerCollision : MonoBehaviour
{
    public SnakeTail SnakeTail;
    public Movement Movement;

    public UnityEvent OnEat;

    public event UnityAction<int> ScoreChanged;

    private int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            Debug.Log("FOOD");
            scoreValue++;
            ScoreChanged?.Invoke(scoreValue);
            collision.GetComponent<IsEating>().OnHit();
            SnakeTail.MakeNode();
            Movement.Speed += 0.05f;

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
            Debug.Log("BOXCollider");
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            Debug.Log("NODETail");
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<LevelComplete>())
        {
            Debug.Log("LEVELComplete");
            MenuManager.Instance.GameWon();
        }
    }
}
