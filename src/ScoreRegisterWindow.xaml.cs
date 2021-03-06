﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JOYLAND {
    public partial class ScoreRegisterWindow : Window {
        private ScoreRegisterWindowVM vm;

        public ScoreRegisterWindow(int playerId) {
            InitializeComponent();
            vm = new ScoreRegisterWindowVM(playerId);
            DataContext = vm;
        }

        private void SelectMusicButton_Click(object sender, RoutedEventArgs e) {
            int trackId = int.Parse((string)((Button)sender).CommandParameter);
            AssignmentSongListWindow window = new AssignmentSongListWindow {
                selectMusic = vm.GetSelectMusic(trackId)
            };
            window.ShowDialog();
            if (window.selectMusic != null) {
                vm.Select(trackId, window.selectMusic);
            } else {
                vm.UnSelect(trackId);
            }
        }

        private void DetailInputMenu_Click(object sender, RoutedEventArgs e) {
            int trackId = int.Parse((string)((MenuItem)sender).CommandParameter);
            DetailInputWindow window = new DetailInputWindow(vm.GetSelectMusicData(trackId));
            window.ShowDialog();
            vm.Calc();
        }

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e) {
            CalcAndSave();
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            CalcAndSave();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e) {
            CalcAndSave();
        }

        private void CalcAndSave() {
            vm.Calc();
        }
    }
}
