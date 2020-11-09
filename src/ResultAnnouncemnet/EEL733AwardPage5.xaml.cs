using System.Windows.Controls;

namespace JOYLAND {
    public partial class EEL733AwardPage5 : Page {
        public EEL733AwardPage5() {
            InitializeComponent();
        }

        private void PresentButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            ResultAnnouncementWindowVM vm = DataContext as ResultAnnouncementWindowVM;
            vm.GetEEL733Award5();
        }
    }
}
