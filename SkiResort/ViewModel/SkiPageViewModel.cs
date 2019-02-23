namespace SkiResort.ViewModel
{
    using SkiResort.Base;
    using SkiResort.Resources;


    public class SkiPageViewModel : ViewModelBase
    {

        /// <summary>
        /// The page title.
        /// </summary>
        private string _title;

        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        /// <value>The page title.</value>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        public SkiPageViewModel()
        {
            Title = AppResources.TitleSkiPage;
        }
    }
}
