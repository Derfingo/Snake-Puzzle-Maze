using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoodForAI : MonoBehaviour
{
    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    public GameObject foodPrefab;
    protected GameObject currentFood;
    protected Vector2 currentPositionFood;
    
    void AddNewFood()
    {
        RandomPositionFood();
        currentFood = Instantiate(foodPrefab, currentPositionFood, transform.rotation);
    }


    void RandomPositionFood()
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
