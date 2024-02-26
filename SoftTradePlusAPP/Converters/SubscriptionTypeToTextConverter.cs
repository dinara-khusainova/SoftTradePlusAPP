using SoftTradePlusAPP.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using System.Windows.Data;

namespace SoftTradePlusAPP.Converters
{
   class SubscriptionTypeToTextConverter : IValueConverter
    {
        private static IDictionary<SubscriptionType, string> _descriptions = new Dictionary<SubscriptionType, string>
        {
            { SubscriptionType.Subscription, "Subscription" },
            { SubscriptionType.PermanentLicense, "Permanent license" },
            

        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SubscriptionType))
                return null;
            var gender = (SubscriptionType)value;
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
