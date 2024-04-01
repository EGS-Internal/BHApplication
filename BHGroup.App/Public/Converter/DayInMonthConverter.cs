using System.Globalization;
using System.Windows.Data;

namespace BHGroup.App.Public.Converter
{
    public class DayInMonthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is int && values[1] is int)
            {
                int year = (int)values[0];
                int month = (int)values[1];

                // Lấy số ngày của tháng từ giá trị của ComboBox tháng và năm
                int daysInMonth = DateTime.DaysInMonth(year, month);
                List<int> days = new List<int>();
                for (int i = 1; i <= daysInMonth; i++)
                {
                    days.Add(i);
                }

                return days;
            }

            // Trả về null nếu giá trị đầu vào không hợp lệ
            return null;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
