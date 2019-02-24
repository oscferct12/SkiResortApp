namespace SkiResort.ViewModel
{
    using LiveCharts;
    using LiveCharts.Configurations;
    using SkiResort.Base;
    using SkiResort.Models;
    using System.Collections.ObjectModel;

    public class PointStateExampleViewModel : ViewModelBase
    {

        /// <summary>
        /// The max path.
        /// </summary>
        private static ObservableCollection<CoordinateModel> _listResult;

        /// <summary>
        /// 
        /// </summary>
        public static ObservableCollection<CoordinateModel> ListResult
        {
            get { return _listResult; }
            set
            {
                _listResult = value;
            }
        }

        public ChartValues<CoordinateModel> Values { get; set; }
        public CartesianMapper<CoordinateModel> Mapper { get; set; }


        public PointStateExampleViewModel()
        {
            ListResult = new ObservableCollection<CoordinateModel>(App.ListResult);
            Values = new ChartValues<CoordinateModel>();
            foreach (var item in ListResult)
            {

                CoordinateModel coordinate = new CoordinateModel();
                coordinate = item;

                Values.Add(coordinate);
            }

            //Lets define a custom mapper, to set fill and stroke
            //according to chart values...
            Mapper = Mappers.Xy<CoordinateModel>()
             .X(model => model.Xcoord)
             .Y(model => model.Value);
        }
    }
}
