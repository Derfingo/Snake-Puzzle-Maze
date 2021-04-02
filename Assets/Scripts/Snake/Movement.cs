using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        private float speed = 100f;
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

        //private float delta = 0.020f;

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
            //Vector2 cos = rb2d.position;

            switch (curDirection)
            {
                case 0:
                    rb2d.velocity = Vector3.up * speed * Time.deltaTime;
                    //cos.x += delta * Mathf.Sin(Time.fixedTime * 5f);
                    //rb2d.position = cos;
                    break;
                case 1:
                    rb2d.velocity = Vector3.down * speed * Time.deltaTime;
                    //cos.x += delta * Mathf.Sin(Time.fixedTime * 5f);
                    //rb2d.position = cos;
                    break;
                case 2:
                    rb2d.velocity = Vector3.left * speed * Time.deltaTime;
                    //cos.y -= delta * Mathf.Sin(Time.fixedTime * 5f);
                    //rb2d.position = cos;
                    break;
                case 3:
                    rb2d.velocity = Vector3.right * speed * Time.deltaTime;
                    //cos.y -= delta * Mathf.Sin(Time.fixedTime * 5f);
                    //rb2d.position = cos;
                    break;
                case 4:
                    rb2d.velocity = Vector3.zero;
                    break;
            }

            //Debug.Log(cos);
        }
    }
}
