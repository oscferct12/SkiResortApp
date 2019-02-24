namespace SkiResort.ViewModel
{
    using Microsoft.Win32;
    using SkiResort.Base;
    using SkiResort.Resources;
    using SkiResort.Services.Interfaces;
    using SkiResort.Services.Services;
    using SkiResort.View;
    using System.Diagnostics;
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
        /// The Email to Command..
        /// </summary>
        private ICommand _emailToCommand;


        /// <summary>
        /// Gets or sets The Email to Command.
        /// </summary>
        /// <value>The look file.</value>
        public ICommand EmailToCommand
        {
            get { return _emailToCommand; }
            set
            {
                _emailToCommand = value;
                OnPropertyChanged("EmailToCommand");
            }
        }

        /// <summary>
        /// The Git repository Command..
        /// </summary>
        private ICommand _gitRepositoryCommand;


        /// <summary>
        /// Gets or sets The Git repository Command.
        /// </summary>
        /// <value>The look file.</value>
        public ICommand GitRepositoryCommand
        {
            get { return _gitRepositoryCommand; }
            set
            {
                _gitRepositoryCommand = value;
                OnPropertyChanged("GitRepositoryCommand");
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
            RegisterCommand();
        }

        #region method
        /// <summary>
        /// Register Command
        /// </summary>
        public void RegisterCommand()
        {
            SearchFileCommand = new CommandBase(SearchFileOpenDialog, e => true);
            GitRepositoryCommand = new CommandBase(GotoGitRepository, e => true);
            EmailToCommand = new CommandBase(GotoEmail, e => true);
        }

        private void GotoEmail(object e)
        {
            Process.Start(AppResources.EmailTo);
        }

        /// <summary>
        /// Go to git repository
        /// </summary>
        private void  GotoGitRepository(object e)
        {
            Process.Start(AppResources.GitRepository);
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
