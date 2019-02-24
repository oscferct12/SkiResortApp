

namespace SkiResort.Services.Entities.Response
{
    public class FileResponse
    {
        /// <summary>
        /// The rows number in the matriz.
        /// </summary>
        public int RowsNumber { get; set; }

        /// <summary>
        /// The column number in the matriz.
        /// </summary>
        public int ColumnNumber { get; set; }

        /// <summary>
        /// The matriz *x*.
        /// </summary>
        public int[][] ClimbMap { get; set; }

        /// <summary>
        /// Valid if the file is corrupt.
        /// </summary>
        public bool IsCorruptFile { get; set; }
    }
}
