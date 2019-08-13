using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>MeshRendererList</c> with MeshRenderers in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/MeshRendererList Populator")]
    public class MeshRendererListPopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceList</c> to be populated by this component.
		/// </summary>
		public MeshRendererList referenceList;

		/// <summary>
		/// The array of objects to populate the <c>ReferenceList</c> with.
		/// </summary>
		public MeshRenderer[] items;

		/// <summary>
		/// Initialises the <c>ReferenceList</c> by passing it the array on Awake.
		/// </summary>
		private void Awake ()
        {
			referenceList.Initialise (items);
        }
    }
}