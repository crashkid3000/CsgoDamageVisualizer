using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// Class that deals with analyzing a weapon, with no clear topic in mind. In other words, this class holds the calculations that don't fit anywhere else.
    /// </summary>
    public class MiscAnalysis
    {

        Weapon weapon;

        public MiscAnalysis(Weapon weapon)
        {
            this.weapon = weapon;
        }

        #region constants

        /// <summary>
        /// The speed of the player in units per second with a knife equipped.
        /// </summary>
        public static float KnifeSpeed { get { return 250.0f; } } //units per second

        #endregion

        #region analysis

        /// <summary>
        /// The maximum player speed in <i>primary</i> fire mode, relative to the speed with a knife out.
        /// </summary>
        public float MaxPlayerSpeedRelative { get { return weapon.MaxPlayerSpeed / KnifeSpeed; } }

        /// <summary>
        /// The maximum player speed in <i>secondary</i> fire mode, relative to the speed with a knife out.
        /// </summary>
        public float MaxPlayerSpeedAltRelative { get { return weapon.MaxPlayerSpeedAlt / KnifeSpeed; } }

        #endregion
    }
}
