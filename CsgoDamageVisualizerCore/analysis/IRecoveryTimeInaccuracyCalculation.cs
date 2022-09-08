using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    public interface IRecoveryTimeInaccuracyCalculation
    {
        /// <summary>
        /// Calculates the inaccuracy just before taking the <c>shotToBeFired</c>-th shot. Implementations of this class will handle everything related to standing/crouching and primary/Secondary fire mode.
        /// </summary>
        /// <param name="userCycleTime"><para>The time between each shot by the user of the gun. Should not be lower than the weapon's cycletime.</para><para><u>Unit:</u> 1 s</para></param>
        /// <param name="shotToBeFired"><para>The number of the bullet that is just about to be fired, whose inaccuracy we are trying to figure out.</para><para><u>Unit:</u> 1 (bullet)</para></param>
        /// <returns><para>The inaccuracy of the weapon just before firing the <c>shotToBeFired</c>-th shot.</para><u>Unit:</u> 1 ia</returns>
        public float Calculate(float userCycleTime, int shotToBeFired);
    }
}
