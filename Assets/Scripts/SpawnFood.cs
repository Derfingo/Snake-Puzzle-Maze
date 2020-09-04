using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;
    public Transform Top;
    public Transform Bottom;
    public Transform Left;
    public Transform Right;

    private void Spawn()
    {
        float x = (float)Random.Range(Left.position.x + .3f, Right.position.x - .3f);
        float y = (float)Random.Range(Bottom.position.y + .3f, Top.position.y - .3f);

        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
    }

    private void Start()
    {
        //spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
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
