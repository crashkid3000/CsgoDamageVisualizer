using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.model;

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

#pragma warning disable IDE0060
// While no instance of Weapon is needed for any method, I'd still like to keep them this closely related ebcause we access a field directly from Weapon
        public static float ValueOrBackupValue(this Weapon w, float primaryValue, float backupValue)
        {
            return primaryValue.Equals(Weapon.NOT_FILLED_FLOAT) ? backupValue : primaryValue;
        }

        public static int ValueOrBackupValue(this Weapon w, int primaryValue, int backupValue)
        {
            return primaryValue.Equals(Weapon.NOT_FILLED_INT) ? backupValue : primaryValue;
        }

        public static string ValueOrBackupValue(this Weapon w, string primaryValue, string backupValue)
        {
            return primaryValue.Equals("") ? backupValue : primaryValue;
        }
#pragma warning restore
    }
}
