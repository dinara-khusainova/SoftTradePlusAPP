using SoftTradePlusAPP.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using System.Windows.Data;

namespace SoftTradePlusAPP.Converters
{
    class SubscriptionPeriodToTextConverter : IValueConverter
    {
        private static IDictionary<SubscriptionPeriod, string> _descriptions = new Dictionary<SubscriptionPeriod, string>
        {
            { SubscriptionPeriod.Month, "Month" },
            { SubscriptionPeriod.Quarter, "Quarter" },
            { SubscriptionPeriod.Year, "Year" },
            
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SubscriptionPeriod))
                return null;
            var gender = (SubscriptionPeriod)value;
            if (!_descriptions.ContainsKey(gender))
                return null;
            return _descriptions[gender];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
