using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.loader.model
{
    /// <summary>
    /// Sets the converted type of the attribute. Default is <b>float</b>.
    /// </summary>
    internal class CfgAttributeType: Attribute
    {
        public Type type;

        public CfgAttributeType(Type type)
        {
            this.type = type;
        }
    }
}
