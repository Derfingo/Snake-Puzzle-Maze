using UnityEngine;
using Snake;

public class TouchController : MonoBehaviour
{
    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float swipeThreshold = 20f;

    public Movement movement;

    private Vector2 fingerDown;
    private Vector2 fingerUp;

    private float VerticalMove => Mathf.Abs(fingerDown.y - fingerUp.y);
    private float HorizontalMove => Mathf.Abs(fingerDown.x - fingerUp.x);

    private void FixedUpdate()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDown = touch.position;
                fingerUp = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    DefineDirectionSwipe();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                DefineDirectionSwipe();
            }
        }
    }

    private void DefineDirectionSwipe()
    {
        if (VerticalMove > swipeThreshold && VerticalMove > HorizontalMove)
        {
            if (fingerDown.y - fingerUp.y > 0)
            {
                movement.Move(Movement.Direction.Up);
            }
            else if (fingerDown.y - fingerUp.y < 0)
            {
                movement.Move(Movement.Direction.Down);
            }
        }
        else if (HorizontalMove > swipeThreshold && HorizontalMove > VerticalMove)
        {
            if (fingerDown.x - fingerUp.x > 0)
            {
                movement.Move(Movement.Direction.Right);
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                movement.Move(Movement.Direction.Left);
            }
        }
    }
}
