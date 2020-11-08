using JOYLAND.Model;
using JOYLAND.Repository;
using System.Collections.Generic;
using System.ComponentModel;

namespace JOYLAND {
    internal class UserListWindowVM : INotifyPropertyChanged {
        private PlayerDataRepository repository = PlayerDataRepository.Instance;

        public List<PlayerData> AllUser {
            get {
                return repository.GetAll();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
