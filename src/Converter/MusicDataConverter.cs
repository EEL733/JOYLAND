using JOYLAND.Model;
using System;

namespace JOYLAND.Converter {
    public class SelectMusicNameConverter : ValueConverterBase<PlayerData, string> {
        public override string Convert(PlayerData data, object parameter) {
            int key = int.Parse((string)parameter);
            return data.musics.ContainsKey(key) ? data.musics[key].music.name : "";
        }

        public override PlayerData ConvertBack(string value, object parameter) {
            throw new NotImplementedException();
        }
    }

    public class MusicNameConverter : ValueConverterBase<MusicData, string> {
        public override string Convert(MusicData data, object parameter) {
            return data.visible ? data.name : "？？？？？";
        }

        public override MusicData ConvertBack(string value, object parameter) {
            throw new NotImplementedException();
        }
    }

    public class MusicLevelConverter : ValueConverterBase<MusicData, string> {
        public override string Convert(MusicData data, object parameter) {
            return data.visible ? data.level.ToString() : "??";
        }

        public override MusicData ConvertBack(string value, object parameter) {
            throw new NotImplementedException();
        }
    }

    public class MusicDifficultyTypeConverter : ValueConverterBase<MusicData, string> {
        public override string Convert(MusicData data, object parameter) {
            return data.visible ? data.difficultyType : "???";
        }

        public override MusicData ConvertBack(string value, object parameter) {
            throw new NotImplementedException();
        }
    }
}
