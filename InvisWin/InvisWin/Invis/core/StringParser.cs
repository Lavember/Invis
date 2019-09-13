using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InvisWin.Invis.core
{
    /// <summary>
    /// This class parses and "cleans out" most of the string codes such as variables (#date) or line skips (\n)
    /// </summary>
    public static class StringParser
    {
        /// <summary>
        /// Filter/parse a string to make variables pop out and break lines
        /// </summary>
        /// <param name="toParse">String destined to be parsed</param>
        /// <param name="environment">Parent environment</param>
        /// <returns></returns>
        public static string ParseString(string toParse, Environment environment)
        {
            // Working result of the string. It'll go through different sorts of filters.
            string result = toParse;

            // Replace all \n with real line skip except there is \\n
            result = result.Replace("\\\\n", "\u0171");
            result = result.Replace("\\n", "\u0172");
            result = result.Replace("\u0171", "\\n");
            result = result.Replace("\u0172", "\n");

            // Replace all #date with the date unless \#date
            result = result.Replace("\\#date", "\u0171");
            result = result.Replace("#date", "\u0172");
            result = result.Replace("\u0171", "#date");
            result = result.Replace("\u0172", new variables.VDate(environment).value.ToString());

            return result;
        }



    }
}
