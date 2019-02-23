using SkiResort.Services.Entities.Response;

namespace SkiResort.Services.Interfaces
{
    public interface IFileProcessingService
    {

        /// <summary>
        /// Read all file selected.
        /// </summary>
        /// <param name="pathFIle">The path file.</param>
        /// <returns></returns>
        FileResponse ReadAllFile(string pathFIle);
    }
}
