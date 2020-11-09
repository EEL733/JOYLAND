namespace JOYLAND.Model {
    public class SelectMusicData {
        public MusicData music { get; set; }
        public int declaredScore { get; set; } = 0;
        public int actualScore { get; set; } = 0;
        public int earnedScore { get; set; } = 0;
        public int critical { get; set; } = 0;
        public int near { get; set; } = 0;
        public int error { get; set; } = 0;

        public SelectMusicData(MusicData music) {
            this.music = music;
        }
    }
}
