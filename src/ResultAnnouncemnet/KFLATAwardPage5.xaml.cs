using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage5 : Page {
        private static KFLATAwardPage6 page = null;

        public KFLATAwardPage5() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetKFLATAward5();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage6();
            }

            NavigationService.Navigate(page);
        }
    }
}
