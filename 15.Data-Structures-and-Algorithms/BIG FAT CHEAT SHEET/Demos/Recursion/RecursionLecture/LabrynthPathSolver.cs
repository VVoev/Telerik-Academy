using System;
using System.Collections.Generic;

namespace RecursionLecture
{
    public class LabrynthPathSolver
    {
        private List<int[,]> paths;
        private int pathsCount;
        private int[,] currentPath;
        private int currentStepCount;

        public List<int[,]> GetPossiblePaths(bool[,] labrynth)
        {
            this.paths = new List<int[,]>();
            this.pathsCount = 0;
            this.currentStepCount = 0;
            this.currentPath = new int[labrynth.GetLength(0), labrynth.GetLength(1)];

            this.FindPath(labrynth, 0, 0);

            return this.paths;
        }

        private void FindPath(bool[,] labrynth, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || colIndex < 0 || rowIndex >= labrynth.GetLength(0) || colIndex >= labrynth.GetLength(1))
            {
                return;
            }

            if (labrynth[rowIndex, colIndex])
            {
                return;
            }

            if (rowIndex == labrynth.GetLength(0) - 1 && colIndex == labrynth.GetLength(1) - 1)
            {
                this.AddPath(this.currentPath);
            }

            labrynth[rowIndex, colIndex] = true;
            this.currentStepCount++;
            this.currentPath[rowIndex, colIndex] = this.currentStepCount;

            this.FindPath(labrynth, rowIndex + 1, colIndex);
            this.FindPath(labrynth, rowIndex - 1, colIndex);
            this.FindPath(labrynth, rowIndex, colIndex + 1);
            this.FindPath(labrynth, rowIndex, colIndex - 1);

            this.currentStepCount--;
            this.currentPath[rowIndex, colIndex] = 0;
            labrynth[rowIndex, colIndex] = false;
        }

        private void AddPath(int[,] currentPath)
        {
            var pathToAdd = new int[currentPath.GetLength(0), currentPath.GetLength(1)];

            for (int i = 0; i < currentPath.GetLength(0); i++)
            {
                for (int j = 0; j < currentPath.GetLength(1); j++)
                {
                    pathToAdd[i, j] = currentPath[i, j];
                }
            }

            this.paths.Add(pathToAdd);
        }
    }
}
