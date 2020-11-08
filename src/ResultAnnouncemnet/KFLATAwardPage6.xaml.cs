using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage6 : Page {
        private static EEL733AwardPage1 page = null;

        public KFLATAwardPage6() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage1();
            }

            NavigationService.Navigate(page);
        }
    }
}
