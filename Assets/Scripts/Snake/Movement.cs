using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] public static float speed = 1f;

        private Rigidbody2D rb2d;
        private Vector2 position;
        private readonly float speedRotation = 20f;
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
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
                    break;
                case 1:
                    rb2d.velocity = Vector2.down * speed;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), speedRotation * Time.deltaTime);
                    break;
                case 2:
                    rb2d.velocity = Vector2.left * speed;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), speedRotation * Time.deltaTime);
                    break;
                case 3:
                    rb2d.velocity = Vector2.right * speed;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);
                    break;
                default:
                    Debug.Log("Nothing");
                    break;
            }
        }
    }
}
