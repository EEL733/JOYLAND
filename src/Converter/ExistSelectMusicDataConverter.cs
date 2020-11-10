using JOYLAND.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace JOYLAND.Converter {
    public class ExistSelectMusicDataConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            PlayerData player = value as PlayerData;
            int key = int.Parse((string)parameter);
            return player.musics.ContainsKey(key);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
