using System;
using System.Collections.Generic;
using System.Windows;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace JOYLAND {
    public partial class AssignmentSongListWindow : Window {
        private int playerIndex;
        private int trackIndex;

        public AssignmentSongListWindow(int playerIndex, int trackIndex) {
            InitializeComponent();
            InitData();
            SizeToContent = SizeToContent.Width;

            this.playerIndex = playerIndex;
            this.trackIndex = trackIndex;
        }

        private void InitData() {
            // 左グリッドの準備
            musicGrid1.Columns[0].Header = MusicDataModel.Instance.getCurrentGroupName();
            MusicDataModel.Instance.AllVisible();
            musicGrid1.ItemsSource = MusicDataModel.Instance.generateCurrentGroupList();

            // 右グリッドの準備
            List<MusicData> musicList2 = MusicDataModel.Instance.generateNextGroupList();
            if (musicList2.Count == 0) {
                musicGrid2.Visibility = Visibility.Collapsed;
            } else {
                musicGrid2.Columns[0].Header = MusicDataModel.Instance.getNextGroupName();
                musicGrid2.ItemsSource = musicList2;
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            MusicData music;

            if (musicGrid1.SelectedItem != null) {
                music = musicGrid1.SelectedItem as MusicData;
                if (music.Select) {
                    return;
                }
            } else if (musicGrid2.SelectedItem != null) {
                music = musicGrid2.SelectedItem as MusicData;

                // 残り曲数が足りない場合は選曲不可
                if (!MusicDataModel.Instance.CanSelect(playerIndex, trackIndex)) {
                    MessageBox.Show("残り曲数が足りないため選曲できません");
                    return;
                }

                // ダイアログ表示
                var dialog = new DialogWindow("「" + music.name + "」\r\nを本当に選曲しますか？");
                bool? result = dialog.ShowDialog();
                if (result == false) {
                    return;
                }

                if (music.Select) {
                    return;
                }
                MusicDataModel.Instance.currentGroup++;
            } else {
                // 未選択時は何もしない
                return;
            }

            // 激アツマジヤバ☆ソースコード
            music.Select = true;

            PlayerData player = PlayerDataListModel.Instance.Players[playerIndex];
            MusicData prev = player.musics[trackIndex].Music;
            if (prev != null) {
                MusicDataModel.Instance.UnSelect(prev);
            }

            player.musics[trackIndex].Music = music;

            JsonUtil<MusicDataModel>.WriteJsonFile("./output/music-data.json", MusicDataModel.Instance);
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            PlayerData player = PlayerDataListModel.Instance.Players[playerIndex];
            MusicData prev = player.musics[trackIndex].Music;
            if (prev != null) {
                MusicDataModel.Instance.UnSelect(prev);
            }

            player.musics[trackIndex].Music = null;

            JsonUtil<MusicDataModel>.WriteJsonFile("./output/music-data.json", MusicDataModel.Instance);
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
