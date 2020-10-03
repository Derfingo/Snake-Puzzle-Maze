using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] protected Transform snakeHead;
    [SerializeField] protected Transform nodeTail;
    [SerializeField] protected Transform nodeFirst;
    [SerializeField] protected Transform nodeSecond;
    [SerializeField] private float circleDiameter = .25f;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> crsPositions = new List<Vector2>();
    private Vector2 snakePosition;

    public Vector2 GetSnakePosition
    {
        get => snakePosition;
        set => snakePosition = value;
    }

    private void Start()
    {
        snakeHead.position = nodeTail.position;
        crsPositions.Add(nodeTail.position);
        crsPositions.Add(nodeFirst.position);
        snakeCircles.Add(nodeFirst);
        crsPositions.Add(nodeSecond.position);
        snakeCircles.Add(nodeSecond);
        snakePosition = transform.position;
    }

    private void Update()
    {
        MakeTail();
    }

    private void MakeTail()
    {
        float distance = Vector2.Distance(snakeHead.position, crsPositions[0]);

        if (distance > circleDiameter)
        {
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

    public void AddNode()
    {
        Transform circle = Instantiate(nodeTail, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        crsPositions.Add(circle.position);
    }
}
