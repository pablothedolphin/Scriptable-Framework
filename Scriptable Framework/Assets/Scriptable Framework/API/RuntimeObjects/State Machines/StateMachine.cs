using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A high level wrapper class that encapsulates a <c>GameObjectList</c> and drives the active state of each
	/// object according to a given list index that represents a state.
	/// </summary>
	[CreateAssetMenu(menuName = "Runtime Objects/State Machines/State Machine")]
	public class StateMachine : StateMachineBase
	{
		/// <summary>
		/// A list of GameObjects that represent the current object state. The order of the objects is expected
		/// to match the order of the states.
		/// </summary>
		[Space]
		public GameObjectList gameObjects;

		/// <summary>
		/// Actually runs the loop which sets the GameObjects on or off.
		/// </summary>
		/// <param name="newSelectionIndex">Index of the object to be left on.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState(int newSelectionIndex)
		{
			selectionIndex = newSelectionIndex;

			for (int i = 0; i < gameObjects.Count; i++)
			{
				if (!CheckListItemBeforeUpdate(i)) return false;

				gameObjects[i].SetActive(i == selectionIndex);
			}

			return true;
		}

		/// <summary>
		/// Actually runs the loop which sets all the GameObjects on or off.
		/// </summary>
		/// <param name="stateForAll">The new state for all GameObjects.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState(bool stateForAll)
		{
			selectionIndex = -1;

			for (int i = 0; i < gameObjects.Count; i++)
			{
				if (!CheckListItemBeforeUpdate(i)) return false;

				gameObjects[i].SetActive(stateForAll);
			}

			return true;
		}

		/// <summary>
		/// Actually applies the new state to the selected object.
		/// </summary>
		/// <param name="newSelectionIndex">The index of the object to update.</param>
		/// <param name="stateAtThisObject">The state to provide that object with.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState(int newSelectionIndex, bool stateAtThisObject)
		{
			selectionIndex = -1;

			for (int i = 0; i < gameObjects.Count; i++)
			{
				if (!CheckListItemBeforeUpdate(i)) return false;
			}

			gameObjects[newSelectionIndex].SetActive(stateAtThisObject);

			return true;
		}

		/// <summary>
		/// Actually runs the loop which applies your given range of objects and the rest with another.
		/// </summary>
		/// <param name="startIndex">Where to start applying your state (inclusive).</param>
		/// <param name="length">How many objects to affect.</param>
		/// <param name="stateToApply">The state to apply within your given range.</param>
		/// <returns>Whether or not the operation succeeded.</returns>
		protected override bool ApplyState(int startIndex, int length, bool stateToApply)
		{
			selectionIndex = -1;

			for (int i = 0; i < gameObjects.Count; i++)
			{
				if (!CheckListItemBeforeUpdate(i)) return false;

				if (i >= startIndex && i < startIndex + length)
					gameObjects[i].SetActive (stateToApply);
				else
					gameObjects[i].SetActive (!stateToApply);
			}

			return true;
		}

		/// <summary>
		/// Checks if the list is null. Since the list can be a varying type, defining this as 
		/// an abstract function is needed to help reduce code.
		/// </summary>
		/// <returns>If the list is null or not.</returns>
		protected override bool CheckListBeforeUpdate()
		{
			if (gameObjects == null)
			{
				Debug.LogError(string.Format("'{0}' has a null list. State update failed.", name));
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks if the index is greater than -1 but less than the length of the list.
		/// </summary>
		/// <param name="objectIndex">The index of the object to check.</param>
		/// <returns>True if the index is within a range that won't throw an out of range exception.</returns>
		protected override bool CheckSelectionIndexBeforeUpdate(int objectIndex)
		{
			if (objectIndex < 0 || objectIndex >= gameObjects.Count)
			{
				Debug.LogError(string.Format("Provided index {0} to '{1}' but the list count is {2}", objectIndex, name, gameObjects.Count));
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
		protected override bool CheckListItemBeforeUpdate(int objectIndex)
		{
			if (gameObjects[objectIndex] == null)
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
			if (gameObjects == null) return;

			if (gameObjects.Count == 0) return;

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
			if (gameObjects == null) return;

			for (int i = 0; i < gameObjects.Count; i++)
			{
				if (gameObjects[i] == null) return;
			}

			Clear ();
        }
	}
}
