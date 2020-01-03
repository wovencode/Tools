// =======================================================================================
// EditorTools
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

#if UNITY_EDITOR

using wovencode;
using System;
using UnityEditor;
using UnityEngine;

namespace wovencode
{

	[InitializeOnLoad]
	public static partial class EditorTools
	{
	
		// -------------------------------------------------------------------------------
		// Removes the passed define (string) from scripting defines of the current target
		// platform, without touching other defines.
		// -------------------------------------------------------------------------------
		public static void AddScriptingDefine(string define)
		{
			BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
			string definestring = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
			string[] defines = definestring.Split(';');

			if (Tools.ArrayContains(defines, define))
				return;

			PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, (definestring + ";" + define));
		}

		// -------------------------------------------------------------------------------
		// Adds the passed define (string) to scripting defines of the current target 
		// platform, without adding duplicates.
		// -------------------------------------------------------------------------------
		public static void RemoveScriptingDefine(string define)
		{
			BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
			string definestring = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
			string[] defines = definestring.Split(';');

			defines = Tools.RemoveFromArray(defines, define);

			definestring = string.Join(";", defines);

			PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, (definestring));
		}
	
		// -------------------------------------------------------------------------------
	
	}

}

#endif

// =======================================================================================