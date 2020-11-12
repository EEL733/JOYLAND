﻿using JOYLAND.Model;
using JOYLAND.Util;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JOYLAND {
    public partial class DetailInputWindow : Window {
        public SelectMusicData selectMusicData { get; set; }
        private DetailInputWindowVM vm;

        public DetailInputWindow(SelectMusicData selectMusicData) {
            InitializeComponent();
            this.selectMusicData = selectMusicData;
            vm = new DetailInputWindowVM() {
                critical = selectMusicData.critical,
                near = selectMusicData.near,
                error = selectMusicData.error
            };
            DataContext = vm;
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            TextBox textBox = sender as TextBox;
            e.Handled = !checkDeclaredScore(textBox.Text, e.Text, textBox.SelectionStart, textBox.SelectionLength);
        }

        private bool checkDeclaredScore(string pre, string input, int selectionStart, int selectionLength) {
            Regex regex = new Regex("^[0-9]{0,4}$");
            string newStr = pre.Remove(selectionStart, selectionLength).Insert(selectionStart, input);
            return regex.IsMatch(newStr);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            selectMusicData.critical = vm.critical;
            selectMusicData.near = vm.near;
            selectMusicData.error = vm.error;
            selectMusicData.actualScore = CalcUtil.CalcActualScore(vm.critical, vm.near, vm.error);
            Close();
        }
    }
}
