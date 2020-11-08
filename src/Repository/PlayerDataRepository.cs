using JOYLAND.Model;
using JOYLAND.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace JOYLAND.Repository {
    public class PlayerDataRepository {
        public static readonly PlayerDataRepository Instance = new PlayerDataRepository();

        private readonly Dictionary<int, PlayerData> store = new Dictionary<int, PlayerData>();

        private PlayerDataRepository() {
            string[] fileList = Directory.GetFileSystemEntries("./data", "player-*.json");
            foreach (string filePath in fileList) {
                PlayerData data = JsonUtil<PlayerData>.ReadJsonFile(filePath);
                store[data.id] = data;
            }
        }

        public PlayerData Get(int id) {
            return store[id];
        }

        public List<PlayerData> GetAll() {
            List<PlayerData> list = store.Values.ToList();
            list.Sort((d1, d2) => d1.vf.CompareTo(d2.vf));
            return list;
        }

        public void Save(PlayerData data) {
            store[data.id] = data;
            JsonUtil<PlayerData>.WriteJsonFile("./data/player-" + data.id + ".json", data);
        }

        public int GetRequiredTrackCount() {
            return (store.Count * 3) - store.Sum(data => data.Value.musics.Count);
        }
    }
}
