// =======================================================================================
// ExampleTemplate
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================
#if UNITY_EDITOR

using wovencode;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace wovencode
{

	[InitializeOnLoad]
	public partial class DefinesManager
	{

		// -----------------------------------------------------------------------------------
		// DefinesManager (Constructor)
		// -----------------------------------------------------------------------------------
		static DefinesManager()
		{
			DevExtUtils.InvokeStaticDevExtMethods(typeof(DefinesManager), "Constructor");
		}
	
		// -----------------------------------------------------------------------------------
	
	}

}

#endif