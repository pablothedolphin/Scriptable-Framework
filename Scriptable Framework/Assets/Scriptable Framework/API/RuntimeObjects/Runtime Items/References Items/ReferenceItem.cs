using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
    /// <summary>
    /// An abstract generic RuntimeObject which encapsulates a given reference type.
    /// Inherit from this class to create your own RuntimeReference sub class.
    /// Give your class the CreateAssetMenu attribute to serialize an instance of it.
    /// </summary>
    /// <typeparam name="T">A class (reference type) object to be stored in this asset.</typeparam>
    public abstract class ReferenceItem<T> : RuntimeItem<T>, IReferenceContainer where T : class
    {
		/// <summary>
		/// The reference type obect being stored.
		/// </summary>
		[Space]
		public T reference;

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
		/// Set value to null rather can create a new instance to avoid issues like
		/// instantiating new objects. If marked for asset referencing only, the data will not be cleared.
		/// </summary>
		public override void Clear ()
		{
			if (!ForAssetReferencingOnly) reference = null;
		}
    }
}