// =======================================================================================
// EditorTools
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

#if UNITY_EDITOR

using Wovencode;
using System;
using UnityEditor;
using UnityEngine;

namespace Wovencode
{
	
	// ===================================================================================
	// EditorTools
	// ===================================================================================
	[InitializeOnLoad]
	public static partial class EditorTools
	{
		
		public static string[] definesArray;
		public static string definesString;
		public static BuildTargetGroup buildTargetGroup;
		
		// -------------------------------------------------------------------------------
		// AddScriptingDefine
		// Removes the passed define (string) from scripting defines of the current target
		// platform, without touching other defines.
		// -------------------------------------------------------------------------------
		public static void AddScriptingDefine(string define)
		{
			if (HasScriptingDefine(define))
				return;
				
			PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, (definesString + ";" + define));
		}

		// -------------------------------------------------------------------------------
		// RemoveScriptingDefine
		// Adds the passed define (string) to scripting defines of the current target 
		// platform, without adding duplicates.
		// -------------------------------------------------------------------------------
		public static void RemoveScriptingDefine(string define)
		{
			if (!HasScriptingDefine(define))
				return;

			definesArray = Tools.RemoveFromArray(definesArray, define);

			definesString = string.Join(";", definesArray);

			PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, (definesString));
		}
		
		// -------------------------------------------------------------------------------
		// HasScriptingDefine
		// Checks if the provided string is present in scripting defines
		// -------------------------------------------------------------------------------
		public static bool HasScriptingDefine(string define)
		{
			buildTargetGroup 	= EditorUserBuildSettings.selectedBuildTargetGroup;
			definesString 		= PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
			definesArray 		= definesString.Split(';');

			if (Tools.ArrayContains(definesArray, define))
				return true;
			
			return false;
		}
	
		// -------------------------------------------------------------------------------
	
	}

}

#endif

// =======================================================================================