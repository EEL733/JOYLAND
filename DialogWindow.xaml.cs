using System.Windows;

namespace JOYLAND {
    public partial class DialogWindow : Window {
        public DialogWindow(string message) {
            InitializeComponent();
            this.DataContext = message;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
