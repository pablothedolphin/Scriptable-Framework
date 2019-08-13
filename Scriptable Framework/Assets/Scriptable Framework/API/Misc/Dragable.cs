using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace ScriptableFramework
{
	/// <summary>
	/// Apply this to all UI elements that can be dragged by the mouse so that
	/// inputs don't clash with things like cameras.
	/// </summary>
	public class Dragable : MonoBehaviour, IBeginDragHandler, IEndDragHandler
	{
		/// <summary>
		/// Called by the Unity <c>EventSystem</c> when this object starts being dragged.
		/// </summary>
		/// <param name="eventData">Contains info about the pointer event</param>
		public void OnBeginDrag (PointerEventData eventData)
		{
			InputValidation.draggingUI = true;
		}

		/// <summary>
		/// Called by the Unity <c>EventSystem</c> when this object stops being dragged.
		/// </summary>
		/// <param name="eventData">Contains info about the pointer event</param>
		public void OnEndDrag (PointerEventData eventData)
		{
			InputValidation.draggingUI = false;
		}
	}
}