using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MazeScale : MonoBehaviour
    {
        [SerializeField] private float localScale = 0.78f;

        private Transform mazePositin;

        void Start()
        {
            mazePositin = GetComponent<Transform>();

            mazePositin.localScale *= localScale;
        }

    }
}
