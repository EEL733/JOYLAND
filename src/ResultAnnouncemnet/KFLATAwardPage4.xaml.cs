using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage4 : Page {
        private static KFLATAwardPage5 page = null;

        public KFLATAwardPage4() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetKFLATAward4();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage5();
            }

            NavigationService.Navigate(page);
        }
    }
}
