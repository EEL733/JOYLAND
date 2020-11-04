namespace JOYLAND {
    public class VolforceLank {
        public static readonly VolforceLank UnderArgento = new VolforceLank(0);
        public static readonly VolforceLank Eldora12 = new VolforceLank(10000);
        public static readonly VolforceLank Eldora34 = new VolforceLank(20000);
        public static readonly VolforceLank Crimson12 = new VolforceLank(30000);
        public static readonly VolforceLank Crimson34 = new VolforceLank(40000);
        public static readonly VolforceLank Imperial1Low = new VolforceLank(50000);
        public static readonly VolforceLank Imperial1High = new VolforceLank(75000);
        public int conceded { get; set; }

        public VolforceLank(int conceded) {
            this.conceded = conceded;
        }

        public static VolforceLank convert(double vf) {
            if (vf < 18.0) {
                return VolforceLank.UnderArgento;
            } else if (vf < 18.5) {
                return VolforceLank.Eldora12;
            } else if (vf < 19.0) {
                return VolforceLank.Eldora34;
            } else if (vf < 19.5) {
                return VolforceLank.Crimson12;
            } else if (vf < 20.0) {
                return VolforceLank.Crimson34;
            } else if (vf < 20.5) {
                return VolforceLank.Imperial1Low;
            } else {
                return VolforceLank.Imperial1High;
            }
        }
    }
}
