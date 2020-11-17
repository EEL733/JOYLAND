using System.Windows;

namespace JOYLAND {
    public partial class UserAddWindow : Window {
        private UserAddWindowVM vm;

        public UserAddWindow() {
            InitializeComponent();
            vm = new UserAddWindowVM();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            vm.Save();
            Close();
        }
    }
}
