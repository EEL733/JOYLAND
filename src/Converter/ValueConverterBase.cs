using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace JOYLAND.Converter {
    public abstract class ValueConverterBase<T, U> : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (value) {
                case T t_val:
                    return Convert(t_val, parameter);
                case IEnumerable<T> t_arr:
                    return t_arr.Select(t => Convert(t, parameter));
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (value) {
                case U u_val:
                    return ConvertBack(u_val, parameter);
                case IEnumerable<U> u_arr:
                    return u_arr.Select(u => ConvertBack(u, parameter));
                default:
                    return null;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }

        public abstract U Convert(T value, object parameter);
        public abstract T ConvertBack(U value, object parameter);
    }
}
