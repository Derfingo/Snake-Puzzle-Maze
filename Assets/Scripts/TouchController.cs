using UnityEngine;
using Snake;

public class TouchController : MonoBehaviour
{
    public Movement movement;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float swipeThreshold = 20f;

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
            int verticalDirection = movement.CurDirection;

            //Swipe up
            if (fingerDown.y - fingerUp.y > 0 && verticalDirection != 1)
            {
                movement.CurDirection = 0;
            }
            //Swipe down
            if (fingerDown.y - fingerUp.y < 0 && verticalDirection != 0)
            {
                movement.CurDirection = 1;
            }
        }

        if (HorizontalMove > swipeThreshold && HorizontalMove > VerticalMove)
        {
            int horizontalDirection = movement.CurDirection;

            //Swipe left
            if (fingerDown.x - fingerUp.x < 0 && horizontalDirection != 3)
            {
                movement.CurDirection = 2;
            }
            //Swipe right
            if (fingerDown.x - fingerUp.x > 0 && horizontalDirection != 2)
            {
                movement.CurDirection = 3;
            }
        }
    }
}
