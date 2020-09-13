using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private Transform target;
    protected Rigidbody2D rb2dAI;
    private float distanceToPlayer;

    private void Start()
    {
        rb2dAI = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Food").GetComponent<Transform>();
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer < visionRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) > 0.1)
        {
            if (transform.position.x < target.position.x)
            {
                rb2dAI.velocity = Vector2.right * speed;
            }

            if (transform.position.x > target.position.x)
            {
                rb2dAI.velocity = Vector2.left * speed;
            }
        }

        if (Mathf.Abs(transform.position.x - target.position.x) < 0.1)
        {
            if (transform.position.y < target.position.y)
            {
                rb2dAI.velocity = Vector2.up * speed;
            }

            if (transform.position.y > target.position.y)
            {
                rb2dAI.velocity = Vector2.down * speed;
            }
        }
    }

    private void StopChasingPlayer()
    {
        rb2dAI.velocity = new Vector2(0, 0);
    }
}
