using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace JOYLAND {
    public partial class ScoreRegisterWindow : Window {
        private ScoreRegisterWindowVM vm;

        public ScoreRegisterWindow(int playerId) {
            InitializeComponent();
            vm = new ScoreRegisterWindowVM(playerId);
            DataContext = vm;
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            AssignmentSongListWindow window = new AssignmentSongListWindow {
                selectMusic = vm.GetSelectMusic(0)
            };
            window.ShowDialog();
            if (window.selectMusic != null) {
                vm.Select(0, window.selectMusic);
            } else {
                vm.UnSelect(0);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            AssignmentSongListWindow window = new AssignmentSongListWindow {
                selectMusic = vm.GetSelectMusic(1)
            };
            window.ShowDialog();
            if (window.selectMusic != null) {
                vm.Select(1, window.selectMusic);
            } else {
                vm.UnSelect(1);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            AssignmentSongListWindow window = new AssignmentSongListWindow() {
                selectMusic = vm.GetSelectMusic(2)
            };
            window.ShowDialog();
            if (window.selectMusic != null) {
                vm.Select(2, window.selectMusic);
            } else {
                vm.UnSelect(2);
            }
        }

        private void DetailInputMenu1_Click(object sender, RoutedEventArgs e) {
            DetailInputWindow window = new DetailInputWindow(vm.GetSelectMusicData(0));
            window.ShowDialog();
            vm.Calc();
        }

        private void DetailInputMenu2_Click(object sender, RoutedEventArgs e) {
            DetailInputWindow window = new DetailInputWindow(vm.GetSelectMusicData(1));
            window.ShowDialog();
            vm.Calc();
        }

        private void DetailInputMenu3_Click(object sender, RoutedEventArgs e) {
            DetailInputWindow window = new DetailInputWindow(vm.GetSelectMusicData(2));
            window.ShowDialog();
            vm.Calc();
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

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e) {
            CalcAndSave();
        }

        private void CalcAndSave() {
            vm.Calc();
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            CalcAndSave();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e) {
            CalcAndSave();
        }
    }
}
