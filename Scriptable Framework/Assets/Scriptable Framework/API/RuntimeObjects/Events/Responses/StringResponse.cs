using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>UnityEvent</c> able to take a dynamic string.
	/// </summary>
	[System.Serializable]
    public class StringResponse : UnityEvent<string>
    {

    }
}