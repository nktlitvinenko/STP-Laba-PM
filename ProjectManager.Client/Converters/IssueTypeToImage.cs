using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManager.Client.Converters
{
    public class IssueTypeToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Bug":
                    return @"\Resources\Images\IssueTypes\bug.png";
                case "Improvement":
                    return @"\Resources\Images\IssueTypes\improvement.png";
                case "NewFeature":
                    return @"\Resources\Images\IssueTypes\new.png";
                case "Task":
                    return @"\Resources\Images\IssueTypes\task.png";
                case "Test":
                    return @"\Resources\Images\IssueTypes\test.png";
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
