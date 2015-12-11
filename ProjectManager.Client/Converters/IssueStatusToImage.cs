using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManager.Client.Converters
{
    public class IssueStatusToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Open":
                    return @"\Resources\Images\IssueStatuses\open.png";
                case "InProgress":
                    return @"\Resources\Images\IssueStatuses\inprogress.png";
                case "Resolved":
                    return @"\Resources\Images\IssueStatuses\resolved.png";
                case "Closed":
                    return @"\Resources\Images\IssueStatuses\closed.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
