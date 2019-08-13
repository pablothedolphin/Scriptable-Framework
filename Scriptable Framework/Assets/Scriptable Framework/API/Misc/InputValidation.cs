using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility class for validating when certain types of input are possible.
	/// </summary>
	public static class InputValidation
	{
		/// <summary>
		/// Works in tandem with <c>Dragable</c> component to check if UI is being dragged.
		/// </summary>
		public static bool draggingUI = false;

		/// <summary>
		/// Static Boolean function that checks whether the position of the mouse if over a 3D object. 
		/// Works for touch input as well.
		/// </summary>
		/// <returns>Boolean on mouse over</returns>
		public static bool IsMouseOverUIObject ()
		{
			if (EventSystem.current != null)
			{
				PointerEventData eventDataCurrentPosition = new PointerEventData (EventSystem.current)
				{
					position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y)
				};

				List<RaycastResult> results = new List<RaycastResult> ();
				EventSystem.current.RaycastAll (eventDataCurrentPosition, results);

				return results.Count > 0;
			}
			else
			{
				Debug.LogError ("No EventSystem present to check for 'InputValidation.IsMouseOverUIObject ()'.");
				return false;
			}
		}
	}
}