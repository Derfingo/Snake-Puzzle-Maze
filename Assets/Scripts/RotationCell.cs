using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCell : MonoBehaviour
{
    [SerializeField] private float firstDelay = 0;
    //[SerializeField] private float lastDelay = 0;
    [SerializeField] private float rangeX = 1f;
    //[SerializeField] private float rangeY = 1f;
    //[SerializeField] private float moveSpeed = 1f;

    //private Transform cell;

    //private void Start()
    //{
    //    cell = GetComponent<Transform>();
    //}

    private void Update()
    {
        StartCoroutine(MoveCell());

        if (Input.GetMouseButtonDown(0))
        {
            Test();
        }
    }

    private IEnumerator MoveCell()
    {
        if (rangeX > 0)
        {
            float moveX = Mathf.PingPong(Time.time, rangeX);
            transform.position = new Vector3(moveX, 0, 0);

            yield return new WaitForSeconds(firstDelay);
        }
        else
        {
            transform.Translate(transform.position, 0f);
        }

        //if (rangeY > 0)
        //{
        //    float moveY = Mathf.PingPong(Time.time, rangeY);
        //    cell.position = new Vector3(0, moveY, 0);
        //}
    }

    private void Test()
    {
        StopAllCoroutines();

        transform.position = Vector3.zero;
    }
}
