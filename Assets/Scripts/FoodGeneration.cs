using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
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
        currentPositionFood = new Vector2(Random.Range(-3.2f, 2.8f), Random.Range(3.2f, -2.8f));
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("SnakeHead"))
    //    {
    //        other.GetComponent<SnakeController>().AddCircle();
    //        Destroy(gameObject);
    //    }
    //}

}
