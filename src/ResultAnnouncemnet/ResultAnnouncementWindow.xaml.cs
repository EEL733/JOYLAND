using System.Windows.Navigation;

namespace JOYLAND {
    public partial class ResultAnnouncementWindow : NavigationWindow {
        public ResultAnnouncementWindow() {
            InitializeComponent();
            DataContext = new ResultAnnouncementWindowVM();
        }

        private void Window_Closing(object sender, System.EventArgs e) {
            new TitleWindow().Show();
        }
    }
}
