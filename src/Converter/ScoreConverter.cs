using JOYLAND.Model;
using System;

namespace JOYLAND.Converter {
    public class EarnedScoreConverter : ValueConverterBase<PlayerData, string> {
        public override string Convert(PlayerData player, object parameter) {
            int key = int.Parse((string)parameter);
            int earnedScore = 0;
            if (player.musics.ContainsKey(key)) {
                earnedScore = player.musics[key].earnedScore;
            }

            return $"{earnedScore:#,0}";
        }

        public override PlayerData ConvertBack(string value, object parameter) {
            throw new NotImplementedException();
        }
    }
}
