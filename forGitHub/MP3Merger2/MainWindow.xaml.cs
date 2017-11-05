using Microsoft.Win32;
using MP3Merger1.ViewModel;
using System.Windows;

namespace MP3Merger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        string inputFile1;
        string inputFile2;
        string outputFile;
        */
        public MainWindow()
        {
            /*
            inputFile1 = "";
            inputFile2 = "";
            outputFile = "";
                        */
            InitializeComponent();

        }
        /*
        private void MP3MergerViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            mp3FilesVMObj = new MP3FilesViewModel();
            MP3MergerViewControl.DataContext = mp3FilesVMObj;

            MP3MergerViewControl.txtBox1.Text = mp3FilesVMObj.MP3Files.FileName1;
            MP3MergerViewControl.txtBox2.Text = mp3FilesVMObj.MP3Files.FileName2;
            MP3MergerViewControl.txtBox3.Text = mp3FilesVMObj.MP3Files.OutputDirectory;
        }
        */

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            /*
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog1.ShowDialog() == true)
            {
                mp3FilesVMObj.MP3Files.FileName1 = openFileDialog1.FileName;
                //inputFile1 = openFileDialog1.FileName;
            }
            */

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
/*
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "MP3 files (*.mp3)|*.mp3";
            if (openFileDialog2.ShowDialog() == true)
            {
                mp3FilesVMObj.MP3Files.FileName1 = openFileDialog2.FileName;
                //inputFile2 = openFileDialog2.FileName;
            }
            */
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            saveFileDialog.DefaultExt = "mp3";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                label3.Content = saveFileDialog.FileName;
                outputFile = saveFileDialog.FileName;
            }
            */

        }

        public void btn4_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (!(string.IsNullOrEmpty(inputFile1) 
                || string.IsNullOrEmpty(inputFile2) 
                || string.IsNullOrEmpty(outputFile)))
            {
                this.mp3Merger();
            }
            */
        }

        private void mp3Merger()
        {
            /*
            var fileA = new AudioFileReader(inputFile1);

            // Calculate our buffer size, since we're normalizing our samples to floats
            // we'll need to account for that by dividing the file's audio byte count
            // by its bit depth / 8.
            var bufferA = new float[fileA.Length / (fileA.WaveFormat.BitsPerSample / 8)];

            // Now let's populate our buffer with samples.
            fileA.Read(bufferA, 0, bufferA.Length);

            // Do it all over again for the other file.
            var fileB = new AudioFileReader(inputFile2);
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
            convertWavStreamToMp3File(outputFile, final);
            MessageBox.Show("Finished");
            Close();
            */
        }

        public static void convertWavStreamToMp3File(string outputFile, byte[] waveFile)
        {
            /*
            using (var ms = new MemoryStream(waveFile))
            using (var wfr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(outputFile, wfr.WaveFormat, LAMEPreset.VBR_100))
            {
                wfr.CopyTo(wtr);
            }
            */
        }

        public void saveToDisk(byte[] mp3File, string destinationFile)
        {
            /*
            File.WriteAllBytes(destinationFile, mp3File);
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            Close();
            */
        }
    }
}
