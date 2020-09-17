using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionWithObjects : MonoBehaviour
{
    public UnityEvent OnEat;
    [SerializeField] protected SnakeTail tail;
    [SerializeField] protected IsEating isEating;
    [SerializeField] protected SnakeMovement velocitySnake;
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
            tail.AddCircle();
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
    }

    
}
