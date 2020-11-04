using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace JOYLAND {
    public class PlayerData : INotifyPropertyChanged {
        public class SelectMusicData : INotifyPropertyChanged {
            private MusicData music;
            public int declaredScore { get; set; }
            public int actualScore { get; set; }
            private int earnedScore;
            public event PropertyChangedEventHandler PropertyChanged;

            public MusicData Music {
                get { return music; }
                set {
                    music = value;
                    OnPropertyChanged("Music");
                }
            }

            public int EarnedScore {
                get { return earnedScore; }
                set {
                    earnedScore = value;
                    OnPropertyChanged("EarnedScore");
                }
            }

            public void OnPropertyChanged(string name) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }

        internal int playerIndex;
        public int id { get; set; }
        public string userName { get; set; }
        private double vf;
        private VolforceLank vfLank;
        public ObservableCollection<SelectMusicData> musics { get; set; }
        private int scoreAll;
        public event PropertyChangedEventHandler PropertyChanged;

        public PlayerData() {
        }

        public PlayerData(string userName, int id, double vf) {
            this.userName = userName;
            this.id = id;
            this.vf = vf;
            
            musics = new ObservableCollection<SelectMusicData> {
                new SelectMusicData(),
                new SelectMusicData(),
                new SelectMusicData()
            };
            vfLank = VolforceLank.convert(vf);
        }

        public double Vf {
            get { return vf; }
            set {
                vf = value;
                vfLank = VolforceLank.convert(vf);
            }
        }

        public int PlayerNo {
            get { return playerIndex + 1; }
            set { playerIndex = value - 1; }
        }

        public int ScoreAll {
            get { return scoreAll; }
            set {
                scoreAll = value;
                OnPropertyChanged("ScoreAll");
            }
        }

        internal void Calc() {
            for (int i = 0; i < 3; i++) {
                if (musics[i].actualScore == 0) {
                    musics[i].EarnedScore = 0;
                } else {
                    musics[i].EarnedScore = musics[i].declaredScore * 10000;
                    if (musics[i].actualScore < musics[i].declaredScore * 10000) {
                        int diff = (musics[i].declaredScore * 10000) - musics[i].actualScore;
                        int deductionScore = (int)Math.Ceiling(diff * vf / 10) + vfLank.conceded;
                        musics[i].EarnedScore -= deductionScore;
                    }
                }
            }
            ScoreAll = musics.Select(m => m.EarnedScore).Sum();
        }

        public void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
