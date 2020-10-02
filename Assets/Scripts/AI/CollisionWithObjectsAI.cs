using UnityEngine;
using UnityEngine.Events;

public class CollisionWithObjectsAI : MonoBehaviour
{
    public UnityEvent OnEat;
    [SerializeField] protected SnakeTail tail;
    [SerializeField] protected IsEating isEating;
    //[SerializeField] protected SnakeMovement velocitySnake;
    [HideInInspector] public bool OnEating = false;

    private void Start()
    {
        //tail = GameObject.Find("Snake").GetComponent<SnakeTail>();
        //TryGetComponent(out IsEating _);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>() != null)
        {
            OnEating = true;
            collision.GetComponent<IsEating>().OnHit();
            tail.AddNode();

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
