using UnityEngine;

public class SpawnFoodForAI : MonoBehaviour
{
    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    public GameObject foodPrefabAI;
    protected GameObject currentFood;
    [HideInInspector] public Vector2 currentPositionFood;
    
    private void AddNewFood()
    {
        RandomPositionFood();
        currentFood = Instantiate(foodPrefabAI, currentPositionFood, transform.rotation);
    }

    private void RandomPositionFood()
    {
        currentPositionFood = new Vector2(Random.Range(Left.position.x + .3f, Right.position.x - .3f),
                                       Random.Range(Bottom.position.y + .3f, Top.position.y - .3f));
    }

    void Update()
    {
        if (!currentFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }

    }
}
