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
            HashSet<string> result = new HashSet<string>();
            int min = 1000;
            int targetScore = 0;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int tmp = Math.Abs((selectData.actualScore % 1000) - 210);
                    if (tmp < min) {
                        min = tmp;
                        targetScore = selectData.actualScore;
                        result.Clear();
                        result.Add(data.userName);
                    } else if (tmp == min) {
                        result.Add(data.userName);
                    }
                }
            }

            KFLATAward1Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward1Name");
            KFLATAward1Sub = result.Count > 0 ? $"スコア:{targetScore,8}\n差分　:{min,8}" : "";
            OnPropertyChange("KFLATAward1Sub");
        }

        // 一度に宣言スコアを下回った点数が最も大きい人
        public void GetKFLATAward2() {
            HashSet<string> result = new HashSet<string>();
            int max = -1;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int declaredScore = selectData.declaredScore * 10000;
                    if (selectData.actualScore < declaredScore) {
                        int diff = declaredScore - selectData.actualScore;
                        if (max < diff) {
                            max = diff;
                            result.Clear();
                            result.Add(data.userName);
                        } else if (max == diff) {
                            result.Add(data.userName);
                        }
                    }
                }
            }

            KFLATAward2Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward2Name");
            KFLATAward2Sub = result.Count > 0 ? $"差分:{max}" : "";
            OnPropertyChange("KFLATAward2Sub");
        }

        // 最も高い宣言を成功させた人
        public void GetKFLATAward3() {
            HashSet<string> result = new HashSet<string>();
            int max = 0;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int declaredScore = selectData.declaredScore * 10000;
                    if (selectData.actualScore >= declaredScore) {
                        if (max < declaredScore) {
                            max = declaredScore;
                            result.Clear();
                            result.Add(data.userName);
                        } else if (max == declaredScore) {
                            result.Add(data.userName);
                        }
                    }
                }
            }

            KFLATAward3Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward3Name");
            KFLATAward3Sub = result.Count > 0 ? $"宣言スコア:{max}" : "";
            OnPropertyChange("KFLATAward3Sub");
        }

        // 選曲された楽曲のうち最もBPMが高い楽曲を選んだ人
        public void GetKFLATAward4() {
            HashSet<string> result = new HashSet<string>();
            int max = 0;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int bpm = selectData.music.bpm;
                    if (max < bpm) {
                        max = bpm;
                        result.Clear();
                        result.Add(data.userName);
                    } else if (max == bpm) {
                        result.Add(data.userName);
                    }
                }
            }

            KFLATAward4Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward4Name");
            KFLATAward4Sub = result.Count > 0 ? $"最高選曲BPM:{max}" : "";
            OnPropertyChange("KFLATAward4Sub");
        }

        // 3曲のニア合計が最も48に近い人
        public void GetKFLATAward5() {
            HashSet<string> result = new HashSet<string>();
            int min = int.MaxValue;
            int near = 0;
            foreach (PlayerData data in playerList) {
                if (data.musics.Count == 3) {
                    int cnt = data.musics.Sum(e => e.Value.near);
                    int tmp = Math.Abs(cnt - 48);
                    if (min > tmp) {
                        min = tmp;
                        near = cnt;
                        result.Clear();
                        result.Add(data.userName);
                    } else if (min == tmp) {
                        result.Add(data.userName);
                    }
                }
            }

            KFLATAward5Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward5Name");
            KFLATAward5Sub = result.Count > 0 ? $"合計ニア数:{near}" : "";
            OnPropertyChange("KFLATAward5Sub");
        }

        // 3曲に含まれるゲーミングFXチップの合計が最も多い人
        public void GetKFLATAward6() {
            HashSet<string> result = new HashSet<string>();
            int max = 1;
            foreach (PlayerData data in playerList) {
                if (data.musics.Count == 3) {
                    int cnt = data.musics.Sum(e => e.Value.music.fx);
                    if (max < cnt) {
                        max = cnt;
                        result.Clear();
                        result.Add(data.userName);
                    } else if (max == cnt) {
                        result.Add(data.userName);
                    }
                }
            }

            KFLATAward6Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("KFLATAward6Name");
            KFLATAward6Sub = result.Count > 0 ? $"合計FXチップ:{max}" : "";
            OnPropertyChange("KFLATAward6Sub");
        }

        // 「3曲の合計獲得スコア」「獲得スコア」「単曲の実プレースコア」のうち下4桁が2021であるスコアを獲得した人
        public void GetEEL733Award1() {
            List<string> result = new List<string>();
            foreach (PlayerData data in playerList) {
                bool all = data.scoreAll % 10000 == 2021;
                bool act1 = (data.musics.ContainsKey(0) ? data.musics[0].actualScore : 0) % 10000 == 2021;
                bool act2 = (data.musics.ContainsKey(1) ? data.musics[1].actualScore : 0) % 10000 == 2021;
                bool act3 = (data.musics.ContainsKey(2) ? data.musics[2].actualScore : 0) % 10000 == 2021;
                bool ear1 = (data.musics.ContainsKey(0) ? data.musics[0].earnedScore : 0) % 10000 == 2021;
                bool ear2 = (data.musics.ContainsKey(1) ? data.musics[1].earnedScore : 0) % 10000 == 2021;
                bool ear3 = (data.musics.ContainsKey(2) ? data.musics[2].earnedScore : 0) % 10000 == 2021;
                if (all || act1 || act2 || act3 || ear1 || ear2 || ear3) {
                    result.Add(data.userName);
                }
            }

            EEL733Award1Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("EEL733Award1Name");
        }

        // 東方リミックス楽曲を最も多く選曲した人
        public void GetEEL733Award2() {
            HashSet<string> result = new HashSet<string>();
            int max = 1;
            foreach (PlayerData data in playerList) {
                int cnt = data.musics.Where(e => e.Value.music.touhou).Count();
                if (max < cnt) {
                    max = cnt;
                    result.Clear();
                    result.Add(data.userName);
                } else if (max == cnt) {
                    result.Add(data.userName);
                }
            }

            EEL733Award2Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("EEL733Award2Name");
            EEL733Award2Sub = result.Count > 0 ? $"選曲数:{max}" : "";
            OnPropertyChange("EEL733Award2Sub");
        }

        // ボルテIIIの譜面を最も多く選曲した人
        public void GetEEL733Award3() {
            HashSet<string> result = new HashSet<string>();
            int max = 1;
            foreach (PlayerData data in playerList) {
                int cnt = data.musics.Where(e => e.Value.music.version == 3).Count();
                if (max < cnt) {
                    max = cnt;
                    result.Clear();
                    result.Add(data.userName);
                } else if (max == cnt) {
                    result.Add(data.userName);
                }
            }

            EEL733Award3Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("EEL733Award3Name");
            EEL733Award3Sub = result.Count > 0 ? $"選曲数:{max}" : "";
            OnPropertyChange("EEL733Award3Sub");
        }

        // 最も低いスコアを宣言した人
        public void GetEEL733Award4() {
            HashSet<string> result = new HashSet<string>();
            int min = 10000001;
            foreach (PlayerData data in playerList) {
                foreach (SelectMusicData selectData in data.musics.Values) {
                    int declaredScore = selectData.declaredScore;
                    if (min > declaredScore) {
                        min = declaredScore;
                        result.Clear();
                        result.Add(data.userName);
                    } else if (min == declaredScore) {
                        result.Add(data.userName);
                    }
                }
            }

            EEL733Award4Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("EEL733Award4Name");
            EEL733Award4Sub = result.Count > 0 ? $"宣言スコア:{min}" : "";
            OnPropertyChange("EEL733Award4Sub");
        }

        // 3曲の実プレースコアについて、分散が最も小さい人
        public void GetEEL733Award5() {
            HashSet<string> result = new HashSet<string>();
            long min = 300000000000000;
            foreach (PlayerData data in playerList) {
                long tmp = data.variance140;
                if (min > tmp) {
                    min = tmp;
                    result.Clear();
                    result.Add(data.userName);
                } else if (min == tmp) {
                    result.Add(data.userName);
                }
            }

            EEL733Award5Name = result.Count > 0 ? CollectionToString(result) : "該当者なし";
            OnPropertyChange("EEL733Award5Name");
            EEL733Award5Sub = result.Count > 0 ? $"分散:{min * 2 / 9.0:F2}" : "";
            OnPropertyChange("EEL733Award5Sub");
        }

        private string CollectionToString(IEnumerable<string> values) {
            return string.Join("\n", values);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
