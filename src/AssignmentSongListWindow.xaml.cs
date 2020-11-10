using JOYLAND.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace JOYLAND {
    public partial class AssignmentSongListWindow : Window {
        public MusicData selectMusic { get; set; } = null;
        private AssignmentSongListWindowVM vm = new AssignmentSongListWindowVM();

        public AssignmentSongListWindow() {
            InitializeComponent();
            DataContext = vm;
            SizeToContent = SizeToContent.Width;
            InitData();
        }

        private void InitData() {
            musicGrid1.Columns[0].Header = vm.CurrentGroupHeader();
            musicGrid2.Columns[0].Header = vm.NextGroupHeader();

            if (vm.NextGroupList.Count == 0) {
                musicGrid2.Visibility = Visibility.Collapsed;
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            MusicData music;

            if (musicGrid1.SelectedItem != null) {
                music = musicGrid1.SelectedItem as MusicData;
                if (music.select) {
                    return;
                }
            } else if (musicGrid2.SelectedItem != null) {
                music = musicGrid2.SelectedItem as MusicData;

                // 残り曲数が足りない場合は選曲不可
                if (!vm.CanSelect()) {
                    MessageBox.Show("残り曲数が足りないため選曲できません");
                    return;
                }

                // ダイアログ表示
                DialogWindow dialog = new DialogWindow("「" + music.name + "」\r\nを本当に選曲しますか？");
                if (dialog.ShowDialog() == false) {
                    return;
                }

                vm.IncrementGroupNo();
            } else {
                // 未選択時は何もしない
                return;
            }

            vm.Select(music);
            selectMusic = music;
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            vm.UnSelect(selectMusic);
            selectMusic = null;
            Close();
        }

        private void musicGrid1_CurrentCellChanged(object sender, EventArgs e) {
            musicGrid2.SelectedIndex = -1;
        }

        private void musicGrid2_CurrentCellChanged(object sender, EventArgs e) {
            musicGrid1.SelectedIndex = -1;
        }

        private void musicGrid1_PreviewKeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }

        private void musicGrid2_PreviewKeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }
    }
}
