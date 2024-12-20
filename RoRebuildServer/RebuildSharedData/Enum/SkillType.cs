﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RebuildSharedData.Enum
{
    public enum SkillTarget : byte
    {
        Passive,
        Enemy,
        Ally,
        Any,
        Ground,
        Self
    }

    public enum SkillClass : byte
    {
        None,
        Physical,
        Ranged,
        Magic,
        Unique
    }

    [Flags]
    public enum AttackFlags : short
    {
        Neutral = 0,
        Physical = 1,
        Magical = 2,
        CanCrit = 4,
        GuaranteeCrit = 8,
        CanHarmAllies = 16,
        IgnoreDefense = 32,
        IgnoreEvasion = 64,
        NoDamageModifiers = 128,
        NoElement = 256
    }
}
