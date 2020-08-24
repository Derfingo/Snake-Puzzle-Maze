using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private int move;

    public bool detectSwipeOnlyAfterRelease = false;
    public float SwipeThreshold = 20f;
    [Range(0, 3)] public float runSpeed = 1f;

    float VerticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float HorizontalMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }
            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    CheckSwipe();
                }
            }
            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        switch (move)
        {
            case 0:
                rb2d.velocity = Vector2.up * runSpeed;
                break;
            case 1:
                rb2d.velocity = Vector2.right * runSpeed;
                break;
            case 2:
                rb2d.velocity = Vector2.down * runSpeed;
                break;
            case 3:
                rb2d.velocity = Vector2.left * runSpeed;
                break;
        }
        return;
    }

    void CheckSwipe()
    {
        //Check if Vertical swipe
        if (VerticalMove() > SwipeThreshold && VerticalMove() > HorizontalMove())
        {
            if (move != 2 && fingerDown.y - fingerUp.y > 0)//Up swipe
            {
                move = 0;
            }
            else if (move != 0 && fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                move = 2;
            }
        }
        //Check if Horizontal swipe
        else if (HorizontalMove() > SwipeThreshold && HorizontalMove() > VerticalMove())
        {
            if (move != 3 && fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                move = 1;
            }
            else if (move != 1 && fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                move = 3;
            }
        }
    }
}
