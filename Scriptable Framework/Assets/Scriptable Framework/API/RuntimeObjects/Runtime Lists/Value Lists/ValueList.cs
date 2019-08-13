using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

namespace ScriptableFramework
{
    /// <summary>
    /// An abstract generic RuntimeList which encapsulates a given value type.
    /// Inherit from this class to create your own ValueList sub class.
    /// Give your class the CreateAssetMenu attribute to serialize an instance of it.
    /// A default list can be optionally set in the inspector.
    /// </summary>
    /// <typeparam name="T">This list will be constrained to <c>struct</c> (value type) objects.</typeparam>
    public abstract class ValueList<T> : RuntimeList<T> where T : struct
    {
		/// <summary>
		/// A default set of values for this object to initialise to if, in the inspector, 
		/// <c>useCustomDefaultValues</c> was set to true.
		/// </summary>
		[Space]
        [Header ("Editor Properties")]
        public List<T> customDefaultValues;
		
		/// <summary>
		/// If true, the <c>values</c> property will initialise to the user defined default values.
		/// </summary>
		public bool useCustomDefaultValues;

		/// <summary>
		/// Empties the current internal list.
		/// </summary>
        public override void Clear ()
        {
            items.Clear ();
        }

		/// <summary>
		/// Clears the <c>ValueList</c> then, if <c>useCustomDefaultValues</c> is true, reinitialises the list
		/// with the contents of <c>customDefaultValues</c>.
		/// </summary>
		public override void Reset ()
        {
            Clear ();

            if (useCustomDefaultValues)
            {
                items.AddRange (customDefaultValues);
            }
        }

		/// <summary>
		/// Shorthand for creating a new <c>NativeArray</c> out of the current <c>ValueList</c> based on a
		/// given allocator type.
		/// </summary>
		/// <param name="allocator">Specifies which allocation type to use.</param>
		/// <returns>A new <c>NativeArray</c> copy of this list's values.</returns>
		public virtual NativeArray<T> ToNativeArray (Allocator allocator)
		{
			return new NativeArray<T> (items.ToArray (), allocator);
		}
    }
}