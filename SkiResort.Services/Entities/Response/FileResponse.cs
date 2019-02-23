

namespace SkiResort.Services.Entities.Response
{
    public class FileResponse
    {
        public int RowsNumber { get; set; }

        public int ColumnNumber { get; set; }

        public int[][] ClimbMap { get; set; }
    }
}
