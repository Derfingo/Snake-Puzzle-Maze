using UnityEngine;
using UnityEngine.Events;

public class CollisionWithObjectsAI : MonoBehaviour
{
    public UnityEvent OnEat;
    [SerializeField] protected SnakeTail tail;
    [SerializeField] protected IsEating isEating;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            collision.GetComponent<IsEating>().OnHit();
            tail.AddNode();

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }
    }
}
