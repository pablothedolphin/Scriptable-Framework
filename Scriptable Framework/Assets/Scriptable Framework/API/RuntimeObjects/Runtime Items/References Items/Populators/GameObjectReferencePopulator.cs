using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>GameObjectReference</c> with a GameObject in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/GameObjectReference Populator")]
    public class GameObjectReferencePopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceItem</c> to be populated by this component.
		/// </summary>
        public GameObjectReference referenceItem;

		/// <summary>
		/// The object to populate the <c>ReferenceItem</c> with.
		/// </summary>
        public GameObject item;

		/// <summary>
		/// Initialises the <c>ReferenceItem</c> by passing it the item on Awake.
		/// </summary>
        private void Awake ()
        {
            referenceItem.reference = item;
        }
    }
}