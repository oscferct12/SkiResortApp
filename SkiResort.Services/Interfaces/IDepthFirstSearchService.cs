using SkiResort.Services.Entities;

namespace SkiResort.Services.Interfaces
{
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



    }
}
