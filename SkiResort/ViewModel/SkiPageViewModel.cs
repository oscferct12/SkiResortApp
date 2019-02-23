namespace SkiResort.ViewModel
{
    using SkiResort.Base;
    using SkiResort.Resources;
    using SkiResort.Services.Entities;
    using SkiResort.Services.Entities.Response;
    using SkiResort.Services.Interfaces;
    using SkiResort.Services.Services;
    using System;

    public class SkiPageViewModel : ViewModelBase
    {
        #region Property
        /// <summary>
        /// The service.
        /// </summary>
        private IDepthFirstSearchService _service;

        /// <summary>
        /// The file Information.
        /// </summary>
        private FileResponse _fileInformation;

        #endregion
        /// <summary>
        /// The constructor.
        /// </summary>
        public SkiPageViewModel()
        {
            Title = AppResources.TitleSkiPage;

            if (App.FileInformation != null)
            {
                _fileInformation = App.FileInformation;
                _service = new DepthFirstSearchService(_fileInformation.RowsNumber, _fileInformation.RowsNumber);
                FunctionDFS(_fileInformation);
            }
        }

        #region Methods

        /// <summary>
        /// Algorithm Depth FirstSearch.
        /// </summary>
        /// <param name="climbMap"></param>
        private void FunctionDFS(FileResponse climbMap)
        {
            int numberRows = climbMap.RowsNumber;
            int numberColumns = climbMap.ColumnNumber;

            int[,] Path = new int[numberRows, numberColumns];
            int[,] Drop = new int[numberRows, numberColumns];
            int[,] map = ConvertToArrayMap(climbMap);

            for (int i = 0; i < numberRows; i++)
            {
                for (int j = 0; j < numberColumns; j++)
                {
                    Route route = _service.FunctionDFS(i, j, map);
                    Path[i, j] = route.PathLenght;
                    Drop[i, j] = map[i, j] - map[route.MovX, route.MovY];
                }
            }
        }

        /// <summary>
        /// Convert to arrayMap.
        /// </summary>
        /// <returns></returns>
        private int[,] ConvertToArrayMap(FileResponse climbMap)
        {
            int minorLength = climbMap.ClimbMap[0].Length;
            int[,] map = new int[climbMap.RowsNumber, climbMap.ColumnNumber];

            for (int i = 0; i < climbMap.ClimbMap.Length; i++)
            {
                var array = climbMap.ClimbMap[i];

                for (int j = 0; j < minorLength; j++)
                {
                    map[i, j] = array[j];
                }
            }
            return map;
        }
        #endregion
    }



}

