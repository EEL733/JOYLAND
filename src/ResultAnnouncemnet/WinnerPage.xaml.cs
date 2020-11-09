using System.Windows.Controls;

namespace JOYLAND {
    public partial class WinnerPage : Page {
        private static KFLATAwardPage1 page = null;

        public WinnerPage() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetWinner();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage1();
            }

            NavigationService.Navigate(page);
        }
    }
}
