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

	}
}
