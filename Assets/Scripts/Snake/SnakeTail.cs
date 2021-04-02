using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private Transform Head;
    [SerializeField] private Transform Node;

    [SerializeField] private float nodeDiameter = 0.28f;

    public Vector2 SnakePosition { get; private set; }

    private readonly List<Transform> snakeNodes = new List<Transform>();
    private readonly List<Vector2> nodesDirection = new List<Vector2>();

    private void Start()
    {
        SnakePosition = transform.position;

        nodesDirection.Add(Head.position);

        nodesDirection.Add(Node.position);
        snakeNodes.Add(Node);

        MakeNode();
        MakeNode();
    }

    private void Update()
    {
        AddNodePosition();
    }

    private void AddNodePosition()
    {
        float distance = Vector2.Distance(Head.position, nodesDirection[0]);

        if (distance > nodeDiameter)
        {
            Vector2 direction = ((Vector2)Head.position - nodesDirection[0]).normalized;
            nodesDirection.Insert(0, nodesDirection[0] + direction * nodeDiameter);
            nodesDirection.RemoveAt(nodesDirection.Count - 1);
            distance -= nodeDiameter;
        }

        for (int i = 0; i < snakeNodes.Count; i++)
        {
            snakeNodes[i].position = Vector2.Lerp(nodesDirection[i + 1], nodesDirection[i], distance / nodeDiameter);
        }
    }

    public void MakeNode()
    {
        Transform newNode = Instantiate(Node, nodesDirection[nodesDirection.Count - 1], Quaternion.identity, transform);
        snakeNodes.Add(newNode);
        nodesDirection.Add(newNode.position);
    }
}
