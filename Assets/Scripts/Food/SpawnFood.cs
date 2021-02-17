using UnityEngine;
using Snake;

namespace Food
{
    public class SpawnFood : MonoBehaviour
    {
        [SerializeField] private SnakeTail Snake;
        [SerializeField] private GameObject FoodPrefab;
        [SerializeField] private BoxCollider2D boxCollider2D;

        private Vector2 foodPosition;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 0.1f, 3f);  //spawn food every 3 seconds, starting in 0.1
        }

        private void Update()
        {
            MakeFoodPosition();
        }

        private void MakeFoodPosition()
        {
            foodPosition = new Vector2(Random.Range(boxCollider2D.bounds.min.x + 0.5f, boxCollider2D.bounds.max.x - 0.5f),
                                       Random.Range(boxCollider2D.bounds.min.y + 0.5f, boxCollider2D.bounds.max.y - 0.5f));
        }

        private float DistanceFoodToPlayer()
        {
            float distance = Vector2.Distance(foodPosition, Snake.SnakePosition);

            return distance;
        }

        private void Spawn()
        {
            if (DistanceFoodToPlayer() > 1f)
            {
                Instantiate(FoodPrefab, foodPosition, Quaternion.identity, transform);
            }
            else
            {
                return;
            }
        }
    }
}
