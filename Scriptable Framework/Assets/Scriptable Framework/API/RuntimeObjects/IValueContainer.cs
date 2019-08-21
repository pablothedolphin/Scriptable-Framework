using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// To be used in both <c>ValueList</c> and <c>ValueItem</c> so that their common fields can be enforced
	/// through a common interface.
	/// </summary>
	public interface IValueContainer
	{
		/// <summary>
		/// Toggle this on to ensure that the object resets with user defined custom default value(s).
		/// </summary>
		bool UseCustomDefault { get; set; }
	}
}