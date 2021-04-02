using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MazeScale : MonoBehaviour
    {
        [SerializeField] private float localScale = 0.8f;

        private Transform mazePosition;

        void Start()
        {
            mazePosition = GetComponent<Transform>();

            mazePosition.localScale *= localScale;
        }

    }
}
