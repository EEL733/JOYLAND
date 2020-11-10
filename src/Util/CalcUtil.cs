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

        public static int CalcActualScore(int critical, int near, int error) {
            int sum = critical + near + error;
            if (sum == 0) {
                return 0;
            }

            return (int)Math.Floor(((critical * 2) + near) * 10000000.0 / (sum * 2));
        }

        public static int ClacEarnedScore(double vf, VolforceLank vfLank, int declaredScore, int actualScore) {
            if (actualScore == 0) {
                return 0;
            }

            if (actualScore >= declaredScore) {
                return declaredScore;
            }

            int diff = declaredScore - actualScore;
            int deductionScore = (int)Math.Ceiling(diff * vf / 10) + (int)vfLank;
            return declaredScore - deductionScore;
        }
    }
}
