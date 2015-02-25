using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.Data;
using App1.Common.Model;
namespace Converters
{
    //[ValueConversion(typeof(DateTime), typeof(String))]
    public class DateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("yyyy年MM月dd日");
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    public class IncomeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = (RecorderItem)value;
            var result = string.Format("卖出每斤单价：{0}元,重量：{1}斤,总收入：{2}元。",item.SellUnitPrice,item.SellWeight,item.SellTotalPrice);
            return result;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class PurchaseConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = (RecorderItem)value;
            var result = string.Format("收的每斤单价：{0}元,重量：{1}斤,总花费：{2}元。",item.PurchaseUnitPrice,item.PurchaseWeight,item.PurchaseTotalPrice);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ProfitConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = (decimal)value;
            var result = string.Format("净收入：{0}元", item);
            return result;
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
