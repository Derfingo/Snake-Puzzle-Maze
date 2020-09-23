using System.Dynamic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SnakeMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private int move;
    private Vector2 gridPosition;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float swipeThreshold = 20f;
    [SerializeField] [Range(1, 5)] private float runSpeed = 1f;

    public float RunSpeed
    {
        get => runSpeed;
        set => runSpeed = value;
    }

    private void Awake()
    {
        //starting position snake
        gridPosition = new Vector2(0, 0);
        transform.position = new Vector2(gridPosition.x, gridPosition.y);
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        DetectSwipe();
    }

    public void IncreaseVelocitySnake()
    {
        RunSpeed += .1f;
    }

    private void DetectSwipe()
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

    private void Movement()
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
    }

    private void CheckSwipe()
    {
        //Check if Vertical swipe
        if (VerticalMove() > swipeThreshold && VerticalMove() > HorizontalMove())
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
        else if (HorizontalMove() > swipeThreshold && HorizontalMove() > VerticalMove())
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

    private float VerticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    private float HorizontalMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

}
