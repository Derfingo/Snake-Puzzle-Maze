using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    public UnityEvent OnEat;

    [SerializeField] private Transform SnakeHead;
    [SerializeField] private float CircleDiameter = 0.25f;
    private Vector2Int gridPosition;
    private Rigidbody2D rb2d;
    private bool isEating = false;
    private int move;

    private static int intialLenScore = 0;
    public static int LengthTail = intialLenScore;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> crsPositions = new List<Vector2>();
   
    private void Awake()
    {
        //starting position snake
        gridPosition = new Vector2Int(0, 0);
        transform.position = new Vector2(gridPosition.x, gridPosition.y);
    }

    private void Start()
    {
        LengthTail = intialLenScore;
        rb2d = GetComponent<Rigidbody2D>();
        crsPositions.Add(SnakeHead.position);
        AddCircle();
    }

    private void Update()
    {
        SnakeTail();
    }

    private void SnakeTail()
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

    private void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.TryGetComponent(out SpawnFood food))
        //{
        //    isEating = true;
        //    Destroy(collision.gameObject);
        //    AddCircle();
        //    IncreaseVelocityPlayer();

        //    if (OnEat != null)
        //    {
        //        OnEat.Invoke();
        //    }
        //}

        if (collision.gameObject.tag == "Food")
        {
            isEating = true;
            Destroy(collision.gameObject);
            AddCircle();
            IncreaseVelocityPlayer();

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

    private float IncreaseVelocityPlayer()
    {
        return GetComponent<SnakeMovement>().RunSpeed += 0.10f;
    }
}

    
