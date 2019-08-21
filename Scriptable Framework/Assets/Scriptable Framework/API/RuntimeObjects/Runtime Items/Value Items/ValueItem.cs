using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
    /// <summary>
    /// An abstract generic RuntimeObject which encapsulates a given value type.
    /// Inherit from this class to create your own RuntimeValue sub class.
    /// Give your class the CreateAssetMenu attribute to serialize an instance of it.
    /// A default value can be optionally set in the inspector.
    /// </summary>
    /// <typeparam name="T">A <c>struct</c> (value type) object to be stored in this asset.</typeparam>
    public abstract class ValueItem<T> : RuntimeItem<T>, IValueContainer where T : struct
    {
		/// <summary>
		/// The value type object being stored.
		/// </summary>
		[Space]
		public T value;

		/// <summary>
		/// A default value for this object to initialise to if, in the inspector, 
		/// <c>UseCustomDefault</c> was set to true.
		/// </summary>
		[Space]
        [Header ("Editor Properties")]
        public T customDefaultValue;

		/// <summary>
		/// If true, the <c>value</c> property will initialise to the user defined default value.
		/// </summary>
		[SerializeField] protected bool useCustomDefault;

		/// <summary>
		/// Toggle this on to ensure that the object resets with user defined custom default value(s).
		/// </summary>
		public bool UseCustomDefault { get => useCustomDefault; set => useCustomDefault = value; }

		/// <summary>
		/// Call the constructor of T and set value as the result.
		/// </summary>
		public override void Clear ()
		{
			value = Activator.CreateInstance<T> ();
		}

		/// <summary>
		/// If <c>UseCustomDefault</c> was set to true, the <c>value</c> property will be set to
		/// the user defined default. Otherwise, this will simply call <c>Clear ()</c>.
		/// </summary>
		public override void Reset ()
        {
            if (useCustomDefault)
                value = customDefaultValue;
            else
                Clear ();
        }
    }
}
