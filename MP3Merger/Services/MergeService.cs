using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows;

namespace MP3Merger2.Services
{
    class MergeService
    {
        /// <summary>
        /// Merge two mp3 files and put the merged content in the specified path.
        /// </summary>
        /// <param name="fileName1"></param>
        /// <param name="fileName2"></param>
        /// <param name="outputDirectory"></param>
        public static void Mp3Merge(string fileName1, string fileName2, string outputDirectory)
        {
            var fileA = new AudioFileReader(fileName1);

            // Calculate our buffer size, since we're normalizing our samples to floats
            // we'll need to account for that by dividing the file's audio byte count
            // by its bit depth / 8.
            var bufferA = new float[fileA.Length / (fileA.WaveFormat.BitsPerSample / 8)];

            // Now let's populate our buffer with samples.
            fileA.Read(bufferA, 0, bufferA.Length);

            // Do it all over again for the other file.
            var fileB = new AudioFileReader(fileName2);
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
            ConvertWavStreamToMp3File(outputDirectory, final);
            MessageBox.Show("Finished");
        }


        private static void ConvertWavStreamToMp3File(string outputFile, byte[] waveFile)
        {
            using (var ms = new MemoryStream(waveFile))
            using (var wfr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(outputFile, wfr.WaveFormat, LAMEPreset.VBR_100))
            {
                wfr.CopyTo(wtr);
            }
        }

        private void SaveToDisk(byte[] mp3File, string destinationFile)
        {
            File.WriteAllBytes(destinationFile, mp3File);
        }
    }
}
