// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using UnityEngine;
using System.Linq;
using Wovencode;
using Wovencode.Network;
using Wovencode.DebugManager;

namespace Wovencode
{
	
	// ===================================================================================
	// ProjectConfigTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New Project Configuration", menuName = "Configuration/New Project Configuration", order = 999)]
	public partial class ProjectConfigTemplate : ScriptableObject
	{

		[Header("Project Configuration")]
		[SerializeField]protected NetworkType networkType;
		public bool globalDebugMode;
		
		static ProjectConfigTemplate _instance;
		
		protected const string isServer = "_SERVER";
    	protected const string isClient = "_CLIENT";
		
		// -------------------------------------------------------------------------------
		// singleton
		// -------------------------------------------------------------------------------
		public static ProjectConfigTemplate singleton
		{
			get
			{
				if (!_instance)
					_instance = Resources.FindObjectsOfTypeAll<ProjectConfigTemplate>().FirstOrDefault();
				return _instance;
			}
		}
	// -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public void OnValidate()
    {
#if UNITY_EDITOR
        if (networkType == NetworkType.Server)
        {
            EditorTools.RemoveScriptingDefine(isClient);
            EditorTools.AddScriptingDefine(isServer);
            debug.Log("[ProjectConfig] Switched to SERVER mode.");
        }
        else if (networkType == NetworkType.HostAndPlay)
        {
            EditorTools.AddScriptingDefine(isServer);
            EditorTools.AddScriptingDefine(isClient);
            debug.Log("[ProjectConfig] Switched to HOST & PLAY mode.");
        }
        else
        {
            EditorTools.AddScriptingDefine(isClient);
            EditorTools.RemoveScriptingDefine(isServer);
            debug.Log("[ProjectConfig] Switched to CLIENT mode.");
        }
#endif
    }
    
		// -------------------------------------------------------------------------------
	}

}

// =======================================================================================
