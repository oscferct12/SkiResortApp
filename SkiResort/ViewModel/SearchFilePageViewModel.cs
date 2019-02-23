﻿using Microsoft.Win32;
using SkiResort.Base;
using SkiResort.Resources;
using System;
using System.Windows.Input;

namespace SkiResort.ViewModel
{
    public class SearchFilePageViewModel : ViewModelBase
    {

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
        /// <summary>
        /// The constructor.
        /// </summary>
        public SearchFilePageViewModel()
        {
            Title = AppResources.TitleSkiPage;
            ImageSource = AppResources.SrcImageSkiIcon;
            RegisterCommand();
        }


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
            }
        }
    }
}
