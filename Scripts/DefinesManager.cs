// =======================================================================================
// ExampleTemplate
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================
#if UNITY_EDITOR

using Wovencode;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Wovencode
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