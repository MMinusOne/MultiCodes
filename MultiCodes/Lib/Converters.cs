using MultiCodes.Lib.Models;
using MultiCodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MultiCodes.Lib.Converters
{
    public class CommandToReadonlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var codeBlock = (CLIBlock)value;
            return !(codeBlock.IsUserCommand && !codeBlock.Executed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedItemNodeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
