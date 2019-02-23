namespace SkiResort.Services.Services
{
    using SkiResort.Services.Entities.Response;
    using SkiResort.Services.Interfaces;
    using System;
    using System.Linq;

    public class FileProcessingService : IFileProcessingService
    {
        /// <summary>
        /// Read all lines in the File.
        /// </summary>
        /// <param name="pathFIle"></param>
        /// <returns></returns>
        public FileResponse ReadAllFile(string pathFile)
        {
            FileResponse response = new FileResponse();

            string[] informationFile = System.IO.File.ReadAllLines(pathFile);

            response.RowsNumber = Convert.ToInt32(informationFile[0].Split(' ').ToList().First());
            response.ColumnNumber = Convert.ToInt32(informationFile[0].Split(' ').ToList().Last());

            int[][] mountainMap = informationFile.Skip(1).ToList().ConvertAll(t => t.Split(' ').ToList()
                                .ConvertAll(r => Convert.ToInt32(r)).ToArray()).ToArray();

            response.ClimbMap = mountainMap;
            return response;
        }
    }
}
