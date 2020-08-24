using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    public UnityEvent OnEat;
    protected Vector2Int gridPosition;
    protected Rigidbody2D rb2d;
    protected bool isEating = false;
    protected int move;
    public Transform SnakeHead;
    public float CircleDiameter;


    private static int intialLen = 0;
    public static int lengthTail = intialLen;


    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> crsPositions = new List<Vector2>();
   
    void Awake()
    {
        //starting position snake
        gridPosition = new Vector2Int(0, 0);
        transform.position = new Vector2(gridPosition.x, gridPosition.y);


    }

    void Start()
    {
        lengthTail = intialLen;
        rb2d = GetComponent<Rigidbody2D>();
        crsPositions.Add(SnakeHead.position);
        AddCircle();
    }

    void Update()
    {
        //distance between two vectors
        float distance = ((Vector2)SnakeHead.position - crsPositions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Направление от старого положения головы, к новому
            Vector2 direction = ((Vector2)SnakeHead.position - crsPositions[0]).normalized;
            crsPositions.Insert(0, crsPositions[0] + direction * CircleDiameter);
            crsPositions.RemoveAt(crsPositions.Count - 1);
            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(crsPositions[i + 1], crsPositions[i], distance / CircleDiameter);
        }
    }

    void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
        transform.localScale = Vector3.one * .90f;
        circle.localScale = Vector3.one * .85f;
        snakeCircles.Add(circle);
        crsPositions.Add(circle.position);
        lengthTail++;
    }

    void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        crsPositions.RemoveAt(1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            isEating = true;
            Destroy(collision.gameObject);
            AddCircle();
            IncreaseVelocity();
            
            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        isEating = false;

        if (collision.gameObject.tag == "Wall")
        {
            MenuManager.FailGame();
        }
    }

    void IncreaseVelocity()
    {
        if (isEating)
        {
            GetComponent<SnakeMovement>().runSpeed += 0.10f;
        }
    }
}

    
