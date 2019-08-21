using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// To be used in both <c>ReferenceList</c> and <c>ReferenceItem</c> so that their common fields can be enforced
	/// through a common interface.
	/// </summary>
	public interface IReferenceContainer
	{
		/// <summary>
		/// Toggle this on to ensure that the object ignores all calls for either clearing or reseting its
		/// reference(s).
		/// </summary>
		bool ForAssetReferencingOnly { get; set; }
	}
}