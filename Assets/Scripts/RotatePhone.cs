using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePhone : MonoBehaviour
{
    public Camera positionCamera;

    void Update()
    {
        CorrectPositionCamera();
    }

    private float CorrectPositionCamera()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            positionCamera.orthographicSize = 9f;
        }
        else
        {
            positionCamera.orthographicSize = 4f;
        }
        return 4f;
    }
}
