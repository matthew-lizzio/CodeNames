using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using static mml.CodeNames.Wpf.Model.Tiles;

namespace mml.CodeNames.Wpf.ViewModel.Converters
{
    public class TileTypeToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            switch ((TileTypes)value)
            {
                case TileTypes.Neutral:
                    return Brushes.Beige;
                case TileTypes.Red:
                    return Brushes.Red;
                case TileTypes.Blue:
                    return Brushes.Blue;
                case TileTypes.Black:
                    return Brushes.Black;
                default:
                    return Brushes.Beige;
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
