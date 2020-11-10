using JOYLAND.Model;
using JOYLAND.Repository;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace JOYLAND {
    internal class ResultAnnouncementWindowVM : INotifyPropertyChanged {
        private readonly PlayerDataRepository repository = PlayerDataRepository.Instance;
        private readonly List<PlayerData> playerList = new List<PlayerData>();

        public ResultAnnouncementWindowVM() {
            playerList = repository.GetAll();
        }

        public string WinnerName { get; set; }
        public string WinnerSub { get; set; }
        public string KFLATAward1Name { get; set; }
        public string KFLATAward1Sub { get; set; }
        public string KFLATAward2Name { get; set; }
        public string KFLATAward2Sub { get; set; }
        public string KFLATAward3Name { get; set; }
        public string KFLATAward3Sub { get; set; }
        public string KFLATAward4Name { get; set; }
        public string KFLATAward4Sub { get; set; }
        public string KFLATAward5Name { get; set; }
        public string KFLATAward5Sub { get; set; }
        public string KFLATAward6Name { get; set; }
        public string KFLATAward6Sub { get; set; }
        public string EEL733Award1Name { get; set; }
        public string EEL733Award1Sub { get; set; }
        public string EEL733Award2Name { get; set; }
        public string EEL733Award2Sub { get; set; }
        public string EEL733Award3Name { get; set; }
        public string EEL733Award3Sub { get; set; }
        public string EEL733Award4Name { get; set; }
        public string EEL733Award4Sub { get; set; }
        public string EEL733Award5Name { get; set; }
        public string EEL733Award5Sub { get; set; }

        // 優勝者
        public void GetWinner() {
            PlayerData winner = repository.Get(0);
            foreach (PlayerData data in playerList) {
                if (data.scoreAll >= winner.scoreAll) {
                    winner = data;
                }
            }

            WinnerName = winner.userName;
            OnPropertyChange("WinnerName");
            WinnerSub = winner.scoreAll.ToString();
            OnPropertyChange("WinnerSub");
        }

        // 実プレースコアの端数3桁が最も210に近い人
        public void GetKFLATAward1() {
            PlayerData result = null;
            int targetScore = 0;
            int min = 1000;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int tmp = Math.Abs((selectData.actualScore % 1000) - 210);
                    if (Math.Abs((selectData.actualScore % 1000) - 210) < min) {
                        min = tmp;
                        targetScore = selectData.actualScore;
                        result = data;
                    }
                }
            }

            KFLATAward1Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward1Name");
            KFLATAward1Sub = result != null ? $"スコア:{targetScore,8}\n差分　:{min,8}" : "";
            OnPropertyChange("KFLATAward1Sub");
        }

        // 一度に宣言スコアを下回った点数が最も大きい人
        public void GetKFLATAward2() {
            PlayerData result = null;
            int max = -1;
            SelectMusicData target = null;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int declaredScore = selectData.declaredScore * 10000;
                    if (selectData.actualScore <= declaredScore * 10000) {
                        if (max < (declaredScore - selectData.actualScore)) {
                            max = declaredScore - selectData.actualScore;
                            result = data;
                            target = selectData;
                        }
                    }
                }
            }

            KFLATAward2Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward2Name");
            KFLATAward2Sub = result != null ? $"宣言:{(target?.declaredScore ?? 0) * 10000,8}\n実際:{target?.actualScore ?? 0,8}\n差分:{max,8}" : "";
            OnPropertyChange("KFLATAward2Sub");
        }

        // 最も高い宣言を成功させた人
        public void GetKFLATAward3() {
            PlayerData result = null;
            int max = 0;
            SelectMusicData target = null;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    if (selectData.actualScore >= selectData.declaredScore * 10000) {
                        if (max < selectData.declaredScore) {
                            max = selectData.declaredScore;
                            result = data;
                            target = selectData;
                        }
                    }
                }
            }

            KFLATAward3Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward3Name");
            KFLATAward3Sub = result != null ? $"宣言:{(target?.declaredScore ?? 0) * 10000,8}\n実際:{target?.actualScore ?? 0,8}" : "";
            OnPropertyChange("KFLATAward3Sub");
        }

        // 選曲された楽曲のうち最もBPMが高い楽曲を選んだ人
        public void GetKFLATAward4() {
            PlayerData result = null;
            int max = 0;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    if (max < selectData.music.bpm) {
                        max = selectData.music.bpm;
                        result = data;
                    }
                }
            }

            KFLATAward4Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward4Name");
            KFLATAward4Sub = result != null ? $"BPM:{max}" : "";
            OnPropertyChange("KFLATAward4Sub");
        }

        // 3曲のニア合計が最も48に近い人
        public void GetKFLATAward5() {
            PlayerData result = null;
            int min = int.MaxValue;
            foreach (PlayerData data in playerList) {
                if (data.musics.Count == 3) {
                    int tmp = Math.Abs(data.musics.Sum(e => e.Value.near) - 48);
                    if (min > tmp) {
                        min = tmp;
                        result = data;
                    }
                }
            }

            KFLATAward5Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward5Name");
            KFLATAward5Sub = result != null ? $"合計:{min}" : "";
            OnPropertyChange("KFLATAward5Sub");
        }

        // 3曲に含まれるゲーミングFXチップの合計が最も多い人
        public void GetKFLATAward6() {
            PlayerData result = null;
            int max = 0;
            foreach (PlayerData data in playerList) {
                if (data.musics.Count == 3) {
                    int cnt = data.musics.Sum(e => e.Value.music.fx);
                    if (max < cnt) {
                        max = cnt;
                        result = data;
                    }
                }
            }

            KFLATAward6Name = result?.userName ?? "該当者なし";
            OnPropertyChange("KFLATAward6Name");
            KFLATAward6Sub = result != null ? $"合計:{max}" : "";
            OnPropertyChange("KFLATAward6Sub");
        }

        // 「3曲の合計獲得スコア」「獲得スコア」「単曲の実プレースコア」のうち下4桁が2021であるスコアを獲得した人
        public void GetEEL733Award1() {
            List<PlayerData> result = new List<PlayerData>();
            foreach (PlayerData data in playerList) {
                bool all = data.scoreAll % 10000 == 2021;
                bool act1 = (data.musics.ContainsKey(0) ? data.musics[0].actualScore : 0) % 10000 == 2021;
                bool act2 = (data.musics.ContainsKey(1) ? data.musics[1].actualScore : 0) % 10000 == 2021;
                bool act3 = (data.musics.ContainsKey(2) ? data.musics[2].actualScore : 0) % 10000 == 2021;
                bool ear1 = (data.musics.ContainsKey(0) ? data.musics[0].earnedScore : 0) % 10000 == 2021;
                bool ear2 = (data.musics.ContainsKey(1) ? data.musics[1].earnedScore : 0) % 10000 == 2021;
                bool ear3 = (data.musics.ContainsKey(2) ? data.musics[2].earnedScore : 0) % 10000 == 2021;
                if (all || act1 || act2 || act3 || ear1 || ear2 || ear3) {
                    result.Add(data);
                }
            }

            if (result.Count == 0) {
                EEL733Award1Name = "該当者なし";
                OnPropertyChange("EEL733Award1Name");
            } else {
                EEL733Award1Name = result.Select(data => data.userName).Aggregate((a, b) => a + "\n" + b);
                OnPropertyChange("EEL733Award1Name");
            }
        }

        // 東方リミックス楽曲を最も多く選曲した人
        public void GetEEL733Award2() {
            PlayerData result = null;
            int max = 0;
            foreach (PlayerData data in playerList) {
                int cnt = data.musics.Select(e => e.Value.music.touhou).Count();
                if (max < cnt) {
                    max = cnt;
                    result = data;
                }
            }

            EEL733Award2Name = result?.userName ?? "該当者なし";
            OnPropertyChange("EEL733Award2Name");
            EEL733Award2Sub = result != null ? $"選曲数:{max}" : "";
            OnPropertyChange("EEL733Award2Sub");
        }

        // ボルテIIIの譜面を最も多く選曲した人
        public void GetEEL733Award3() {
            PlayerData result = null;
            int max = 0;
            foreach (PlayerData data in playerList) {
                int cnt = data.musics.Select(e => e.Value.music.version == 3).Count();
                if (max < cnt) {
                    max = cnt;
                    result = data;
                }
            }

            EEL733Award3Name = result?.userName ?? "該当者なし";
            OnPropertyChange("EEL733Award3Name");
            EEL733Award3Sub = result != null ? $"選曲数:{max}" : "";
            OnPropertyChange("EEL733Award3Sub");
        }

        // 最も低いスコアを宣言した人
        public void GetEEL733Award4() {
            PlayerData result = null;
            int min = 1000;
            SelectMusicData target = null;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    if (min > selectData.declaredScore) {
                        min = selectData.declaredScore;
                        result = data;
                        target = selectData;
                    }
                }
            }

            EEL733Award4Name = result?.userName ?? "該当者なし";
            OnPropertyChange("EEL733Award4Name");
            EEL733Award4Sub = result != null ? $"宣言:{target.declaredScore * 10000,8}\n実際:{target.actualScore,8}" : "";
            OnPropertyChange("EEL733Award4Sub");
        }

        // 3曲の実プレースコアについて、分散が最も小さい人
        public void GetEEL733Award5() {
            PlayerData result = null;
            long min = long.MaxValue;
            foreach (PlayerData data in playerList) {
                long tmp = data.variance140;
                if (min > tmp) {
                    min = tmp;
                    result = data;
                }
            }

            EEL733Award5Name = result?.userName ?? "該当者なし";
            OnPropertyChange("EEL733Award5Name");
            EEL733Award5Sub = result != null ? $"分散:{min * 2 / 9.0:F2}" : "";
            OnPropertyChange("EEL733Award5Sub");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
