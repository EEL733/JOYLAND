using System.ComponentModel;

namespace JOYLAND {
    internal class DetailInputWindowVM : INotifyPropertyChanged {
        public int critical { get; set; }
        public int near { get; set; }
        public int error { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
