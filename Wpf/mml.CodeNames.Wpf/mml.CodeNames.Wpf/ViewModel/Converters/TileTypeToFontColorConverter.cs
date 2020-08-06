using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using static mml.CodeNames.Wpf.Model.Tiles;

namespace mml.CodeNames.Wpf.ViewModel.Converters
{
    public class TileTypeToFontColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TileTypes)value)
            {               
                case TileTypes.Red:
                case TileTypes.Blue:
                case TileTypes.Black:
                    return Brushes.White;             
                default:
                    return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //switch ((SolidColorBrush)value)
            //{
            //    case Brushes.Red:
            //        return TileTypes.Red;
            //    case Brushes.Blue:
            //        return TileTypes.Blue;
            //    case Brushes.Black:
            //        return TileTypes.Black;
            //    default:
            //        return TileTypes.Neutral;
            //}
            throw new NotSupportedException();
        }
    }
}
