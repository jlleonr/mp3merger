/**************************************************************
 * Module: MP3FilesViewModel.cs                               *
 * Author: Jose L. Leon                                       *
 * Copyright: 2016-2017                                       *
 *                                                            *
 * Description:                                               *
 *  This module is responsible of accessing the business      *
 *  logic associated with merging the MP3 files.              *
 *                                                            *
 * ************************************************************/

using Microsoft.Win32;
using MP3Merger1.Model;
using MP3Merger2.Services;
using System.Windows;

namespace MP3Merger1.ViewModel
{
    /// <summary>
    /// ViewModel component
    /// </summary>
    class MP3FilesViewModel
    {
        private const string initF1 = "Path to file #1";
        private const string initF2 = "Path to file #2";
        private const string initOutDir = "Output Directory";
        private OpenFileDialog openFileDialog;

        public MP3FilesModel MP3Files { get; private set; }

        private bool ValidPaths()
        {
            if ((MP3Files.FileName1 == MP3Files.FileName2)
                || (MP3Files.FileName1 == MP3Files.OutputDirectory)
                || (MP3Files.FileName2 == MP3Files.OutputDirectory))
            {
                MessageBox.Show("The file names or directories cannot be repeated!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set initial values to the Model properties,
        /// since they will be binded to the UI the idea is to show
        /// an initial text in the TextBox.
        /// </summary>
        public MP3FilesViewModel()
        {
            MP3Files = new MP3FilesModel()
            {
                FileName1 = initF1,
                FileName2 = initF2,
                OutputDirectory = initOutDir
            };

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
        }

        /// <summary>
        /// Set path for first mp3 file.
        /// </summary>
        public void OnSetFile1()
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog.ShowDialog() == true)
            {
                MP3Files.FileName1 = openFileDialog.FileName;

                if (!ValidPaths())
                {
                    MP3Files.FileName1 = initF1;
                }
            }
        }

        /// <summary>
        /// Set path for second mp3 file.
        /// </summary>
        public void OnSetFile2()
        {
            if (openFileDialog.ShowDialog() == true)
            {
                MP3Files.FileName2 = openFileDialog.FileName;

                if (!ValidPaths())
                {
                    MP3Files.FileName2 = initF2;
                }
            }
        }

        /// <summary>
        /// Set output directory.
        /// </summary>
        public void OnSetOutDir()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            saveFileDialog.DefaultExt = "mp3";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                MP3Files.OutputDirectory = saveFileDialog.FileName;

                if (!ValidPaths())
                {
                    MP3Files.OutputDirectory = initOutDir;
                }
            }
        }

        /// <summary>
        /// Merge the selected files.
        /// </summary>
        public void OnMerge()
        {

            if ((string.IsNullOrEmpty(MP3Files.FileName1) || MP3Files.FileName1.Equals(initF1))
                || (string.IsNullOrEmpty(MP3Files.FileName2) || MP3Files.FileName2.Equals(initF2))
                || (string.IsNullOrEmpty(MP3Files.OutputDirectory) || MP3Files.OutputDirectory.Equals(initOutDir)))
            {
                MessageBox.Show("Select two mp3 files and an output directory first.");
                return;
            }

            MergeService.Mp3Merge(MP3Files.FileName1, MP3Files.FileName2, MP3Files.OutputDirectory);
        }

    }
}
