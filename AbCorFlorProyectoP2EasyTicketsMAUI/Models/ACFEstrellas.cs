using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbCorFlorProyectoP2EasyTicketsMAUI.Models
{
    public class ACFEstrellas : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int calificacion && parameter is string starLevelString && int.TryParse(starLevelString, out int starLevel))
            {
                return calificacion >= starLevel;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
