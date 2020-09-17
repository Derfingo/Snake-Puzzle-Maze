using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SnakeController : MonoBehaviour
{
    public UnityEvent OnEat;

    [SerializeField] protected Transform snakeHead;
    [SerializeField] private float circleDiameter = 0.25f;
    
    protected Vector2 snake;
    protected Rigidbody2D rb2d;
    protected bool isEating = false;

    private static int intialLenScore = 0;
    public static int LengthTail = intialLenScore;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> crsPositions = new List<Vector2>();

    public Vector2 GetSnakePosition()
    {
        return snake;
    }

    private void Awake()
    {
        snake = transform.position;
    }

    private void Start()
    {
        LengthTail = intialLenScore;
        rb2d = GetComponent<Rigidbody2D>();
        crsPositions.Add(snakeHead.position);
        AddCircle();
        AddCircle();
    }

    private void Update()
    {
        SnakeTail();
    }

    private void SnakeTail()
    {
        //distance between two vectors
        float distance = ((Vector2)snakeHead.position - crsPositions[0]).magnitude;

        if (distance > circleDiameter)
        {
            // Направление от старого положения головы, к новому
            Vector2 direction = ((Vector2)snakeHead.position - crsPositions[0]).normalized;
            crsPositions.Insert(0, crsPositions[0] + direction * circleDiameter);
            crsPositions.RemoveAt(crsPositions.Count - 1);
            distance -= circleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(crsPositions[i + 1], crsPositions[i], distance / circleDiameter);
        }
    }

    private void AddCircle()
    {
        Transform circle = Instantiate(snakeHead, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
        transform.localScale = Vector3.one * .90f;
        circle.localScale = Vector3.one * .85f;
        snakeCircles.Add(circle);
        crsPositions.Add(circle.position);
        LengthTail++;
    }

    private void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        crsPositions.RemoveAt(1);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Food")
    //    {
    //        isEating = true;
    //        Destroy(collision.gameObject);
    //        AddCircle();
    //        IncreaseVelocityPlayer();

    //        if (OnEat != null)
    //        {
    //            OnEat.Invoke();
    //        }
    //    }

    //    isEating = false;

    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        MenuManager.FailGame();
    //    }
    //}

}

    
