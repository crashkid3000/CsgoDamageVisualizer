using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.calc
{
    public class MiscCalculations
    {

        Weapon weapon;

        public MiscCalculations(Weapon weapon)
        {
            this.weapon = weapon;
        }

        /// <summary>
        /// The maximum player speed in <i>primary</i> fire mode, relative to the speed with a knife out.
        /// </summary>
        public float MaxPlayerSpeedRelative { get { return weapon.MaxPlayerSpeed / 250.0f; } }

        /// <summary>
        /// The maximum player speed in <i>secondary</i> fire mode, relative to the speed with a knife out.
        /// </summary>
        public float MaxPlayerSpeedAltRelative { get { return weapon.MaxPlayerSpeedAlt / 250.0f; } }
    }
}
