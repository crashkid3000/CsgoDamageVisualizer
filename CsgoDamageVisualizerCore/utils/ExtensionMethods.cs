using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.utils
{
    public static class ExtensionMethods
    {
        public static int GetIndentaionLevel(this string s)
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
