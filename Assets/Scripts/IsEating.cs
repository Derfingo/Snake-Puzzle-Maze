using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEating : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SnakeController snake))
        {
            
        }
    }
}
