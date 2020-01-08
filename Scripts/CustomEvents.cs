// =======================================================================================
// Custom Events
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using System;
using UnityEngine.Events;

namespace wovencode
{
	
	[System.Serializable]
	public class UnityEventString : UnityEvent<string> {}
	
	[System.Serializable]
	public class UnityEventLong : UnityEvent<long> {}
	
	[System.Serializable]
	public class UnityEventInt : UnityEvent<int> {}
	
	[System.Serializable]
	public class UnityEventBool : UnityEvent<bool> {}
	
}

// =======================================================================================