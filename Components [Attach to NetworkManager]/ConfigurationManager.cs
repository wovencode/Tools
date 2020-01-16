// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using wovencode;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace wovencode
{
	
	// ===================================================================================
	// ConfigurationManager
	// ===================================================================================
	[DisallowMultipleComponent]
	public partial class ConfigurationManager : MonoBehaviour
	{

		[Header("Game Rules")]
		public GameRulesTemplate gameRulesTemplate;

		// -----------------------------------------------------------------------------------
	
	}

}