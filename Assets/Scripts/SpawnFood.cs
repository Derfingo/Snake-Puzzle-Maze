using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] protected GameObject FoodPrefab;
    private Vector2 foodPosition;
    private Vector2 circleDeameter = new Vector2((float)0.4, (float)0.4);
    private SnakeTail snakePosition;

    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    private void Spawn()
    {
        do
        {
            foodPosition = new Vector2(Random.Range(Left.position.x + .4f, Right.position.x - .4f),
                                       Random.Range(Bottom.position.y + .4f, Top.position.y - .4f));

            Instantiate(FoodPrefab, new Vector2(foodPosition.x, foodPosition.y), Quaternion.identity);

        } while (foodPosition == snakePosition.GetSnakePosition - circleDeameter && foodPosition == foodPosition - circleDeameter);
    }

    private void Start()
    {
        snakePosition = GameObject.Find("Snake").GetComponent<SnakeTail>();

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
