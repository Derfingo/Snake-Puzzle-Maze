using UnityEngine;
using UnityEngine.UIElements;

public class SpawnFood : MonoBehaviour
{
    public Transform Left;
    public Transform Right;
    public Transform Bottom;
    public Transform Top;

    [SerializeField] protected GameObject FoodPrefab;
    private Vector2 foodPosition;
    private Vector2 circleDeameter = new Vector2((float)0.4, (float)0.4);
    private SnakeTail snakePosition;

    //foodPosition = new Vector2(Random.Range(Left.position.x + .4f, Right.position.x - .4f),
    //                                   Random.Range(Bottom.position.y + .4f, Top.position.y - .4f));

    private void Spawn()
    {
        do
        {
            foodPosition = new Vector2(Random.Range(Left.position.x, Right.position.x),
                                       Random.Range(Bottom.position.y, Top.position.y));

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
