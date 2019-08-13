using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ReferenceList</c> which can hold a list of Transforms.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Reference/List/Transforms")]
    public class TransformList : ReferenceList<Transform>
    {

    }
}