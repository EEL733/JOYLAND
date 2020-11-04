using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace JOYLAND {
    public partial class ScoreRegisterWindow : Window {
        private int playerIndex;

        public ScoreRegisterWindow(int playerIndex) {
            InitializeComponent();
            ScoreRegisterWindowViewModel vm = new ScoreRegisterWindowViewModel(playerIndex);
            DataContext = vm;

            this.playerIndex = playerIndex;
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            Window window = new AssignmentSongListWindow(playerIndex, 0);
            window.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            Window window = new AssignmentSongListWindow(playerIndex, 1);
            window.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            Window window = new AssignmentSongListWindow(playerIndex, 2);
            window.ShowDialog();
        }

        private void declaredScoreTextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkDeclaredScore(declaredScoreTextBox1.Text, e.Text);
        }

        private void declaredScoreTextBox2_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkDeclaredScore(declaredScoreTextBox2.Text, e.Text);
        }

        private void declaredScoreTextBox3_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkDeclaredScore(declaredScoreTextBox3.Text, e.Text);
        }

        private void actualScoreTextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkActualScore(actualScoreTextBox1.Text, e.Text);
        }

        private void actualScoreTextBox2_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkActualScore(actualScoreTextBox2.Text, e.Text);
        }

        private void actualScoreTextBox3_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !checkActualScore(actualScoreTextBox3.Text, e.Text);
        }

        private bool checkDeclaredScore(string pre, string input) {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(input)) {
                return false;
            }

            int value = int.Parse(pre + input);
            return 0 <= value && value <= 1000;
        }

        private bool checkActualScore(string pre, string input) {
            Regex regex = new Regex("[0-9]+");
            if (!regex.IsMatch(input)) {
                return false;
            }

            int value = int.Parse(pre + input);
            return 0 <= value && value <= 10000000;
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            outputJson();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e) {
            ((ScoreRegisterWindowViewModel)DataContext).EnterCommand.Execute(null);
            outputJson();
        }

        private void outputJson() {
            PlayerData data = PlayerDataListModel.Instance.Players[playerIndex];
            string filePath = "./output/player-" + data.id + ".json";
            JsonUtil<PlayerData>.WriteJsonFile(filePath, data);
        }
    }
}
