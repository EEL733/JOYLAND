using System.Windows.Controls;

namespace JOYLAND {
    public partial class KFLATAwardPage5 : Page {
        private static KFLATAwardPage6 page = null;

        public KFLATAwardPage5() {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (page == null) {
                page = new KFLATAwardPage6();
            }

            NavigationService.Navigate(page);
        }
    }
}
