using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// An event handle designed to pass a Color.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Events/Color Event")]
    public class ColorEvent : AppEvent<Color>
    {

    }
}