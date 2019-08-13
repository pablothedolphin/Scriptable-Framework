using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>MeshRendererReference</c> with a MeshRenderer in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/MeshRendererReference Populator")]
    public class MeshRendererReferencePopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceItem</c> to be populated by this component.
		/// </summary>
        public MeshRendererReference referenceItem;

		/// <summary>
		/// The object to populate the <c>ReferenceItem</c> with.
		/// </summary>
        public MeshRenderer item;

		/// <summary>
		/// Initialises the <c>ReferenceItem</c> by passing it the item on Awake.
		/// </summary>
        private void Awake ()
        {
            referenceItem.reference = item;
        }
    }
}