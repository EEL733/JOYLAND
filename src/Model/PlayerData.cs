using JOYLAND.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace JOYLAND.Model {
    public class PlayerData {
        public enum VolforceLank {
            UnderArgento = 0,
            Eldora12 = 10000,
            Eldora34 = 20000,
            Crimson12 = 30000,
            Crimson34 = 40000,
            Imperial1Low = 50000,
            Imperial1High = 75000
        }

        public int id { get; set; }
        public int playerNo { get; set; }
        public string userName { get; set; }
        public double vf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VolforceLank vfLank { get; set; }
        public Dictionary<int, SelectMusicData> musics { get; } = new Dictionary<int, SelectMusicData>();
        public int scoreAll { get; set; } = 0;
        public long variance140 {
            get {
                if (musics.Count != 3) {
                    return 300000000000001;
                }
                long a = musics[0].actualScore;
                long b = musics[1].actualScore;
                long c = musics[2].actualScore;
                return a * (a - b) + b * (b - c) + c * (c - a);
            }
        }

        public PlayerData(int id, string userName, double vf) {
            this.id = id;
            this.userName = userName;
            this.vf = vf;
            vfLank = CalcUtil.ToVolforceLank(vf);
        }
    }
}
