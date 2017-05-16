using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Util
{
    public class CommonUtil
    {
        public static string NumberToWeekDay(int day)
        {
            switch(day)
            {
                case 0: return "Lunes";
                case 1: return "Martes";
                case 2: return "Miércoles";
                case 3: return "Jueves";
                case 4: return "Viernes";
                case 5: return "Sábado";
                case 6: return "Domingo";
                default: return "X";
            }
        }
    }
}
