﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BHGroup.App.Public.Converter
{
    class AddVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && targetType == typeof(Visibility))
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && targetType == typeof(bool))
            {
                return visibility == Visibility.Visible;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
