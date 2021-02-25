using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        private float speed = 50f;
        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        private int curDirection = 4;
        public int CurDirection
        {
            get => curDirection;
            set => curDirection = value;
        }

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            switch (curDirection)
            {
                case 0:
                    rb2d.velocity = Vector3.up * speed * Time.deltaTime;
                    break;
                case 1:
                    rb2d.velocity = Vector3.down * speed * Time.deltaTime;
                    break;
                case 2:
                    rb2d.velocity = Vector3.left * speed * Time.deltaTime;
                    break;
                case 3:
                    rb2d.velocity = Vector3.right * speed * Time.deltaTime;
                    break;
                case 4:
                    rb2d.velocity = Vector3.zero;
                    break;
            }
        }
    }
}
