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
    public abstract class ReferenceList<T> : RuntimeList<T> where T : class
    {

    }
}