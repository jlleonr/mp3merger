using MP3Merger1.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MP3Merger2.Views
{
    public partial class MP3MergerView : UserControl
    {
        private readonly MP3FilesViewModel mp3FilesVMObj;

        /// <summary>
        /// Set the ViewModel of this view and the DataContext.
        /// </summary>
        public MP3MergerView()
        {
            InitializeComponent();
            mp3FilesVMObj = new MP3FilesViewModel();
            DataContext = mp3FilesVMObj;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
