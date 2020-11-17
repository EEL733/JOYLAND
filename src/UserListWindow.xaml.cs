using JOYLAND.Model;
using System.Windows;

namespace JOYLAND {
    public partial class UserListWindow : Window {
        private UserListWindowVM vm = new UserListWindowVM();

        public UserListWindow() {
            InitializeComponent();
            DataContext = vm;
        }

        private void UserAddButtonClick(object sender, RoutedEventArgs e) {
            UserAddWindow window = new UserAddWindow();
            window.ShowDialog();
            vm.OnPropertyChange("AllUser");
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {
            if (playerListGrid.SelectedItems.Count != 1) {
                return;
            }

            PlayerData selectUser = (PlayerData)playerListGrid.SelectedItem;
            ScoreRegisterWindow window = new ScoreRegisterWindow(selectUser.id);
            window.ShowDialog();
            vm.OnPropertyChange("AllUser");
        }

        private void Window_Closing(object sender, System.EventArgs e) {
            new TitleWindow().Show();
        }
    }
}
