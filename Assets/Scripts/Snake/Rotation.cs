using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake;

public class Rotation : MonoBehaviour
{
    public Movement Direction;

    private readonly float speedRotation = 5f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        switch (Direction.CurDirection)
        {
            case 0:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
                break;
            case 1:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), speedRotation * Time.deltaTime);
                break;
            case 2:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), speedRotation * Time.deltaTime);
                break;
            case 3:
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), speedRotation * Time.deltaTime);
                break;
        }
    }
}
