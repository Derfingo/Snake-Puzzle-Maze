using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] protected Transform snakeHead;
    [SerializeField] private float circleDiameter = .25f;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> crsPositions = new List<Vector2>();

    private Vector2 snake;

    public Vector2 GetSnakePosition()
    {
        return snake;
    }

    private void Start()
    {
        crsPositions.Add(snakeHead.position);
        snake = transform.position;
        AddCircle();
        AddCircle();
    }

    private void Update()
    {
        MakeTail();
    }

    private void MakeTail()
    {
        //distance between two vectors
        //float distance = ((Vector2)snakeHead.position - crsPositions[0]).magnitude;
        float distance = Vector2.Distance(snakeHead.position, crsPositions[0]);

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

    public void AddCircle()
    {
        Transform circle = Instantiate(snakeHead, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
        transform.localScale = Vector3.one * .90f;
        circle.localScale = Vector3.one * .85f;
        snakeCircles.Add(circle);
        crsPositions.Add(circle.position);
    }
}
