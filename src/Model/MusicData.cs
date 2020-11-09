namespace JOYLAND.Model {
    public class MusicData {
        public int id { get; set; }
        public string name { get; set; }
        public string difficultyType { get; set; }
        public int level { get; set; }
        public int group { get; set; }
        public bool select { get; set; }
        public bool visible { get; set; }
        public int bpm { get; set; }
        public int fx { get; set; }
        public int version { get; set; }
        public bool touhou { get; set; }

        public MusicData(int id, string name, string difficultyType, int level, int group, bool visible, int bpm, int fx, int version, bool touhou) {
            this.id = id;
            this.name = name;
            this.difficultyType = difficultyType;
            this.level = level;
            this.group = group;
            select = false;
            this.visible = visible;
            this.bpm = bpm;
            this.fx = fx;
            this.version = version;
            this.touhou = touhou;
        }
    }
}
