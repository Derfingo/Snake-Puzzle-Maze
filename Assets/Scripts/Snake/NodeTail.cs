using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class NodeTail : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<CompositeCollider2D>())
            {
                //Debug.Log("collision");

            }
        }
    }
}
