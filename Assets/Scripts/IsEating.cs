using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsEating : MonoBehaviour
{


    public void OnHit()
    {
        Destroy(gameObject);
    }
}
