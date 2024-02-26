using SoftTradePlusAPP.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using System.Windows.Data;

namespace SoftTradePlusAPP.Converters
{
    class StatusToTextConverter : IValueConverter
    {
        private static IDictionary<ClientStatus, string> _descriptions = new Dictionary<ClientStatus, string>
        {
            { ClientStatus.KeyClient, "Key client" },
            { ClientStatus.RegularClient, "Regular client" },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ClientStatus))
                return null;
            var gender = (ClientStatus)value;
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
