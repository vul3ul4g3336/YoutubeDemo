using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YoutubeDemo.Utility
{
    public  class Converter: IValueConverter
    {

            // 當資料從 ViewModel 傳到 畫面時 (決定按鈕要不要亮起來)
            public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null || parameter == null) return false;

                // 比較目前的 Enum 值是否等於 XAML 傳進來的參數
                return value.ToString().Equals(parameter.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }

            // 當使用者 點擊按鈕時 (把選中的值存回 ViewModel)
            public   object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null || parameter == null) return Binding.DoNothing;

                // 如果按鈕被選中了 (true)，就回傳該 Enum 值給 ViewModel
                if ((bool)value)
                {
                    return Enum.Parse(targetType, parameter.ToString());
                }

                return null;
            }
        
    }
}
