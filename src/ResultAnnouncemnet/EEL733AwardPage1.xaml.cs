using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage1 : Page {
        private static EEL733AwardPage2 page = null;

        public EEL733AwardPage1() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new EEL733AwardPage2();
            }

            NavigationService.Navigate(page);
        }
    }
}
