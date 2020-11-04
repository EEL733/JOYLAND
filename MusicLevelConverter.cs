using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace JOYLAND {
    class MusicLevelConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            MusicData data = value as MusicData;
            return data.Visible ? data.level.ToString() : "??";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
