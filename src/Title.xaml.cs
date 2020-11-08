using System.Windows;

namespace JOYLAND {
    public partial class Title : Window {
        public Title() {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e) {
            UserListWindow window = new UserListWindow();
            window.Show();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
