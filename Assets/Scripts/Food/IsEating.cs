using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Food
{
    public class IsEating : MonoBehaviour
    {
        public void OnHit()
        {
            Destroy(gameObject);
        }
    }
}
