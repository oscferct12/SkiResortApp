namespace SkiResort.ViewModel
{
    using Microsoft.Win32;
    using SkiResort.Base;
    using SkiResort.Resources;
    using SkiResort.Services.Interfaces;
    using SkiResort.Services.Services;
    using SkiResort.View;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    public class SearchFilePageViewModel : ViewModelBase
    {
        #region Propertys
        /// <summary>
        /// The service.
        /// </summary>
        IFileProcessingService _service;

        /// <summary>
        /// The image source.
        /// </summary>
        private string _imageSource;

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>The image source.</value>
        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The look file command.
        /// </summary>
        private ICommand _searchFileCommand;


        /// <summary>
        /// Gets or sets the look file.
        /// </summary>
        /// <value>The look file.</value>
        public ICommand SearchFileCommand
        {
            get { return _searchFileCommand; }
            set
            {
                _searchFileCommand = value;
                OnPropertyChanged("SearchFileCommand");
            }
        }
        #endregion
        /// <summary>
        /// The constructor.
        /// </summary>
        public SearchFilePageViewModel()
        {
            Title = AppResources.TitleSkiPage;
            ImageSource = AppResources.SrcImageSkiIcon;
            RegisterCommand();
        }

        #region method
        /// <summary>
        /// Register Command
        /// </summary>
        public void RegisterCommand()
        {
            SearchFileCommand = new CommandBase(SearchFileOpenDialog, e => true);
        }


        /// <summary>
        /// Open dialog for Look file.
        /// </summary>
        /// <param name="e"></param>
        private void SearchFileOpenDialog(object e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = AppResources.TextLookFileMountain;
            dlg.DefaultExt = ".txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                ReadFileSelected(filename);
            }
        }

        /// <summary>
        /// Read the file selected.
        /// </summary>
        /// <param name="path"></param>
        private void ReadFileSelected(string path)
        {
            _service = new FileProcessingService();
            bool ValidExtension = Path.GetExtension(path) == ".txt" ? true : false;
            if (!ValidExtension)
            {
                MessageBox.Show(AppResources.InvalidExtensionFIle, "Invalid Extension");
                return;
            }
            var response = _service.ReadAllFile(path);

            if (response != null && !response.IsCorruptFile)
            {
                App.FileInformation = response;
                SkiPage skiPage = new SkiPage();
                skiPage.Show();
            }
            else
            {
                MessageBox.Show(AppResources.FileCantRead, "Error");
                return;
            }

        }
        #endregion
    }
}
