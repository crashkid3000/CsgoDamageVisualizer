﻿using CsgoDamageVisualizerCore.model;
using CsgoDamageVisualizerCore.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// Class that deals with analyzing the inaccuracy of a gun.
    /// </summary>
    public class InaccuracyAnalysis
    {
        private Weapon weapon;

        public InaccuracyAnalysis(Weapon weapon)
        {
            this.weapon = weapon;
        }   

        public float StandingInaccuracy { get { return weapon.Spread + weapon.InaccuracyStand; } }
        public float StandingInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + weapon.ValueOrBackupValue(weapon.InaccuracyStandAlt, weapon.InaccuracyStand); } }

        public float CrouchingInaccuracy { get { return weapon.Spread + weapon.InaccuracyCrouch; } }
        public float CrouchingInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + weapon.ValueOrBackupValue(weapon.InaccuracyCrouchAlt, weapon.InaccuracyCrouch); } }

        public float RunningInaccuracy { get { return this.StandingInaccuracy + weapon.InaccuracyMove; } }
        public float RunningInaccuracyAlt { get { return this.StandingInaccuracyAlt + weapon.ValueOrBackupValue(weapon.InaccuracyMoveAlt, weapon.InaccuracyMove); } }

        public float LadderInaccuracy { get { return weapon.Spread + weapon.InaccuracyLadder; } }
        public float LadderInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + weapon.ValueOrBackupValue(weapon.InaccuracyLadderAlt, weapon.InaccuracyLadder); } }


    }
}