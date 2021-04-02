using System.Collections;
using UnityEngine;

namespace Food
{
    public class SpawnFoodRaycast : MonoBehaviour
    {
        [SerializeField] private GameObject FoodPrefab;
        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private LayerMask spawnedLayer;

        private Vector3 foodPosition;
        private readonly float raycastDistance = 2f;

        private void Start()
        {
            StartCoroutine(nameof(SpawnFood));
        }

        private void Update()
        {
            FoodPosition();
        }

        private void FoodPosition()
        {
            foodPosition = new Vector3(Random.Range(boxCollider2D.bounds.min.x + 0.4f, boxCollider2D.bounds.max.x - 0.4f),
                                       Random.Range(boxCollider2D.bounds.min.y + 0.4f, boxCollider2D.bounds.max.y - 0.4f));
        }

        private void PositionRaycast()
        {
            if (Physics2D.Raycast(foodPosition, Vector3.forward, raycastDistance))
            {
                Vector2 overlapBox = new Vector2(0.5f, 0.5f);

                Collider2D[] collidersInsideOverlapBox = new Collider2D[1];
                int numberOfCollidersFound = Physics2D.OverlapBoxNonAlloc(foodPosition, overlapBox, 0f, collidersInsideOverlapBox, spawnedLayer);

                if (numberOfCollidersFound == 0)
                {
                    //Debug.Log("spawned food");
                    Instantiate(FoodPrefab, foodPosition, Quaternion.identity, transform);
                }
                else
                {
                    //Debug.Log("name of collider found " + collidersInsideOverlapBox[0].name);
                }
            }
            else
            {
                //Debug.Log("miss");
            }
        }

        private IEnumerator SpawnFood()
        {
            while (true)
            {
                PositionRaycast();

                yield return new WaitForSeconds(Random.Range(0f, 5f));
            }
        }
    }
}
