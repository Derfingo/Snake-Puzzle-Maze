using UnityEngine;
using Snake;

namespace Food
{
    public class SpawnFood : MonoBehaviour
    {
        public SnakeTail snakePosition;

        [SerializeField] protected GameObject FoodPrefab;
        private Vector2 foodPosition;
        private Vector2 circleDeameter = new Vector2(0.4f, 0.4f);
        

        private void Spawn()
        {
            do
            {
                foodPosition = new Vector2(Random.value, Random.value);
                foodPosition = Camera.main.ViewportToWorldPoint(foodPosition);

                Instantiate(FoodPrefab, foodPosition, Quaternion.identity);

            } while (foodPosition == snakePosition.GetSnakePosition - circleDeameter && foodPosition == foodPosition - circleDeameter);
        }

        private void Start()
        {
            //snakePosition = GameObject.Find("Snake").GetComponent<SnakeTail>();

            InvokeRepeating(nameof(Spawn), 0, 4);  //spawn food every 4 seconds, starting in 0
        }

        private void Update()
        {
            if (!FoodPrefab)
            {
                Spawn();
            }
            else
            {
                return;
            }
        }
    }
}
