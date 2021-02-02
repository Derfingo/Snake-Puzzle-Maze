using UnityEngine;
using Snake;

namespace TouchControll
{
    public class TouchController : MonoBehaviour
    {
        public Movement movement;

        [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
        [SerializeField] private float swipeThreshold = 20f;

        //private const float inchesToCentimeters = 2.54f;

        private enum SwipeDirection { Up, Down, Left, Right };

        private Vector2 fingerDown;
        private Vector2 fingerUp;

        private float VerticalMove => Mathf.Abs(fingerDown.y - fingerUp.y);
        private float HorizontalMove => Mathf.Abs(fingerDown.x - fingerUp.x);

        //public float ScreenPixelsPerCm
        //{
        //    get
        //    {
        //        float fallBackDpi = 160f;
        //        return Screen.dpi == 0f ? fallBackDpi / inchesToCentimeters : Screen.dpi / inchesToCentimeters;
        //    }
        //}

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
                        DefineSwipeDirection();
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    DefineSwipeDirection();
                }
            }
        }

        private void DefineSwipeDirection()
        {
            if (VerticalMove > swipeThreshold && VerticalMove > HorizontalMove)
            {
                int verticalDirection = movement.CurDirection;

                if (fingerDown.y - fingerUp.y > 0 && verticalDirection != 1)
                {
                    movement.CurDirection = (int)SwipeDirection.Up;
                }

                if (fingerDown.y - fingerUp.y < 0 && verticalDirection != 0)
                {
                    movement.CurDirection = (int)SwipeDirection.Down;
                }
            }

            if (HorizontalMove > swipeThreshold && HorizontalMove > VerticalMove)
            {
                int horizontalDirection = movement.CurDirection;

                if (fingerDown.x - fingerUp.x < 0 && horizontalDirection != 3)
                {
                    movement.CurDirection = (int)SwipeDirection.Left;
                }

                if (fingerDown.x - fingerUp.x > 0 && horizontalDirection != 2)
                {
                    movement.CurDirection = (int)SwipeDirection.Right;
                }
            }
        }
    }
}
