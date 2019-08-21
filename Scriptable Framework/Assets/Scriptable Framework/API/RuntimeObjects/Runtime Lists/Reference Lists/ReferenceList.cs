using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A constrained version of RuntimeList that can only be used on reference types.
	/// </summary>
	/// <typeparam name="T">Must be at least a class NOT a struct.</typeparam>
    public abstract class ReferenceList<T> : RuntimeList<T>, IReferenceContainer where T : class
    {
		/// <summary>
		/// If true, the <c>items</c> property will not be cleared on application start.
		/// This is useful when wanting a persistent reference to another asset rather than a runtime
		/// reference to an object in a scene.
		/// </summary>
		[Space]
		[Header ("Editor Properties")]
		[SerializeField] protected bool forAssetReferencingOnly;

		/// <summary>
		/// Toggle this on to ensure that the object ignores all calls for either clearing or reseting its
		/// reference(s).
		/// </summary>
		public bool ForAssetReferencingOnly { get => forAssetReferencingOnly; set => forAssetReferencingOnly = value; }

		/// <summary>
		/// Empties the current internal list. If marked for asset referencing only, the data will not be cleared.
		/// </summary>
		public override void Clear ()
		{
			if (!forAssetReferencingOnly) items.Clear ();
		}
	}
}