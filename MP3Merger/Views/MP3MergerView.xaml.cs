using MP3Merger1.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MP3Merger2.Views
{
    /// <summary>
    /// Interaction logic for MP3MergerView.xaml
    /// </summary>
    public partial class MP3MergerView : UserControl
    {
        private readonly MP3FilesViewModel mp3FilesVMObj;

        public MP3MergerView()
        {
            InitializeComponent();
            mp3FilesVMObj = new MP3FilesViewModel();
            DataContext = mp3FilesVMObj;
            txtBox1.Text = mp3FilesVMObj.MP3Files.FileName1;
            txtBox2.Text = mp3FilesVMObj.MP3Files.FileName2;
            txtBox3.Text = mp3FilesVMObj.MP3Files.OutputDirectory;
        }

        private void btn1_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            mp3FilesVMObj.OnSetFile1();
            txtBox1.Text = mp3FilesVMObj.MP3Files.FileName1;
        }

        private void btn2_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            mp3FilesVMObj.OnSetFile2();
            txtBox2.Text = mp3FilesVMObj.MP3Files.FileName2;
        }

        private void btn3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mp3FilesVMObj.OnSetOutDir();
            txtBox3.Text = mp3FilesVMObj.MP3Files.OutputDirectory;
        }

        private void btn4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mp3FilesVMObj.OnMerge();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
