using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsTest : MonoBehaviour
{
    private Vector3 normalizedObject;
    private float lengthNormObject;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        normalizedObject = transform.position.normalized;
        lengthNormObject = normalizedObject.magnitude;

        float scalarProdouct = Vector3.Dot(Vector3.zero, transform.position);
        //Debug.Log(normalizedObject);
        //Debug.Log(lengthNormObject);
        Debug.DrawLine(Vector3.zero, transform.position, Color.green, scalarProdouct);
    }
}
