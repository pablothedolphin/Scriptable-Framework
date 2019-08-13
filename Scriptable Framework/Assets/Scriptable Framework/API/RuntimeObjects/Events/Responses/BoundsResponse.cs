using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>UnityEvent</c> able to take a dynamic Bounds.
	/// </summary>
	[System.Serializable]
    public class BoundsResponse : UnityEvent<Bounds>
    {

    }
}
