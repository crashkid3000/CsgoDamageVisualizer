using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.model
{
    /// <summary>
    /// Property that names a <c>CfgWeapon</c> field whose value will be copied over to a <c>Weapon</c> instance during object crteation.
    /// </summary>
    internal class WeaponPropertyMapping : Attribute
    {
        public string CfgWeaponFieldName { get; init; }

        /// <summary>
        /// Use this to specify that explicitly, no conversion from CfgWeapon to Weapon is is intended
        /// </summary>
        public static string NO_CONVERSION = "no conversion";

        public WeaponPropertyMapping(string name)
        {
            CfgWeaponFieldName = name;
        }
    }
}
