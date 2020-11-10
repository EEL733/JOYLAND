using JOYLAND.Model;
using JOYLAND.Repository;
using System.Collections.Generic;
using System.ComponentModel;

namespace JOYLAND {
    internal class AssignmentSongListWindowVM : INotifyPropertyChanged {
        private readonly MusicGroupRepository musicGroupRepository = MusicGroupRepository.Instance;
        private readonly MusicDataRepository musicDataRepository = MusicDataRepository.Instance;
        private readonly PlayerDataRepository playerDataRepository = PlayerDataRepository.Instance;

        public List<MusicData> CurrentGroupList {
            get {
                int group = musicGroupRepository.GetCurrentGroup();
                return musicDataRepository.GetByGroup(group, true);
            }
        }

        public List<MusicData> NextGroupList {
            get {
                int group = musicGroupRepository.GetCurrentGroup();
                return musicDataRepository.GetByGroup(group + 1, false);
            }
        }

        internal string CurrentGroupHeader() {
            return musicGroupRepository.GetCurrentGroupHeader();
        }

        internal string NextGroupHeader() {
            return musicGroupRepository.GetNextGroupHeader();
        }

        internal bool CanSelect() {
            int group = musicGroupRepository.GetCurrentGroup();
            int requiredTrackCount = playerDataRepository.GetRequiredTrackCount();
            return musicDataRepository.CanSelect(requiredTrackCount, group);
        }

        internal void IncrementGroupNo() {
            musicGroupRepository.SelectNextGroup();
        }

        internal void Select(MusicData music) {
            music.select = true;
            musicDataRepository.Save(music);
        }

        internal void UnSelect(MusicData music) {
            if (music != null) {
                music.select = false;
                musicDataRepository.Save(music);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
