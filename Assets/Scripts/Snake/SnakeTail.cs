using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeTail : MonoBehaviour
    {
        public Transform Node1;
        public Transform Node2;

        [SerializeField] protected Transform head;
        [SerializeField] protected Transform nodePrefab;
        [SerializeField] protected float circleDiameter = 0.25f;

        protected List<Transform> snakeCircles = new List<Transform>();
        protected List<Vector2> crsPositions = new List<Vector2>();
        protected Vector2 snakePosition;

        public Vector2 GetSnakePosition => snakePosition;

        private void Start()
        {
            snakePosition = transform.position;

            crsPositions.Add(Node1.position);
            snakeCircles.Add(Node1);
            crsPositions.Add(Node2.position);
            snakeCircles.Add(Node2);

            crsPositions.Add(nodePrefab.position);
        }

        private void Update()
        {
            MakeTail();
        }

        private void MakeTail()
        {
            float distance = Vector2.Distance(head.position, crsPositions[0]);

            if (distance > circleDiameter)
            {
                Vector2 direction = ((Vector2)head.position - crsPositions[0]).normalized;
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
            Transform newNode = Instantiate(nodePrefab, crsPositions[crsPositions.Count - 1], Quaternion.identity, transform);
            
            snakeCircles.Add(newNode);
            crsPositions.Add(newNode.position);
        }
    }
}
