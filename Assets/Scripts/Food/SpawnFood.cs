using UnityEngine;
using Snake;

namespace Food
{
    public class SpawnFood : MonoBehaviour
    {
        public SnakeTail Snake;
        public GameObject FoodPrefab;
        public Camera SpawnArea;

        private Vector2 foodPosition;
        private Vector2 circleDeameter = new Vector2(2f, 2f);

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 0f, 0.1f);  //spawn food every 4 seconds, starting in 1
        }

        private void Update()
        {
            MakeFoodPosition();
        }

        private void MakeFoodPosition()
        {
            foodPosition = new Vector2(Random.value, Random.value);
            foodPosition = SpawnArea.ViewportToWorldPoint(foodPosition);
        }

        private void Spawn()
        {
            //foodPosition == Snake.SnakePosition - circleDeameter && foodPosition == foodPosition - circleDeameter
            //foodPosition != Snake.SnakePosition

            Instantiate(FoodPrefab, foodPosition, Quaternion.identity);
        }
    }
}
