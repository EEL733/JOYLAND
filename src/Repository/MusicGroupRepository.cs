using JOYLAND.Model;
using JOYLAND.Util;

namespace JOYLAND.Repository {
    public class MusicGroupRepository {
        public static readonly MusicGroupRepository Instance = new MusicGroupRepository();

        private readonly MusicGroupData data;

        private MusicGroupRepository() {
            data = JsonUtil<MusicGroupData>.ReadJsonFile("./data/music-group.json");
        }

        public int GetCurrentGroup() {
            return data.currentGroup;
        }

        public string GetCurrentGroupHeader() {
            return data.headers[data.currentGroup];
        }

        public string GetNextGroupHeader() {
            return data.headers[data.currentGroup + 1];
        }

        public void SelectNextGroup() {
            data.currentGroup++;
            Save();
        }

        private void Save() {
            JsonUtil<MusicGroupData>.WriteJsonFile("./data/music-group.json", data);
        }
    }
}
