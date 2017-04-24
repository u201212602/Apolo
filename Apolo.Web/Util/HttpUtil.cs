using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Apolo.Web.Util
{
    public static class HttpUtil
    {
        public static string OutputStringIfUrlMatches(HttpContext context, string pattern, string output)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(context.Request.Path) ? output : null;
        }
    }
}