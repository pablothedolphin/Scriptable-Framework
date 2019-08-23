using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	public abstract class StateMachineBase : RuntimeObject
	{
		/// <summary>
		/// A enum to determine how the <c>Clear ()</c> and <c>Reset ()</c> functions behave.
		/// </summary>
		[Space]
		public DefaultState defaultState = DefaultState.FirstActive;

		/// <summary>
		/// The current index of the state machine. Default value is 0. When <c>Clear ()</c> is called and
		/// <c>defaultState</c> is not set to first active, will be set to -1.
		/// </summary>
		public int selectionIndex = 0;

		/*private void Awake ()
		{
			Resources.LoadAll<RuntimeObjectDatabase> ("/")[0].RegisterStateMachine (this);
		}*/

		/// <summary>
		/// Applies a new single state to the list.
		/// </summary>
		/// <param name="newSelectionIndex">Index of the state to be active.</param>
		/// <param name="onlyThisObject">If true, the update for all other objects will be skipped.</param>
		public void UpdateState (int newSelectionIndex)
		{
			if (!CheckListBeforeUpdate ()) return;

			if (!CheckSelectionIndexBeforeUpdate (newSelectionIndex)) return;

			ApplyState (newSelectionIndex);
		}

		/// <summary>
		/// Applies the same state to all objects in the current list.
		/// </summary>
		/// <param name="stateForAll">The new state for all contained object.</param>
		public void UpdateState (bool stateForAll)
		{
			if (!CheckListBeforeUpdate ()) return;

			ApplyState (stateForAll);
		}

		/// <summary>
		/// Applies a state to a single object without affecting other objects in the list.
		/// </summary>
		/// <param name="newSelectionIndex">The index of the object to update.</param>
		/// <param name="stateAtThisObject">The state to provide that object with.</param>
		public void UpdateState (int newSelectionIndex, bool stateAtThisObject)
		{
			if (!CheckListBeforeUpdate ()) return;

			if (!CheckSelectionIndexBeforeUpdate (newSelectionIndex)) return;

			ApplyState (newSelectionIndex, stateAtThisObject);
		}

		/// <summary>
		/// Applies a state to all objects in the given range and the opposite state to the objects
		/// outside of the range.
		/// </summary>
		/// <param name="startIndex">Where to start applying your state (inclusive).</param>
		/// <param name="length">How many objects to affect.</param>
		/// <param name="stateToApply">The state to apply within your given range.</param>
		public void UpdateState (int startIndex, int length, bool stateToApply)
		{
			if (!CheckListBeforeUpdate ()) return;

			ApplyState (startIndex, length, stateToApply);
		}

		/// <summary>
		/// Actually runs the loop which updates the state.
		/// </summary>
		/// <param name="newSelectionIndex">Index of the state to be active.</param>
		/// <param name="onlyThisObject">If true, the update for all other objects will be skipped.</param>
		protected abstract void ApplyState (int newSelectionIndex);

		/// <summary>
		/// Actually runs the loop which sets the state of all objects in the list.
		/// </summary>
		/// <param name="stateForAll">State to apply for all.</param>
		protected abstract void ApplyState (bool stateForAll);

		/// <summary>
		/// Actually applies the new state to the selected object.
		/// </summary>
		/// <param name="newSelectionIndex">The index of the object to update.</param>
		/// <param name="stateAtThisObject">The state to provide that object with.</param>
		protected abstract void ApplyState (int newSelectionIndex, bool stateAtThisObject);

		/// <summary>
		/// Actually runs the loop which applies your given range of objects and the rest with another.
		/// </summary>
		/// <param name="startIndex">Where to start applying your state (inclusive).</param>
		/// <param name="length">How many objects to affect.</param>
		/// <param name="stateToApply">The state to apply within your given range.</param>
		protected abstract void ApplyState (int startIndex, int length, bool stateToApply);

		/// <summary>
		/// Checks if the list is null. Since the list can be a varying type, defining this as 
		/// an abstract function is needed to help reduce code.
		/// </summary>
		/// <returns>If the list is null or not.</returns>
		protected abstract bool CheckListBeforeUpdate ();

		/// <summary>
		/// Checks if the index is greater than -1 but less than the length of the list.
		/// </summary>
		/// <param name="objectIndex">The index of the object to check.</param>
		/// <returns>True if the index is within a range that won't throw an out of range exception.</returns>
		protected abstract bool CheckSelectionIndexBeforeUpdate (int objectIndex);

		/// <summary>
		/// Checks if an item in the list is null. Since the list can be a varying type, defining this as 
		/// an abstract function is needed to help reduce code.
		/// </summary>
		/// <param name="objectIndex">The index of the object to check.</param>
		/// <returns>If the item is null or not.</returns>
		protected abstract bool CheckListItemBeforeUpdate (int objectIndex);
	}
}