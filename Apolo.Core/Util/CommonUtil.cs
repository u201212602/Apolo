using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Util
{
    public static class CommonUtil
    {
        public static string NumberToWeekDay(int day)
        {
            switch(day)
            {
                case 0: return "Lunes";
                case 1: return "Martes";
                case 2: return "Miercoles";
                case 3: return "Jueves";
                case 4: return "Viernes";
                case 5: return "Sabado";
                case 6: return "Domingo";
                default: return "X";
            }
        }

        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }

            }

        }
    }
}
