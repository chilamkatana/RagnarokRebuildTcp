﻿using System.Xml.Linq;

namespace RebuildSharedData.Enum.EntityStats;

public enum CharacterElement : byte
{
    Neutral1,
    Neutral2,
    Neutral3,
    Neutral4,
    Earth1,
    Earth2,
    Earth3,
    Earth4,
    Water1,
    Water2,
    Water3,
    Water4,
    Fire1,
    Fire2,
    Fire3,
    Fire4,
    Wind1,
    Wind2,
    Wind3,
    Wind4,
    Poison1,
    Poison2,
    Poison3,
    Poison4,
    Undead1,
    Undead2,
    Undead3,
    Undead4,
    Dark1,
    Dark2,
    Dark3,
    Dark4,
    Holy1,
    Holy2,
    Holy3,
    Holy4,
    Ghost1,
    Ghost2,
    Ghost3,
    Ghost4,
    None
}

public static class CharacterElementExtensions
{
    public static bool IsElementBaseType(this CharacterElement element, CharacterElement targetType)
    {
        return element >= targetType && element <= targetType + 3; //checks if element 1-4 is equal to targetType (assuming we pass element 1)
    }
}