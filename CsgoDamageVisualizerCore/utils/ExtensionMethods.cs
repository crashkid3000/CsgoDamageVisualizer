using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.utils
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns the number of spaces preceeding a line. Tabs and other characters not representing a normal space (e.g. no-break space U+00A0) are not counted.
        /// </summary>
        /// <param name="s">The string of which to extract the identation level from</param>
        /// <returns>The number of spaces used for identation. Always >= 0.</returns>
        public static int GetSpaceIndentationLevel(this string s)
        {
            bool firstAlphaCharSeen = false;
            return s.Count(c =>
            {
                if (Char.IsLetter(c))
                {
                    firstAlphaCharSeen = true;
                }
                return c.Equals(' ') && !firstAlphaCharSeen;
            });
        }
    }
}
