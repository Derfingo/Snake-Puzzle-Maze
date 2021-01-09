using System.Collections.Generic;
using UnityEngine;
using Snake;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public SnakeTail tail;
    public SpawnFoodForAI foodTarget;
    protected Rigidbody2D rb2dAI;
    private float distanceToPlayer;
    private Vector2 startPosion = new Vector2(0, 1);
    private int move;
    private Vector2 newTarget;

    private void Start()
    {
        transform.position = startPosion;
        rb2dAI = GetComponent<Rigidbody2D>();
        newTarget = foodTarget.currentPositionFood;
    }

    private void Update()
    {
        if (newTarget != null)
        {
            FollowFood();
        }
        else
        {
            newTarget = foodTarget.currentPositionFood;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        switch (move)
        {
            case 0:
                rb2dAI.velocity = Vector2.up * speed;
                break;
            case 1:
                rb2dAI.velocity = Vector2.right * speed;
                break;
            case 2:
                rb2dAI.velocity = Vector2.down * speed;
                break;
            case 3:
                rb2dAI.velocity = Vector2.left * speed;
                break;
        }
    }

    private void FollowFood()
    {
        distanceToPlayer = Vector2.Distance(transform.position, foodTarget.currentPositionFood);

        if (Mathf.Abs(transform.position.x - foodTarget.currentPositionFood.x) > 0.1)
        {
            if (transform.position.x < foodTarget.currentPositionFood.x && move != 3)
            {
                move = 1; // right
            }

            if (transform.position.x > foodTarget.currentPositionFood.x && move != 1)
            {
                move = 3; // left
            }
        }

        if (Mathf.Abs(transform.position.x - foodTarget.currentPositionFood.x) < 0.1)
        {
            if (transform.position.y < foodTarget.currentPositionFood.y && move != 2)
            {
                move = 0; // up
            }

            if (transform.position.y > foodTarget.currentPositionFood.y && move != 0)
            {
                move = 2; // down
            }
        }
    }

    
}
