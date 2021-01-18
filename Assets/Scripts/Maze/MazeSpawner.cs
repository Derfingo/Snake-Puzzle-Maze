using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MazeSpawner : MonoBehaviour
    {
        public GameObject cellPrefab;
        public GameObject MazePosition;

        private void Start()
        {
            MazeGenerator generator = new MazeGenerator();
            MazeGeneratorCell[,] maze = generator.GenerateMaze();

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Cell cell = Instantiate(cellPrefab, new Vector2(x, y), Quaternion.identity).GetComponent<Cell>();

                    cell.transform.SetParent(MazePosition.transform, false);

                    cell.WallLeft.SetActive(maze[x, y].WallLeft);
                    cell.WallBottom.SetActive(maze[x, y].WallBottom);
                }
            }
        }
    }
}
