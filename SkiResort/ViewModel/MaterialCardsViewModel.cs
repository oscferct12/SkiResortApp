namespace SkiResort.ViewModel
{
    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    public class MaterialClassViewModel
    {
        /// <summary>
        /// The path lenght.
        /// </summary>
        private int _pathLenght;

        /// <summary>
        /// The max drop.
        /// </summary>
        private int _maxDrop;

        /// <summary>
        ///The max drop.
        /// </summary>
        public int MaxDrop
        {
            get { return _maxDrop; }
            set
            {
                _maxDrop = value;
            }
        }

        private double _trend;


        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeriesB { get; set; }


        /// <summary>
        /// The path Lenght.
        /// </summary>
        public int PathLenght
        {
            get { return _pathLenght; }
            set
            {
                _pathLenght = value;
            }
        }

        public MaterialClassViewModel()
        {
            PathLenght = App.MaxPath;
            MaxDrop = App.MaxDrop;

            LastHourSeriesB = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(MaxDrop),
                        new ObservableValue(MaxDrop),
                        new ObservableValue(MaxDrop),
                        new ObservableValue(MaxDrop)
                    }
                }
            };

            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(9),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(2),
                        new ObservableValue(1),
                        new ObservableValue(9),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(2),
                        new ObservableValue(1)
                    }
                }
            };


            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    //_trend += (r.NextDouble() > 0.3 ? 1 : -1) * r.Next(0, 5);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        LastHourSeries[0].Values.Add(new ObservableValue(_trend));
                        LastHourSeries[0].Values.RemoveAt(0);

                        LastHourSeriesB[0].Values.Add(new ObservableValue(_trend));
                        LastHourSeriesB[0].Values.RemoveAt(0);
                    });
                }
            });
        }
    }
}
