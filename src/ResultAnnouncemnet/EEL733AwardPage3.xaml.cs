using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage3 : Page {
        private static EEL733AwardPage4 page = null;

        public EEL733AwardPage3() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetEEL733Award3();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage4();
            }

            NavigationService.Navigate(page);
        }
    }
}
