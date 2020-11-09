using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage3 : Page {
        private static KFLATAwardPage4 page = null;

        public KFLATAwardPage3() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetKFLATAward3();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage4();
            }

            NavigationService.Navigate(page);
        }
    }
}
