using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float visionRange = 10f;
    public SpawnFoodForAI foodTarget;
    protected Rigidbody2D rb2dAI;
    private float distanceToPlayer;
    private Vector2 startPosion = new Vector2(0, 1);
    private int move;

    private void Start()
    {
        transform.position = startPosion;
        rb2dAI = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, foodTarget.currentPositionFood);

        if (distanceToPlayer < visionRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
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

    private void ChasePlayer()
    {
        if (Mathf.Abs(transform.position.x - foodTarget.currentPositionFood.x) > 0.1)
        {
            if (transform.position.x < foodTarget.currentPositionFood.x && move != 3)
            {
                move = 1;
                //rb2dAI.velocity = Vector2.right * speed;
            }

            if (transform.position.x > foodTarget.currentPositionFood.x && move != 1)
            {
                move = 3;
                //rb2dAI.velocity = Vector2.left * speed;
            }
        }

        if (Mathf.Abs(transform.position.x - foodTarget.currentPositionFood.x) < 0.1)
        {
            if (transform.position.y < foodTarget.currentPositionFood.y && move != 2)
            {
                move = 0;
                //rb2dAI.velocity = Vector2.up * speed;
            }

            if (transform.position.y > foodTarget.currentPositionFood.y && move != 0)
            {
                move = 2;
                //rb2dAI.velocity = Vector2.down * speed;
            }
        }
    }

    private void StopChasingPlayer()
    {
        rb2dAI.velocity = new Vector2(-2, 0);
    }
}
