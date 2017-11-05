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
using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;
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

        public MP3FilesModel MP3Files { get; private set; }

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
        }

        public void OnSetFile1()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog1.ShowDialog() == true)
            {
                MP3Files.FileName1 = openFileDialog1.FileName;
            }
        }

        public void OnSetFile2()
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog2.ShowDialog() == true)
            {
                MP3Files.FileName2 = openFileDialog2.FileName;
            }
        }

        public void OnSetOutDir()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            saveFileDialog.DefaultExt = "mp3";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                MP3Files.OutputDirectory = saveFileDialog.FileName;
            }
        }

        public void OnMix()
        {

            if ((string.IsNullOrEmpty(MP3Files.FileName1) || MP3Files.FileName1.Equals(initF1))
                || (string.IsNullOrEmpty(MP3Files.FileName2) || MP3Files.FileName2.Equals(initF2))
                || (string.IsNullOrEmpty(MP3Files.OutputDirectory) || MP3Files.OutputDirectory.Equals(initOutDir)))
            {
                MessageBox.Show("Select two mp3 files and an output directory first.");
                return;
            }
            mp3Merger();
        }

        private void mp3Merger()
        {
            var fileA = new AudioFileReader(MP3Files.FileName1);

            // Calculate our buffer size, since we're normalizing our samples to floats
            // we'll need to account for that by dividing the file's audio byte count
            // by its bit depth / 8.
            var bufferA = new float[fileA.Length / (fileA.WaveFormat.BitsPerSample / 8)];

            // Now let's populate our buffer with samples.
            fileA.Read(bufferA, 0, bufferA.Length);

            // Do it all over again for the other file.
            var fileB = new AudioFileReader(MP3Files.FileName2);
            var bufferB = new float[fileB.Length / (fileB.WaveFormat.BitsPerSample / 8)];
            fileB.Read(bufferB, 0, bufferB.Length);

            // Calculate the largest file
            var maxLen = (long)Math.Max(bufferA.Length, bufferB.Length);
            var final = new byte[maxLen];

            // For now, mix data to a wav file.
            using (MemoryStream ms = new MemoryStream())
            {
                var writer = new WaveFileWriter(ms, fileA.WaveFormat);

                for (var i = 0; i < maxLen; i++)
                {
                    float a, b;

                    if (i < bufferA.Length)
                    {
                        // Reduce the amplitude of the sample by 2
                        // to avoid clipping.
                        a = bufferA[i];// / 2;
                    }
                    else
                    {
                        a = 0;
                    }

                    if (i < bufferB.Length)
                    {
                        b = bufferB[i];// / 2;
                    }
                    else
                    {
                        b = 0;
                    }
                    writer.WriteSample(a + b);
                    writer.Flush();
                }
                ms.Seek(0, SeekOrigin.Begin);
                final = ms.ToArray();             
            }
            convertWavStreamToMp3File(MP3Files.OutputDirectory, final);
            MessageBox.Show("Finished");
        }

        private static void convertWavStreamToMp3File(string outputFile, byte[] waveFile)
        {
            using (var ms = new MemoryStream(waveFile))
            using (var wfr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(outputFile, wfr.WaveFormat, LAMEPreset.VBR_100))
            {
                wfr.CopyTo(wtr);
            }
        }

        private void saveToDisk(byte[] mp3File, string destinationFile)
        {
            File.WriteAllBytes(destinationFile, mp3File);
        }

    }
}
