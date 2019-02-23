namespace SkiResort.ViewModel
{
    using SkiResort.Base;
    using SkiResort.Models;
    using SkiResort.Resources;
    using SkiResort.Services.Entities;
    using SkiResort.Services.Entities.Response;
    using SkiResort.Services.Interfaces;
    using SkiResort.Services.Services;
    using System;
    using System.Collections.Generic;

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
            GetMaxPath(Path, Drop, map);
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


        /// <summary>
        /// Gets the max path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="drop"></param>
        private void GetMaxPath(int[,] path, int[,] drop, int[,] climbMap)
        {

            int[] maxPathCoordXY = new int[2];
            int maxPath = -1;
            int maxDrop = -1;

            var maxPathDrop = _service.GetMaxPath(path, drop, maxPathCoordXY, maxPath, maxDrop);

            App.MaxPath = maxPathDrop[0];
            App.MaxDrop = maxPathDrop[1];
            AddPathToList(maxPathCoordXY, climbMap);

        }

        /// <summary>
        /// Add Path to list result.
        /// </summary>
        private void AddPathToList(int[] maxPathCoordXY, int[,] climbMap)
        {
            List<CoordinateModel> listResult = new List<CoordinateModel>();
            List<int> pathList = _service.DFSForMaxPathLength(maxPathCoordXY[0], maxPathCoordXY[1], climbMap);
            pathList.Reverse();

            int[] CoordXY = new int[2];
            int index = 0;
            int temp = 0;
            string printResult = string.Empty;

            foreach (var item in pathList)
            {
                CoordXY[index % 2] = item;
                index++;

                if (index % 2 == 0)
                {
                    listResult.Add(new CoordinateModel() {Xcoord = temp , Ycoord = item , Value = climbMap[CoordXY[0], CoordXY[1]] });
                }

                temp = item;
            }
        }
        #endregion
    }



}

