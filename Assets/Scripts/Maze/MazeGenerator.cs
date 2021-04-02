using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MazeGeneratorCell
    {
        public int CellByX;
        public int CellByY;

        public bool WallLeft = true;
        public bool WallBottom = true;

        public bool Visited = false;
        public int DistanceFromStart;
    }

    public class MazeGenerator
    {
        public int Width = 5;    // 5
        public int Height = 7;   // 8

        public MazeGeneratorCell[,] GenerateMaze()
        {
            MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = new MazeGeneratorCell { CellByX = x, CellByY = y };
                }
            }

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                maze[x, Height - 1].WallLeft = false;
            }

            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[Width - 1, y].WallBottom = false;
            }

            RemoveWallsWithBackTracker(maze);

            PlaceMazeExit(maze);

            return maze;
        }

        private void RemoveWallsWithBackTracker(MazeGeneratorCell[,] maze)
        {
            MazeGeneratorCell currentCell = maze[0, 0]; //start cell

            currentCell.Visited = true;
            currentCell.DistanceFromStart = 0;

            Stack<MazeGeneratorCell> stackCells = new Stack<MazeGeneratorCell>();

            do
            {
                List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

                int x = currentCell.CellByX;
                int y = currentCell.CellByY;

                if (x > 0 && !maze[x - 1, y].Visited)
                {
                    unvisitedNeighbours.Add(maze[x - 1, y]);
                }

                if (y > 0 && !maze[x, y - 1].Visited)
                {
                    unvisitedNeighbours.Add(maze[x, y - 1]);
                }

                if (x < Width - 2 && !maze[x + 1, y].Visited)
                {
                    unvisitedNeighbours.Add(maze[x + 1, y]);
                }

                if (y < Height - 2 && !maze[x, y + 1].Visited)
                {
                    unvisitedNeighbours.Add(maze[x, y + 1]);
                }

                if (unvisitedNeighbours.Count > 0)
                {
                    MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                    RemoveWall(currentCell, chosen);

                    chosen.Visited = true;
                    stackCells.Push(chosen);
                    currentCell = chosen;
                    chosen.DistanceFromStart = stackCells.Count;
                }
                else
                {
                    currentCell = stackCells.Pop();
                }

            } while (stackCells.Count > 0);
        }

        private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
        {
            if (a.CellByX == b.CellByX)
            {
                if (a.CellByY > b.CellByY)
                {
                    a.WallBottom = false;
                }
                else
                {
                    b.WallBottom = false;
                }
            }
            else
            {
                if (a.CellByX > b.CellByX)
                {
                    a.WallLeft = false;
                }
                else
                {
                    b.WallLeft = false;
                }
            }
        }

        public void PlaceMazeExit(MazeGeneratorCell[,] maze)
        {
            MazeGeneratorCell furthest = maze[0, 0];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                if (maze[x, Height - 2].DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = maze[x, Height - 2];
                }

                if (maze[x, 0].DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = maze[x, 0];
                }
            }

            for (int y = 0; y < maze.GetLength(1); y++)
            {
                if (maze[Width - 2, y].DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = maze[Width - 2, y];
                }

                if (maze[0, y].DistanceFromStart > furthest.DistanceFromStart)
                {
                    furthest = maze[0, y];
                }
            }

            if (furthest.CellByX == 0)
            {
                furthest.WallLeft = false;
            }
            else if (furthest.CellByY == 0)
            {
                furthest.WallBottom = false;
            }
            else if (furthest.CellByX == Width - 2)
            {
                maze[furthest.CellByX + 1, furthest.CellByY].WallLeft = false;
            }
            else if (furthest.CellByY == Height - 2)
            {
                maze[furthest.CellByX, furthest.CellByY + 1].WallBottom = false;
            }
        }
    }
}
