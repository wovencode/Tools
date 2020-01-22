// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Debugging;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wovencode.Debugging
{
	
	// ===================================================================================
	// Debug
	// ===================================================================================
	public partial class debug
	{
		
		protected const bool debugMode = true;
		
		// ======================= PUBLIC METHODS - DEBUG ================================
		
		// -------------------------------------------------------------------------------
		// Log
		// @debugMode
		// -------------------------------------------------------------------------------
		public static void Log(string message)
		{
			if (debugMode)
				UnityEngine.Debug.Log(message);
		}
		
		// -------------------------------------------------------------------------------
		// LogWarning
		// @debugMode
		// -------------------------------------------------------------------------------
		public static void LogWarning(string message)
		{
			if (debugMode)
				UnityEngine.Debug.LogWarning(message);
		}
		
		// -------------------------------------------------------------------------------
		// LogError
		// @debugMode
		// -------------------------------------------------------------------------------
		public static void LogError(string message)
		{
			if (debugMode)
				UnityEngine.Debug.LogError(message);
		}
		
		// -------------------------------------------------------------------------------
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================