using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A high level wrapper class that encapsulates a list of <c>StateMachine</c>s and drives the active state of each
	/// sub object according to a given list index that represents a state.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/State Machines/State Machine Controller")]
	public class StateMachineController : StateMachineBase
    {
		/// <summary>
		/// A list of StateMachines that represent the current object state. The order of the objects is expected
		/// to match the order of the states.
		/// </summary>
		[Space]
		public List<StateMachineBase> subStateMachines;

		/// <summary>
		/// Actually runs the loop which sets each object's state on or off.
		/// </summary>
		/// <param name="newSelectionIndex">Index of the state to be active.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState (int newSelectionIndex)
		{
			selectionIndex = newSelectionIndex;

			for (int i = 0; i < subStateMachines.Count; i++)
			{
				if (!CheckListItemBeforeUpdate (i)) return false;

				subStateMachines[i].UpdateState (i == selectionIndex);
			}

			return true;
		}

		/// <summary>
		/// Actually runs the loop which sets each object's state on or off.
		/// </summary>
		/// <param name="stateForAll">The new state for all objects.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState (bool stateForAll)
		{
			selectionIndex = -1;

			for (int i = 0; i < subStateMachines.Count; i++)
			{
				if (!CheckListItemBeforeUpdate (i)) return false;

				subStateMachines[i].UpdateState (stateForAll);
			}

			return true;
		}

		/// <summary>
		/// Actually applies the new state to the selected object.
		/// </summary>
		/// <param name="newSelectionIndex">The index of the object to update.</param>
		/// <param name="stateAtThisObject">The state to provide that object with.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState (int newSelectionIndex, bool stateAtThisObject)
		{
			selectionIndex = -1;

			if (!CheckListItemBeforeUpdate (newSelectionIndex)) return false;

			subStateMachines[newSelectionIndex].UpdateState (stateAtThisObject);

			return true;
		}

		/// <summary>
		/// Actually runs the loop which applies your given range of objects and the rest with another.
		/// </summary>
		/// <param name="startIndex">Where to start applying your state (inclusive).</param>
		/// <param name="length">How many objects to affect.</param>
		/// <param name="stateToApply">The state to apply within your given range.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState (int startIndex, int length, bool stateToApply)
		{
			selectionIndex = -1;

			for (int i = 0; i < subStateMachines.Count; i++)
			{
				if (!CheckListItemBeforeUpdate (i)) return false;

				if (i >= startIndex && i < startIndex + length)
					subStateMachines[i].UpdateState (stateToApply);
				else
					subStateMachines[i].UpdateState (!stateToApply);
			}

			return true;
		}

		/// <summary>
		/// Checks if the list is null. Since the list can be a varying type, defining this as 
		/// an abstract function is needed to help reduce code.
		/// </summary>
		/// <returns>If the list is null or not.</returns>
		protected override bool CheckListBeforeUpdate ()
		{
			if (subStateMachines == null)
			{
				Debug.LogError (string.Format ("'{0}' has a null list. State update failed.", name));
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks if the index is greater than -1 but less than the length of the list.
		/// </summary>
		/// <param name="objectIndex">The index of the object to check.</param>
		/// <returns>True if the index is within a range that won't throw an out of range exception.</returns>
		protected override bool CheckSelectionIndexBeforeUpdate (int objectIndex)
		{
			if (objectIndex < 0 || objectIndex >= subStateMachines.Count)
			{
				Debug.LogError (string.Format ("Provided index {0} to '{1}' but the list count is {2}", objectIndex, name, subStateMachines.Count));
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks if an item in the list is null. Since the list can be a varying type, defining this as 
		/// an abstract function is needed to help reduce code.
		/// </summary>
		/// <param name="objectIndex">The index of the object to check.</param>
		/// <returns>If the item is null or not.</returns>
		protected override bool CheckListItemBeforeUpdate (int objectIndex)
		{
			if (subStateMachines[objectIndex] == null)
			{
				Debug.LogError (string.Format ("'{0}' has a null item in its list. State update failed.", name));
				return false;
			}

			return true;
		}

		/// <summary>
		/// If the list is not null, and has a count beyond 0, sets the current state according to <c>defaultState</c>.
		/// </summary>
		public override void Clear ()
        {
			if (subStateMachines == null) return;

			if (subStateMachines.Count == 0) return;

			for (int i = 0; i < subStateMachines.Count; i++)
			{
				if (subStateMachines[i] == null) return;
			}

			switch (defaultState)
			{
				case DefaultState.AllActive:
					ApplyState (true);
					break;
				case DefaultState.NoneActive:
					ApplyState (false);
					break;
				default:
					ApplyState (0);
					break;
			}
		}

		/// <summary>
		/// Calls <c>Clear ()</c>
		/// </summary>
        public override void Reset ()
        {
            Clear ();
        }
    }
}
