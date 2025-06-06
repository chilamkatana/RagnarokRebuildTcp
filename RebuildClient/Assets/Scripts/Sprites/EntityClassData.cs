﻿using System;
using System.Collections.Generic;
using RebuildSharedData.ClientTypes;

namespace Assets.Scripts.Sprites
{
    [Serializable]
	public class PlayerHeadData
	{
		public int Id;
		public string Name;
		public string SpriteMale;
		public string SpriteFemale;
		public string[] FemaleIds;
		public string[] MaleIds;
	}


	[Serializable]
	public class ClassWeaponData
	{
		public int Id;
		public int ClassId;
		public string Name;
		public string SpriteMale;
		public string SpriteFemale;
	}
	
	[Serializable]
	public class WeaponClassData
	{
		public int Id;
		public string Name;
		public string WeaponClass;
		public List<string> HitSounds;
	}


	[Serializable]
	public class HeadgearSpriteData
	{
		public int Id;
		public string SpriteName;
	}

    [Serializable]
    public class AdminWarpList
    {
        public string Map;
        public string Title;
        public int X;
        public int Y;
    }
    
    [Serializable]
    public class AdminWarpSectionList
    {
        public string Title;
        public List<AdminWarpList> WarpList;
    }
    
    [Serializable]
    public class UniqueAttackAction
    {
	    public string Sprite;
	    public string Action;
	    public int Animation;
	    public bool HoldLastFrame;
	    public int StartAt;
    }
    
    [Serializable]
    public class MetamorphTransitionResult
    {
	    public string Sprite;
	    public string RemoveType;
	    public int Action;
    }

	class DatabasePlayerHeadData
	{
		public List<PlayerHeadData> PlayerHeadData;
	}

	class DatabasePlayerClassData
	{
		public List<PlayerClassData> PlayerClassData;
	}
	class AdminWarpListData
	{
		public List<AdminWarpList> WarpSections;
	}
	
	[Serializable]
	public class FogInfo
	{
		public float NearPlane;
		public float FarPlane;
		public float Density;
		public string Map;
		public string Color;
	}

    [Serializable]
    public class Wrapper<T>
    {
        public T[] Items;
    }
    
    
    [Serializable]
    public class ListWrapper<T>
    {
	    public List<T> Items;
    }


    //[Serializable]
    //class DatabaseMonsterClassData
    //{
    //	public List<MonsterClassData> MonsterClassData;
    //}
}
