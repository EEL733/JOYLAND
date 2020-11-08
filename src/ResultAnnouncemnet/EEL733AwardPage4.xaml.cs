using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage4 : Page {
        private static EEL733AwardPage5 page = null;

        public EEL733AwardPage4() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage5();
            }

            NavigationService.Navigate(page);
        }
    }
}
