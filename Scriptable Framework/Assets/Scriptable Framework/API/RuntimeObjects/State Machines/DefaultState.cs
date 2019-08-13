using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A set of possible states a <c>StateMachine</c> can default to.
	/// </summary>
	public enum DefaultState : int
	{
		FirstActive = 0,
		AllActive = 1,
		NoneActive = 2
	}
}