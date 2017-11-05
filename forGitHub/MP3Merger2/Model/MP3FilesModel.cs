/**************************************************************
 * Module: MP3FilesModel.cs                                   *
 * Author: Jose L. Leon                                       *
 * Copyright: 2016-2017                                       *
 *                                                            *
 * Description:                                               *
 *  This module holds the data from the MP3 files             *
 *  that will be merged into a single file.                   *
 *                                                            *
 * ************************************************************/

using System.ComponentModel;

namespace MP3Merger1.Model
{
    /// <summary>
    /// Model component
    /// </summary>
    class MP3FilesModel : INotifyPropertyChanged
    {
        private string fileName1;
        private string fileName2;
        private string outputDirectory;

        /// <summary>
        /// Acces to first file name that need to be merged.
        /// </summary>
        public string FileName1
        {
            get
            {
                return fileName1;
            }

            set
            {
                if (fileName1 != value)
                {
                    fileName1 = value;
                    RaisePropertyChanged("FileName1");
                }
            }
        }

        /// <summary>
        /// Acces to second file name that need to be merged.
        /// </summary>
        public string FileName2
        {
            get
            {
                return fileName2;
            }

            set
            {
                if (fileName2 != value)
                {
                    fileName2 = value;
                    RaisePropertyChanged("FileName2");
                }
            }
        }

        /// <summary>
        /// Acces to the desired output directory path.
        /// </summary>
        public string OutputDirectory
        {
            get
            {
                return outputDirectory;
            }

            set
            {
                if (outputDirectory != value)
                {
                    outputDirectory = value;
                    RaisePropertyChanged("OutputDirectory");
                }
            }
        }

        /// <summary>
        /// Event to notify the UI when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
