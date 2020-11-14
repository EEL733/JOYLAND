using JOYLAND.Model;
using System;

namespace JOYLAND.Converter {
    public class ExistSelectMusicDataConverter : ValueConverterBase<PlayerData, bool> {
        public override bool Convert(PlayerData player, object parameter) {
            int key = int.Parse((string)parameter);
            return player.musics.ContainsKey(key);
        }

        public override PlayerData ConvertBack(bool value, object parameter) {
            throw new NotImplementedException();
        }
    }
}
