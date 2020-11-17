using JOYLAND.Model;
using JOYLAND.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            Sort();
        }

        public int GenerateID() {
            return store.Keys.Count();
        }

        public PlayerData Get(int id) {
            return store[id];
        }

        public List<PlayerData> GetAll() {
            return store.Values.OrderBy(data => data.playerNo).ToList();
        }

        public void Save(PlayerData data) {
            bool isAdd = !store.ContainsKey(data.id);
            store[data.id] = data;

            if (isAdd) {
                Sort();
            }
        }

        public int GetRequiredTrackCount() {
            return (store.Count * 3) - store.Sum(data => data.Value.musics.Count);
        }

        private void Sort() {
            int playerNo = 1;
            foreach (PlayerData d in store.Values.OrderBy(v => v.vf)) {
                d.playerNo = playerNo++;
                JsonUtil<PlayerData>.WriteJsonFile("./data/player-" + d.id + ".json", d);
            }
        }
    }
}
