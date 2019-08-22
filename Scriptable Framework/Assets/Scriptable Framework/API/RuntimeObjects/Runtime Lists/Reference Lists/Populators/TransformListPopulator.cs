using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>TransformList</c> with Transforms in the scene.
	/// </summary>
	[DefaultExecutionOrder (-1000)]
	[AddComponentMenu ("Scriptable Framework/Populators/TransformList Populator")]
    public class TransformListPopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceList</c> to be populated by this component.
		/// </summary>
        public TransformList referenceList;

		/// <summary>
		/// The array of objects to populate the <c>ReferenceList</c> with.
		/// </summary>
		public Transform[] items;

		/// <summary>
		/// Initialises the <c>ReferenceList</c> by passing it the array on Awake.
		/// </summary>
		private void Awake ()
        {
			referenceList.Initialise (items);
        }
    }
}