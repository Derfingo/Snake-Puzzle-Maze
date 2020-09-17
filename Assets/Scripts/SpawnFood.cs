using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;
    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    private Vector2 foodPosition;
    private Vector2 circleDeameter = new Vector2((float)0.4, (float)0.4);
    private SnakeTail snakePosition;

    private void Spawn()
    {
        do
        {
            foodPosition = new Vector2(Random.Range(Left.position.x + .3f, Right.position.x - .3f),
                                       Random.Range(Bottom.position.y + .3f, Top.position.y - .3f));

            Instantiate(FoodPrefab, new Vector2(foodPosition.x, foodPosition.y), Quaternion.identity);

        } while (foodPosition == snakePosition.GetSnakePosition() + circleDeameter && foodPosition == foodPosition + circleDeameter);
    }

    private void Start()
    {
        snakePosition = GameObject.Find("Snake").GetComponent<SnakeTail>();
        //spawn food every 4 seconds, starting in 3
        InvokeRepeating(nameof(Spawn), 0, 4);
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
