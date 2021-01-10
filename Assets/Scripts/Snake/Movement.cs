using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] public float speed = 1f;

        private Rigidbody2D rb2d;
        private Vector2 position;
        public int CurDirection { get; set; } = 0;

        private void Start()
        {
            position = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
            transform.position = position;
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            switch (CurDirection)
            {
                case 0:
                    rb2d.velocity = Vector2.up * speed;
                    break;
                case 1:
                    rb2d.velocity = Vector2.down * speed;
                    break;
                case 2:
                    rb2d.velocity = Vector2.left * speed;
                    break;
                case 3:
                    rb2d.velocity = Vector2.right * speed;
                    break;
                default:
                    Debug.Log("Nothing");
                    break;
            }
        }

        //rb2d.velocity = Vector3.right * runSpeed;
        //gameObject.transform.Rotate(new Vector3(0, 0, 0));
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);

    }
}
