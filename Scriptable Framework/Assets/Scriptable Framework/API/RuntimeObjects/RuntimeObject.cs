using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Base class for most of the Scriptable Framework API. These object types that will be reset
	/// on application start.
	/// </summary>
	public abstract class RuntimeObject : ScriptableObject
    {
#if UNITY_EDITOR
		/// <summary>
		/// A serialized string field on every RuntimeObject to be used for documentation
		/// of different object usecases in the editor. Gets stripped in builds to reduce build size.
		/// </summary>
		[TextArea]
		[SerializeField]
		protected string description;
#endif		

		/// <summary>
		/// Clear the object of its current data.
		/// </summary>
		public abstract void Clear ();

        /// <summary>
        /// Set the object to use its default value. Usually just clears it.
        /// </summary>
        public abstract void Reset ();
    }
}