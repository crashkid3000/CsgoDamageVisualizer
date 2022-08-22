using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.model
{
    internal class WeaponPropertyMapping : Attribute
    {
        public string CfgWeaponFieldName { get; init; }

        public WeaponPropertyMapping(string name)
        {
            CfgWeaponFieldName = name;
        }
    }
}
