using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// An event handle designed to pass a string.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Events/String Event")]
    public class StringEvent : AppEvent<string>
    {

    }
}