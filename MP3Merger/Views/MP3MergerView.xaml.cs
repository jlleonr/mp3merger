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
        }

        private void selectFileName1_Click(object sender, RoutedEventArgs e)
        {

            mp3FilesVMObj.OnSetFile1();
        }

        private void selectFileName2_Click(object sender, RoutedEventArgs e)
        {

            mp3FilesVMObj.OnSetFile2();
        }

        private void setOutDirBtn_Click(object sender, RoutedEventArgs e)
        {
            mp3FilesVMObj.OnSetOutDir();
        }

        private void mergeBtn_Click(object sender, RoutedEventArgs e)
        {
            mp3FilesVMObj.OnMerge();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
