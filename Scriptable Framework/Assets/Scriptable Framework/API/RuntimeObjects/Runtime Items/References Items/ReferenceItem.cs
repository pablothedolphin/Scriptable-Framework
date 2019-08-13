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
    public abstract class ReferenceItem<T> : RuntimeItem<T> where T : class
    {
		/// <summary>
		/// The reference type obect being stored.
		/// </summary>
		[Space]
		public T reference;

		/// <summary>
		/// Set value to null rather can create a new instance to avoid issues like
		/// instantiating new GameObjects.
		/// </summary>
		public override void Clear ()
        {
			reference = null;
        }
    }
}