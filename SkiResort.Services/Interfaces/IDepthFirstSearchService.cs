namespace SkiResort.Services.Interfaces
{
    using SkiResort.Services.Entities;
    using System.Collections.Generic;
    public interface IDepthFirstSearchService
    {

        /// <summary>
        /// The FunctionDFS
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="climbMap"></param>
        /// <returns></returns>
        Route FunctionDFS(int i, int j, int[,] climbMap);


        /// <summary>
        /// The get max path method.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Drop"></param>
        /// <param name="maxXY"></param>
        /// <param name="maxPath"></param>
        /// <param name="maxDrop"></param>
        /// <returns></returns>
        List<int> GetMaxPath(int[,] Path, int[,] Drop, int[] maxXY, int maxPath, int maxDrop);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="climbMap"></param>
        /// <returns></returns>
        List<int> DFSForMaxPathLength(int x, int y, int[,] climbMap);
    }
}
