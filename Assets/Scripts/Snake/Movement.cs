using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public Rigidbody2D rb2d;
        private readonly float speedRotation = 2f;

        private float speed = 1f;
        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        private int curDirection = 0;
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
            Rotate();
        }

        private void Move()
        {
            switch (curDirection)
            {
                case 0:
                    rb2d.velocity = Vector2.up * speed;
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
                    break;
                case 1:
                    rb2d.velocity = Vector2.down * speed;
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), speedRotation * Time.deltaTime);
                    break;
                case 2:
                    
                    rb2d.velocity = Vector2.left * speed;
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), speedRotation * Time.deltaTime);
                    break;
                case 3:
                    rb2d.velocity = Vector2.right * speed;
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);
                    break;
            }
        }

        private void Rotate()
        {
            switch (curDirection)
            {
                case 0:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
                    break;
                case 1:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), speedRotation * Time.deltaTime);
                    break;
                case 2:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), speedRotation * Time.deltaTime);
                    break;
                case 3:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);
                    break;
            }
        }
    }
}
