using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using IndustrialMonitor.Core.Models;

namespace IndustrialMonitor.App.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is EquipmentStatus status)
        {
            return status switch
            {
                EquipmentStatus.Running => Brushes.Green,
                EquipmentStatus.Warning => Brushes.Orange,
                EquipmentStatus.Error => Brushes.Red,
                EquipmentStatus.Stopped => Brushes.Gray,
                _ => Brushes.Transparent
            };
        }
        return Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
