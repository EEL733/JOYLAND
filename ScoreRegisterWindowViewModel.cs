using System;
using System.ComponentModel;
using System.Windows.Input;

namespace JOYLAND {
    class EnterCommand : ICommand {
        private int playerIndex;
        public event EventHandler CanExecuteChanged;

        public EnterCommand(int playerIndex) {
            this.playerIndex = playerIndex;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            PlayerDataListModel.Instance.Players[playerIndex].Calc();
        }
    }

    public class ScoreRegisterWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public PlayerData player { get; set; }
        public ICommand EnterCommand { get; set; }

        public ScoreRegisterWindowViewModel(int order) {
            this.player = PlayerDataListModel.Instance.Players[order];
            this.EnterCommand = new EnterCommand(order);
        }
    }
}