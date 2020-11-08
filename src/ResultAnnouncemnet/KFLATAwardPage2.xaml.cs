using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage2 : Page {
        private static KFLATAwardPage3 page = null;

        public KFLATAwardPage2() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage3();
            }

            NavigationService.Navigate(page);
        }
    }
}
