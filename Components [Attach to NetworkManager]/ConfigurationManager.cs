// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using Wovencode;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Wovencode
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