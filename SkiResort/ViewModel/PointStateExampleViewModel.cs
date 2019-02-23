namespace SkiResort.ViewModel
{
    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Defaults;
    using SkiResort.Base;
    using SkiResort.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Media;
    public class PointStateExampleViewModel : ViewModelBase
    {


        /// <summary>
        /// The list with the values solution.
        /// </summary>
        public ObservableCollection<CoordinateModel> ListValues { get; set; }

        public Func<double, string> Formatter { get; set; }
        public ChartValues<ObservableValue> Values { get; set; }
        public Brush DangerBrush { get; set; }
        public CartesianMapper<ObservableValue> Mapper { get; set; }

        private void UpdateDataOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            foreach (var observable in Values)
            {
                observable.Value = r.Next(10, 400);
            }
        }

        public PointStateExampleViewModel()
        {
            ListValues = new ObservableCollection<CoordinateModel>(App.ListResult);
            var r = new Random();
            Values = new ChartValues<ObservableValue>();

            foreach (var item in ListValues)
            {
                ObservableValue observableValue = new ObservableValue();
                observableValue.Value = (double)item.Value;
                Values.Add(observableValue);
            }

            //Lets define a custom mapper, to set fill and stroke
            //according to chart values...
            Mapper = Mappers.Xy<ObservableValue>()
                .X((item, index) => index)
                .Y(item => item.Value)
                .Fill(item => item.Value > 200 ? DangerBrush : null)
                .Stroke(item => item.Value > 200 ? DangerBrush : null);

            Formatter = x => x + " ms";

            DangerBrush = new SolidColorBrush(Color.FromRgb(238, 83, 80));
        }
    }
}
