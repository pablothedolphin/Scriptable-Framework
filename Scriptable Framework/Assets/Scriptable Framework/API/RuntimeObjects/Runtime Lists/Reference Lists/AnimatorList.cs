using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ReferenceList</c> which can hold a list of Animators.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Reference/List/Animators")]
    public class AnimatorList : ReferenceList<Animator>
    {

    }
}