using System;
using Microsoft.UI.Xaml.Data;

namespace Layout_in_WinUI3.Helpers;

public class SelectedItemCountToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        // Convert the selected item count to a boolean value
        var itemCount = (int)value;
        return itemCount > 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}