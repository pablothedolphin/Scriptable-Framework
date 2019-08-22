using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility component to populate a <c>AnimatorList</c> with Animators in the scene.
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Populators/AnimatorList Populator")]
    public class AnimatorListPopulator : MonoBehaviour
	{
		/// <summary>
		/// The <c>ReferenceList</c> to be populated by this component.
		/// </summary>
        public AnimatorList referenceList;

		/// <summary>
		/// The array of objects to populate the <c>ReferenceList</c> with.
		/// </summary>
		public Animator[] items;

		/// <summary>
		/// Initialises the <c>ReferenceList</c> by passing it the array on Awake.
		/// </summary>
        private void Awake ()
        {
			referenceList.Initialise (items);
        }
    }
}