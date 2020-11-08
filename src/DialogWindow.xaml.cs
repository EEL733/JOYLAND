using System.Windows;

namespace JOYLAND {
    public partial class DialogWindow : Window {
        public DialogWindow(string message) {
            InitializeComponent();
            DataContext = message;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
        }
    }
}
