using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
    /// <summary>
    /// A generic RuntimeObject that stores a single object.
    /// </summary>
    /// <typeparam name="T">The type of object to be stored</typeparam>
    public abstract class RuntimeItem<T> : RuntimeObject
    {
        /// <summary>
        /// Calls Clear ().
        /// </summary>
        public override void Reset ()
        {
            Clear ();
        }
    }
}