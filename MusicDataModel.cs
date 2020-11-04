using System.Collections.Generic;

namespace JOYLAND {
    public class MusicDataModel {
        private static MusicDataModel instance;
        public List<MusicData> musicDatas { get; set; }
        public List<string> headers { get; set; }
        public int currentGroup { get; set; }

        public static MusicDataModel Instance {
            get {
                if (instance == null) {
                    instance = JsonUtil<MusicDataModel>.ReadJsonFileAsync("./output/music-data.json");
                }
                return instance;
            }
        }

        public string getCurrentGroupName() {
            return headers[currentGroup];
        }

        public string getNextGroupName() {
            return headers[currentGroup + 1];
        }

        public List<MusicData> generateCurrentGroupList() {
            return musicDatas.FindAll(data => data.group == currentGroup);
        }

        public List<MusicData> generateNextGroupList() {
            return musicDatas.FindAll(data => data.group == (currentGroup + 1));
        }

        public void AllVisible() {
            musicDatas.FindAll(data => data.group == currentGroup).ForEach(data => data.Visible = true);
        }

        public void UnSelect(MusicData data) {
            data.Select = false;
        }

        public bool CanSelect(int playerIndex, int trackIndex) {
            int requiredTrackCount = ((PlayerDataListModel.Instance.Players.Count - playerIndex - 1) * 3) + (3 - trackIndex);
            int remainingCount = musicDatas.FindAll(data => data.group > currentGroup).Count;
            return remainingCount >= requiredTrackCount;
        }
    }
}
