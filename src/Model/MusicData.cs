namespace JOYLAND.Model {
    public class MusicData {
        public int id { get; set; }
        public string name { get; set; }
        public string difficultyType { get; set; }
        public int level { get; set; }
        public int group { get; set; }
        public bool select { get; set; }
        public bool visible { get; set; }

        public MusicData(int id, string name, string difficultyType, int level, int group, bool visible) {
            this.id = id;
            this.name = name;
            this.difficultyType = difficultyType;
            this.level = level;
            this.group = group;
            select = false;
            this.visible = visible;
        }
    }
}
