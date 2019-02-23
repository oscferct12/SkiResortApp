namespace SkiResort
{
    using SkiResort.Services.Entities.Response;
    using SkiResort.View;
    using System.Windows;

    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Propertys

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
