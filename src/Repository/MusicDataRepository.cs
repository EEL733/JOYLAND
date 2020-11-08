using JOYLAND.Model;
using JOYLAND.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JOYLAND.Repository {
    public class MusicDataRepository {
        public static readonly MusicDataRepository Instance = new MusicDataRepository();

        private readonly Dictionary<int, MusicData> store = new Dictionary<int, MusicData>();

        private MusicDataRepository() {
            string[] fileList = Directory.GetFileSystemEntries("./data", "music-data-*.json");
            foreach (string filePath in fileList) {
                MusicData data = JsonUtil<MusicData>.ReadJsonFile(filePath);
                store[data.id] = data;
            }
        }

        public List<MusicData> GetAll() {
            return store.Values.ToList();
        }

        public void Save(MusicData data) {
            store[data.id] = data;
            JsonUtil<MusicData>.WriteJsonFile("./data/music-data-" + data.id + ".json", data);
        }

        public MusicData Get(int id) {
            return store[id];
        }

        public List<MusicData> GetByGroup(int group, bool isAllVisible) {
            List<MusicData> list = store.Values.Where(data => data.group == group).ToList();
            if (isAllVisible) {
                list.FindAll(data => !data.visible).ForEach(data => {
                    data.visible = true;
                    Save(data);
                });
            }
            list.Sort((d1, d2) => d1.id - d2.id);
            return list;
        }

        public bool CanSelect(int requiredTrackCount, int group) {
            long remainingCount = store.Values.Where(data => data.group > group).LongCount();
            return remainingCount >= requiredTrackCount;
        }
    }
}
