using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// This class is about analyzing the economical impact of the weapon
    /// </summary>
    public class EconomyAnalysis
    {
        private Weapon weapon { get; set; }

        public EconomyAnalysis(Weapon weapon)
        {
            this.weapon = weapon;
        }

        #region constants

        /// <summary>
        /// The default kill award that is earned upon killing an enemy when no other number is specified.
        /// </summary>
        public static int DefaultKillAward { get { return 300; } }

        #endregion

        #region analysis

        /// <summary>
        /// <para>A multiplier, telling how much more (or less) the weapon earns per kill</para><para><u>Unit:</u> 1 </para>
        /// </summary>
        public float KillAwardRelative { get { return weapon.KillAward / (float)DefaultKillAward; } }

        /// <summary>
        /// <para>How many kills one has to achieve until the gun has paid for itself in kill reward money</para><para><u>Unit:</u> 1 (kills)</para>
        /// </summary>
        public int KillsUntilAmortized { get { return (int)Math.Ceiling((double)weapon.InGamePrice / weapon.KillAward); } }

        #endregion
    }
}
