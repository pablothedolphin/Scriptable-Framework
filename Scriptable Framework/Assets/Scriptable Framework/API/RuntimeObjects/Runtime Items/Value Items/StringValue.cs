using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ValueItem</c> which can hold a DataString which can be used in place of a regular String.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Value/Item/String")]
    public class StringValue : ValueItem<DataString>
    {
		/// <summary>
		/// Included for <c>ValueItem</c>s to be set via UI events. This overload will make this object compatible with
		/// dynamic values from input fields.
		/// </summary>
		/// <param name="newValue">The new value passed from the UI event.</param>
		public void UpdateValue (string newValue) => value = newValue;
	}
}
