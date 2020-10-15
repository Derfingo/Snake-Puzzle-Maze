using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float swipeThreshold = 20f;
    [SerializeField] [Range(1, 5)] private float runSpeed = 1f;

    private Rigidbody2D rb2d;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private int move;
    private Vector2 gridPosition;
    private float speedRotation;

    private float VerticalMove => Mathf.Abs(fingerDown.y - fingerUp.y);

    private float HorizontalMove => Mathf.Abs(fingerDown.x - fingerUp.x);

    public float RunSpeed
    {
        private get => runSpeed;
        set => runSpeed = value;
    }

    public void IncreaseRunSnake()
    {
        RunSpeed += .1f;
    }

    private void Start()
    {
        gridPosition = new Vector2(3.5f, 6f);
        transform.position = new Vector2(gridPosition.x, gridPosition.y);
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

    //Vector3 direction = (part0.position - part1.position);
    //transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

    private void Movement()
    {
        speedRotation = 5f * runSpeed;

        switch (move)
        {
            case 0:
                rb2d.velocity = Vector2.up * runSpeed;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
                break;
            case 1:
                rb2d.velocity = Vector2.right * runSpeed;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);
                break;
            case 2:
                rb2d.velocity = Vector2.down * runSpeed;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), speedRotation * Time.deltaTime);
                break;
            case 3:
                rb2d.velocity = Vector2.left * runSpeed;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), speedRotation * Time.deltaTime);
                break;
        }
    }

    private void CheckSwipe()
    {
        //Check if Vertical swipe
        if (VerticalMove > swipeThreshold && VerticalMove > HorizontalMove)
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
        else if (HorizontalMove > swipeThreshold && HorizontalMove > VerticalMove)
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
