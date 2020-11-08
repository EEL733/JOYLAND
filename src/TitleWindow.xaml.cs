using System.Windows;

namespace JOYLAND {
    public partial class TitleWindow : Window {
        public TitleWindow() {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e) {
            UserListWindow window = new UserListWindow();
            window.Show();
            Close();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e) {
            ResultAnnouncementWindow window = new ResultAnnouncementWindow();
            window.Show();
            Close();
        }
    }
}
