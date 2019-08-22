using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>AnimatorReference</c> with a Animator in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/AnimatorReference Populator")]
    public class AnimatorReferencePopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceItem</c> to be populated by this component.
		/// </summary>
        public AnimatorReference referenceItem;

		/// <summary>
		/// The object to populate the <c>ReferenceItem</c> with.
		/// </summary>
        public Animator item;

		/// <summary>
		/// Initialises the <c>ReferenceItem</c> by passing it the item on Awake.
		/// </summary>
        private void Awake ()
        {
            referenceItem.reference = item;
        }
    }
}