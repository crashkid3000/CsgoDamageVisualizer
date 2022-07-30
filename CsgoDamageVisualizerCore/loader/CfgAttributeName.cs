using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizer.loader
{
    internal class CfgAttributeName: Attribute
    {
        public CfgAttributeName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
