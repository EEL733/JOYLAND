using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace JOYLAND {
    class PlayerDataListModel {
        private static PlayerDataListModel instance;
        public static PlayerDataListModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerDataListModel();
                }
                return instance;
            }
        }

        private List<PlayerData> players;
        public ReadOnlyCollection<PlayerData> Players {
            get {
                return players.AsReadOnly();
            }
        }

        public PlayerDataListModel() {
            players = new List<PlayerData>();

            string dirPath = Path.GetFullPath("./output");
            string[] fileList = Directory.GetFileSystemEntries(dirPath, "player-*.json");
            foreach (string filePath in fileList) {
                players.Add(JsonUtil<PlayerData>.ReadJsonFileAsync(filePath));
            }

            /**
            players.Add(new PlayerData(("本田　圭佑"), 0, 19.01));
            players.Add(new PlayerData(("健康☆朝マサラ"), 1, 18.81));
            players.Add(new PlayerData(("非正規　遊太"), 2, 18.77));
            players.Add(new PlayerData(("マザヨイノタバイタバイ!?"), 3, 20.04));
            players.Add(new PlayerData(("ふわりねあすも"), 4, 21.27));
            **/

            players.Sort((a, b) => a.Vf.CompareTo(b.Vf));
            for (int i = 0; i < players.Count; i++) {
                players[i].playerIndex = i;
            }
        }
    }
}
