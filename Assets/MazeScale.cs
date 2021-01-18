using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScale : MonoBehaviour
{
    private Transform mazeTransform;
    private float localScale = 0.78f;
    void Start()
    {
        mazeTransform = GetComponent<Transform>();

        mazeTransform.localScale *= localScale;
    }

}
