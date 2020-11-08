using JOYLAND.Model;
using System.Windows;

namespace JOYLAND {
    public partial class UserListWindow : Window {
        UserListWindowVM vm = new UserListWindowVM();

        public UserListWindow() {
            InitializeComponent();
            DataContext = vm;
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
    }
}
