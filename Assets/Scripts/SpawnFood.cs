using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    

    void Spawn()
    {
        int x = (int)Random.Range(left.position.x, right.position.x);
        int y = (int)Random.Range(bottom.position.y, top.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

    void Start()
    {
        //spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    void Update()
    {
        if (!foodPrefab)
        {
            Spawn();
        }
        else
        {
            return;
        }
    }
}
