using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage3 : Page {
        private static EEL733AwardPage4 page = null;

        public EEL733AwardPage3() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage4();
            }

            NavigationService.Navigate(page);
        }
    }
}
