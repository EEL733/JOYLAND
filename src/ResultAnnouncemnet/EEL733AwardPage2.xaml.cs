using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage2 : Page {
        private static EEL733AwardPage3 page = null;

        public EEL733AwardPage2() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage3();
            }

            NavigationService.Navigate(page);
        }
    }
}
