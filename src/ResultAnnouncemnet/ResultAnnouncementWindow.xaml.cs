using System.Windows.Navigation;

namespace JOYLAND {
    public partial class ResultAnnouncementWindow : NavigationWindow {
        public ResultAnnouncementWindow() {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.EventArgs e) {
            new TitleWindow().Show();
        }
    }
}
