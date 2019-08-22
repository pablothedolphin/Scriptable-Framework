using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ReferenceList</c> which can hold a list of Animators. Also has some convenience methods for interacting
	/// with all items at once.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Reference/List/Animators")]
    public class AnimatorList : ReferenceList<Animator>
    {
		/// <summary>
		/// Sets the value of the given boolean parameter to all Animators in the list.
		/// </summary>
		/// <param name="name">The parameter name</param>
		/// <param name="value">The new parameter value</param>
		public virtual void SetBoolToAll (string name, bool value)
		{
			for (int i = 0; i < Count; i++) this[i].SetBool (name, value);
		}

		/// <summary>
		/// Sets the value of the given float parameter to all Animators in the list.
		/// </summary>
		/// <param name="name">The parameter name</param>
		/// <param name="value">The new parameter value</param>
		public virtual void SetFloatToAll (string name, float value)
		{
			for (int i = 0; i < Count; i++) this[i].SetFloat (name, value);
		}

		/// <summary>
		/// Sets the value of the given integer parameter to all Animators in the list.
		/// </summary>
		/// <param name="name">The parameter name</param>
		/// <param name="value">The new parameter value</param>
		public virtual void SetIntegerToAll (string name, int value)
		{
			for (int i = 0; i < Count; i++) this[i].SetInteger (name, value);
		}

		/// <summary>
		/// Sets the value of the given trigger parameter to all Animators in the list.
		/// </summary>
		/// <param name="name">The parameter name</param>
		public virtual void SetTriggerToAll (string name)
		{
			for (int i = 0; i < Count; i++) this[i].SetTrigger (name);
		}
	}
}