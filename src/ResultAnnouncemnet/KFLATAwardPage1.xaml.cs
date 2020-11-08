using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage1 : Page {
        private static KFLATAwardPage2 page = null;

        public KFLATAwardPage1() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage2();
            }

            NavigationService.Navigate(page);
        }
    }
}
