﻿using UnityEngine;
using UnityEngine.Events;

public class CollisionWithObjects : MonoBehaviour
{
    [SerializeField] protected SnakeTail tail;
    [SerializeField] private IsEating isEating;
    [SerializeField] protected SnakeMovement velocitySnake;

    public event UnityAction<int> ScoreChanged;
    private int scoreValue = 0;

    public UnityEvent OnEat;

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
