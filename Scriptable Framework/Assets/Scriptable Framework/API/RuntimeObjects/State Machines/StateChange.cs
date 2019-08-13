using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A helper component designed for quickly allowing control over a StateMachine by hooking it up to UI objects through
	/// either static or dynamic function assignment.
	/// </summary>
	[AddComponentMenu("Scriptable Framework/Misc/State Change")]
	public class StateChange : MonoBehaviour
	{
		#region Variables
		/// <summary>
		/// The StateMachine to be controlled by the UI object.
		/// </summary>
		public StateMachine stateMachine;
		#endregion

		/// <summary>
		///   Updates the GameObjects under the state machine.
		/// </summary>
		/// <param name="value">The index to update the state machine to.</param>
		public void UpdateStateMachine(int value)
		{
			if (stateMachine.selectionIndex != value)
				stateMachine.UpdateState(value);
			else
				stateMachine.UpdateState(false);
		}

		/// <summary>
		///   Updates the GameObjects under the state machine.
		/// </summary>
		/// <param name="value">The value to apply the same state to all GameObjects in the current list.</param>
		public void UpdateStateMachine(bool value)
		{
			stateMachine.UpdateState(value);
		}
	}
}