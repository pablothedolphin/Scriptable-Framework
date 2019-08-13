using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>TransformReference</c> with a Transform in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/TransformReference Populator")]
    public class TransformReferencePopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceItem</c> to be populated by this component.
		/// </summary>
        public TransformReference referenceItem;

		/// <summary>
		/// The object to populate the <c>ReferenceItem</c> with.
		/// </summary>
        public Transform item;

		/// <summary>
		/// Initialises the <c>ReferenceItem</c> by passing it the item on Awake.
		/// </summary>
        private void Awake ()
        {
            referenceItem.reference = item;
        }
    }
}