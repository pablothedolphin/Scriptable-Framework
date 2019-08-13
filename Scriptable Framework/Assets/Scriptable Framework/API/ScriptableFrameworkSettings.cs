#if UNITY_EDITOR
using UnityEditor;

namespace ScriptableFramework
{
	/// <summary>
	/// Contains global settings that effect how the Scriptable Framework API behaves.
	/// </summary>
	[InitializeOnLoad]
	internal static class ScriptableFrameworkSettings
	{
		/// <summary>
		/// The path to the event logging menu toggle as well as the key string of the corresponding
		/// Editor preference.
		/// </summary>
		private const string EditorEventLoggingMenu = "Scriptable Framework/Editor Event Logging";

		/// <summary>
		/// The current state of the editor event logging setting.
		/// </summary>
		internal static bool EditorEventLogging;


		/// <summary>
		/// Static constructor which reads all editor preferences on this machine for the 
		/// current version of the Unity editor. Initialises any read values.
		/// Called on load thanks to the InitializeOnLoad attribute on the class.
		/// </summary>
		static ScriptableFrameworkSettings ()
		{
			EditorEventLogging = EditorPrefs.GetBool (EditorEventLoggingMenu, false);

			// Delaying until first editor tick so that the menu
			// will be populated before setting check state, and
			// re-apply correct action
			EditorApplication.delayCall += () => { PerformToggle (EditorEventLogging); };
		}

		/// <summary>
		/// The menu item method for toggling editor event logging.
		/// </summary>
		[MenuItem (EditorEventLoggingMenu)]
		private static void ToggleEditorEventLogging ()
		{
			PerformToggle (!EditorEventLogging);
		}

		/// <summary>
		/// Actually handles the toggle of the setting.
		/// </summary>
		/// <param name="enabled">The new value to toggle to.</param>
		private static void PerformToggle (bool enabled)
		{
			/// Set checkmark on menu item
			Menu.SetChecked (EditorEventLoggingMenu, enabled);
			/// Saving editor state
			EditorPrefs.SetBool (EditorEventLoggingMenu, enabled);

			EditorEventLogging = enabled;
		}
	}
}
#endif