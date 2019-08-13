using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ReferenceList</c> which can hold a list of GameObjects.
	/// </summary>
	[CreateAssetMenu (menuName = "Runtime Objects/Reference/List/GameObjects")]
    public class GameObjectList : ReferenceList<GameObject>
    {

    }
}