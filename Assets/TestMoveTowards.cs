using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveTowards : MonoBehaviour
{
    public Transform Head;
    
    private float speed = 4f;
    private float nodeDiameter = 1f;

    private void Start()
    {
        
    }

    private void Update()
    {
        float distance = Vector2.Distance(Head.position, transform.position);
        
        transform.position = Vector3.MoveTowards(transform.position, Head.position, nodeDiameter * speed * Time.deltaTime);
        
    }
}
