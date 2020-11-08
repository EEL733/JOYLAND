using System;
using static JOYLAND.Model.PlayerData;

namespace JOYLAND.Util {
    public class CalcUtil {
        public static VolforceLank ToVolforceLank(double vf) {
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

        public static int ClacEarnedScore(double vf, VolforceLank vfLank, int _declaredScore, int actualScore) {
            int declaredScore = _declaredScore * 10000;
            if (actualScore >= declaredScore) {
                return declaredScore;
            }

            int diff = declaredScore - actualScore;
            int deductionScore = (int)Math.Ceiling(diff * vf / 10) + (int)vfLank;
            return declaredScore - deductionScore;
        }
    }
}
