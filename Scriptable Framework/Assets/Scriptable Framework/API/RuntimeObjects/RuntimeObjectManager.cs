using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Utility class designed purely for the resetting of any ScriptableObject
	/// in a Resources directory that derives from <c>RuntimeObject</c>.
	/// </summary>
	public static class RuntimeObjectManager
	{
        /// <summary>
        /// Automatically called on application start.
        /// Reset all assets that derive from RuntimeObject and are within a Resources directory.
        /// If you don't want their data to persist between scenes, call this again BEFORE scene change.
        /// </summary>
		[RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitaliseApp ()
		{
			ResetObjectsOfType<RuntimeObject> ();

			#if UNITY_EDITOR
			Application.quitting += ClearObjectsOfType<RuntimeObject>;
			#endif
		}

		/// <summary>
		/// Reset all assets that are within a Resources directory of a given type T where T 
		/// derives from RuntimeObject.
		/// If you don't want their data to persist between scenes, call this BEFORE scene change.
		/// </summary>
		/// <typeparam name="T">The type of resource to be reset. Must derive from RuntimeObject.</typeparam>
		public static void ResetObjectsOfType<T> () where T : RuntimeObject
		{
			T[] objects = Resources.LoadAll<T> ("/");

			for (int i = 0; i < objects.Length; i++)
			{
				#if UNITY_EDITOR
				UnityEditor.EditorUtility.SetDirty (objects[i]);
				#endif

				objects[i].Reset ();
			}

			Debug.Log (string.Format ("Reset {0} objects of type {1}", objects.Length, typeof (T)));
		}

		/// <summary>
		/// Clear all assets that are within a Resources directory of a given type T where T 
		/// derives from RuntimeObject.
		/// If you don't want their data to persist between scenes, call this BEFORE scene change.
		/// </summary>
		/// <typeparam name="T">The type of resource to be cleared. Must derive from RuntimeData.</typeparam>
		public static void ClearObjectsOfType<T> () where T : RuntimeObject
		{
			T[] objects = Resources.LoadAll<T> ("/");

			for (int i = 0; i < objects.Length; i++)
			{
				#if UNITY_EDITOR
				UnityEditor.EditorUtility.SetDirty (objects[i]);
				#endif

				objects[i].Clear ();
			}

			Debug.Log (string.Format ("Cleared {0} objects of type {1}", objects.Length, typeof (T)));
		}
	}
}