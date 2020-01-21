// =======================================================================================
// GrowthBasedValues
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using System;
using UnityEngine;

namespace Wovencode
{

	[Serializable]
	public partial struct LinearGrowthInt
	{
		public int baseValue;
		public int bonusPerLevel;
		public int Get(int level) => Math.Max(0, bonusPerLevel * (level - 1)) + baseValue;
	}

	[Serializable]
	public partial struct LinearGrowthLong
	{
		public long baseValue;
		public long bonusPerLevel;
		public long Get(int level) => Math.Max(0, bonusPerLevel * (level - 1)) + baseValue;
	}

	[Serializable]
	public partial struct LinearGrowthFloat
	{
		public float baseValue;
		public float bonusPerLevel;
		public float Get(int level) => Mathf.Max(0, bonusPerLevel * (level - 1)) + baseValue;
	}

	[Serializable]
	public partial struct ExponentialGrowthInt
	{
		public int multiplier;
		public float baseValue;
		public int Get(int level) => Convert.ToInt32(multiplier * Mathf.Pow(baseValue, (level - 1)));
	}

	[Serializable]
	public partial struct ExponentialGrowthLong
	{
		public long multiplier;
		public float baseValue;
		public long Get(int level) => Convert.ToInt64(multiplier * Mathf.Pow(baseValue, (level - 1)));
	}

	[Serializable]
	public partial struct ExponentialGrowthFloat
	{
		public float multiplier;
		public float baseValue;
		public float Get(int level) => multiplier * Mathf.Pow(baseValue, (level - 1));
	}

}

// =======================================================================================