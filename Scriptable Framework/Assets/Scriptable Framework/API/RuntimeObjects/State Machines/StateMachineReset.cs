using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// If using the StateMachineAPI in your scene, it is recommended to have an instance of this in your scene as well
	/// to allow for proper initialisation.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Misc/State Machine Reset")]
	public class StateMachineReset : MonoBehaviour
	{
		/// <summary>
		/// Calls <c>StateMachineBase.Reset ()</c> on all StateMachines and StateMachineControllers.
		/// </summary>
		private void OnEnable ()
		{
			RuntimeObjectManager.ResetObjectsOfType<StateMachineBase> ();
		}
	}
}