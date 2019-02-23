namespace SkiResort
{
    using SkiResort.Models;
    using SkiResort.Services.Entities.Response;
    using SkiResort.View;
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Propertys

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


        /// <summary>
        /// The max path.
        /// </summary>
        private static int _maxPath;


        /// <summary>
        /// The max path.
        /// </summary>
        public static int MaxPath
        {
            get { return _maxPath; }
            set
            {
                _maxPath = value;
            }
        }

        /// <summary>
        /// The max drop.
        /// </summary>
        private static int _maxDrop;


        /// <summary>
        /// The max drop.
        /// </summary>
        public static int MaxDrop
        {
            get { return _maxDrop; }
            set
            {
                _maxDrop = value;
            }
        }

        /// <summary>
        /// The file information variable.
        /// </summary>
        private static FileResponse _fileInformation;


        /// <summary>
        /// The file information property.
        /// </summary>
        public static FileResponse FileInformation
        {
            get { return _fileInformation; }
            set
            {
                _fileInformation = value;
            }
        }

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SearchFilePage searchFile = new SearchFilePage();
            searchFile.Show();

        }
    }
}
