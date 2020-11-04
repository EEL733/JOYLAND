using System.Windows;

namespace JOYLAND {
    public partial class UserListWindow : Window {
        public UserListWindow() {
            InitializeComponent();
            InitData();
        }

        private void InitData() {
            playerListGrid.ItemsSource = PlayerDataListModel.Instance.Players;
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {
            if (playerListGrid.SelectedItems.Count != 1) {
                return;
            }

            PlayerData selectUser = (PlayerData)playerListGrid.SelectedItem;
            var window = new ScoreRegisterWindow(selectUser.playerIndex);
            window.ShowDialog();
        }
    }
}
