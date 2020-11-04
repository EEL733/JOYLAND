namespace JOYLAND {
    public class MusicData {
        public string name { get; set; }
        public string difficultyType { get; set; }
        public int level { get; set; }
        public int group { get; set; }
        public bool Select { get; set; }
        public bool Visible { get; set; }

        public MusicData() {
        }

        public MusicData(string name, string difficultyType, int level, int group, bool visible) {
            this.name = name;
            this.difficultyType = difficultyType;
            this.level = level;
            this.group = group;
            this.Select = false;
            this.Visible = visible;
        }
    }
}
