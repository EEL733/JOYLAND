using JOYLAND.Model;
using JOYLAND.Repository;
using JOYLAND.Util;
using System.ComponentModel;

namespace JOYLAND {
    internal class ScoreRegisterWindowVM : INotifyPropertyChanged {
        private readonly PlayerDataRepository playerDataRepository = PlayerDataRepository.Instance;
        public PlayerData player { get; }

        public ScoreRegisterWindowVM(int playerId) {
            player = playerDataRepository.Get(playerId);
        }

        public MusicData GetSelectMusic(int trackId) {
            return GetSelectMusicData(trackId)?.music;
        }

        public SelectMusicData GetSelectMusicData(int trackId) {
            return player.musics.ContainsKey(trackId) ? player.musics[trackId] : null;
        }

        public void Select(int trackId, MusicData music) {
            if (music == null || GetSelectMusic(trackId) == music) {
                return;
            }

            PrevDelete(trackId);
            player.musics[trackId] = new SelectMusicData(music);
            Save();
        }

        public void UnSelect(int trackId) {
            PrevDelete(trackId);
            player.musics.Remove(trackId);
            Save();
        }

        public void Calc() {
            int sum = 0;
            for (int i = 0; i < 3; i++) {
                if (player.musics.ContainsKey(i)) {
                    SelectMusicData data = player.musics[i];
                    if (data != null) {
                        data.earnedScore = CalcUtil.ClacEarnedScore(player.vf, player.vfLank, data.declaredScore * 10000, data.actualScore);
                        sum += data.earnedScore;
                    }
                }
            }
            player.scoreAll = sum;
            Save();
        }

        public void Save() {
            playerDataRepository.Save(player);
            OnPropertyChange("player");
        }

        private void PrevDelete(int trackId) {
            if (player.musics.ContainsKey(trackId)) {
                SelectMusicData prev = player.musics[trackId];
                if (prev != null) {
                    prev.music.select = false;
                }
            }
            Save();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
