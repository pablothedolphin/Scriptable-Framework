using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A <c>ReferenceItem</c> which can hold a GameObject.
	/// </summary>
    [CreateAssetMenu (menuName = "Runtime Objects/Reference/Item/GameObject")]
    public class GameObjectReference : ReferenceItem<GameObject>
    {

    }
}