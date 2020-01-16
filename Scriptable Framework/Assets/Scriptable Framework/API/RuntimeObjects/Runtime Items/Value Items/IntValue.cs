using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ValueItem</c> which can hold a int.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Value/Item/Int")]
    public class IntValue : ValueItem<int>
    {
		/// <summary>
		/// Included for <c>ValueItem</c>s to be set via UI events. This overload makes this object compatible with
		/// dynamic values from sliders or scroll bars.
		/// </summary>
		/// <param name="newValue">The new value passed from the UI event.</param>
		public void UpdateValue (float newValue) => value = (int)newValue;
	}
}
