using SkiResort.Services.Entities;
using SkiResort.Services.Interfaces;
using System.Collections.Generic;

namespace SkiResort.Services.Services
{
    public class DepthFirstSearchService : IDepthFirstSearchService
    {
        /// <summary>
        /// The NumberRows.
        /// </summary>
        private int RowsNumber { get; set; }

        /// <summary>
        /// The NumberColumn.
        /// </summary>
        private int ColumnNumber { get; set; }

        public DepthFirstSearchService(int rowsNumber, int columnNumber)
        {
            RowsNumber = rowsNumber;
            ColumnNumber = columnNumber;
        }

        public Route FunctionDFS(int i, int j, int[,] climbMap)
        {
            Route pathAndDrop = new Route
            {
                PathLenght = 0,
                MovX = i,
                MovY = j
            };

            Route route = new Route();

            // Searching UP  Direction
            if (j > 0 && climbMap[i, j] > climbMap[i, j - 1])
            {
                route = FunctionDFS(i, j - 1, climbMap);

                // If current path value is larger then Update path full length
                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching DOWN  Direction
            if (j < (ColumnNumber - 1) && climbMap[i, j] > climbMap[i, j + 1])
            {
                route = FunctionDFS(i, j + 1, climbMap);

                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching LEFT Direction
            if (i > 0 && climbMap[i, j] > climbMap[i - 1, j])
            {
                route = FunctionDFS(i - 1, j, climbMap);

                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching RIGHT  Direction
            if (i < (RowsNumber - 1) && climbMap[i, j] > climbMap[i + 1, j])
            {
                route = FunctionDFS(i + 1, j, climbMap);

                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // For each recursion set a new Path Full Length
            pathAndDrop.PathLenght++;

            return pathAndDrop;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Drop"></param>
        /// <param name="maxXY"></param>
        /// <param name="maxPath"></param>
        /// <param name="maxDrop"></param>
        /// <returns></returns>
        public List<int> GetMaxPath(int[,] Path, int[,] Drop, int[] maxXY, int maxPath, int maxDrop)
        {
            List<int> maxPathDrop = new List<int>();

            for (int i = 0; i < RowsNumber; i++)
            {
                for (int j = 0; j < ColumnNumber; j++)
                {
                    if (Path[i, j] > maxPath)
                    {   // if path[i][j] > maxPath, update maxPath and maxDrop
                        maxPath = Path[i, j];
                        maxDrop = Drop[i, j];

                        // Update coordinates too by the max point
                        maxXY[0] = i;
                        maxXY[1] = j;
                    }
                    if (Path[i, j] == maxPath)
                    {   // IF maxPaths are equals, compare the maxDrop
                        if (Drop[i, j] > maxDrop)
                        {
                            // if drop[i][j] > maxDrop, update maxDrop
                            maxDrop = Drop[i, j];

                            // Update coordinates too by the max point
                            maxXY[0] = i;
                            maxXY[1] = j;
                        }
                    }
                }
            }
            maxPathDrop.Add(maxPath);
            maxPathDrop.Add(maxDrop);

            return maxPathDrop;
        }

        /// <summary>
        /// DFSs the length of for maximum path.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="GeoMap">The geo map.</param>
        /// <returns></returns>
        public List<int> DFSForMaxPathLength(int x, int y, int[,] climbMap)
        {
            List<int> list = new List<int>();
            List<int> currentPathList = new List<int>();

            // Searching UP Direction
            if (y > 0 && climbMap[x, y] > climbMap[x, y - 1])
            {
                currentPathList = DFSForMaxPathLength(x, y - 1, climbMap);
                if (currentPathList.Count > list.Count)
                    list = currentPathList;
            }

            // Searching DOWN  Direction
            if (y < (ColumnNumber - 1) && climbMap[x, y] > climbMap[x, y + 1])
            {
                currentPathList = DFSForMaxPathLength(x, y + 1, climbMap);
                if (currentPathList.Count > list.Count)
                    list = currentPathList;
            }

            // Searching LEFT Direction
            if (x > 0 && climbMap[x, y] > climbMap[x - 1, y])
            {
                currentPathList = DFSForMaxPathLength(x - 1, y, climbMap);
                if (currentPathList.Count > list.Count)
                    list = currentPathList;
            }

            // Searching RIGHT Direction
            if (x < (RowsNumber - 1) && climbMap[x, y] > climbMap[x + 1, y])
            {
                currentPathList = DFSForMaxPathLength(x + 1, y, climbMap);
                if (currentPathList.Count > list.Count)
                    list = currentPathList;
            }

            list.Add(y); list.Add(x);
            return list;
        }
    }
}
