using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.Data;
namespace Converters
{
    //[ValueConversion(typeof(DateTime), typeof(String))]
    public class DateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
                   return ((DateTime)value).ToString("yyyy年MM月dd日") + "收入";
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    //[ValueConversion(typeof(DateTime), typeof(String))]
    //public class DateConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return ((DateTime)value).ToString("yyyy/MM/dd") + "收入";
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return null;
    //    }
    //}

}
