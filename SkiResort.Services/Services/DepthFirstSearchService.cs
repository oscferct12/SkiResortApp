using SkiResort.Services.Entities;
using SkiResort.Services.Interfaces;

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

            // Searching UP ▲ Direction
            if (j > 0 && climbMap[i, j] > climbMap[i, j - 1])
            {
                route = FunctionDFS(i, j - 1, climbMap);

                // If current path value is larger then Update path full length
                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching DOWN ▼ Direction
            if (j < (ColumnNumber - 1) && climbMap[i, j] > climbMap[i, j + 1])
            {
                route = FunctionDFS(i, j + 1, climbMap);

                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching LEFT ◄ Direction
            if (i > 0 && climbMap[i, j] > climbMap[i - 1, j])
            {
                route = FunctionDFS(i - 1, j, climbMap);

                if (route.PathLenght > pathAndDrop.PathLenght)
                    pathAndDrop = route;
            }

            // Searching RIGHT ► Direction
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
        /// Gets the maximum path.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Drop">The drop.</param>
        /// <param name="maxPathCoordXY">The maximum path coord xy.</param>
        /// <param name="maxPath">The maximum path.</param>
        /// <param name="maxDrop">The maximum drop.</param>
        private  void GetMaxPath(int[,] Path, int[,] Drop, int[] maxXY, ref int maxPath, ref int maxDrop)
        {
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
        }

    }
}
