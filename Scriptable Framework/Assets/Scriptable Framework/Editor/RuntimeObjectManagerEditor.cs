using UnityEditor;

namespace ScriptableFramework.CustomEditors
{
    public static class RuntimeObjectManagerEditor
    {
        [MenuItem ("Scriptable Framework/Reset All RuntimeObjects")]
        public static void ResetAllMenuItem ()
        {
            RuntimeObjectManager.ResetObjectsOfType<RuntimeObject> ();
        }

		[MenuItem ("Scriptable Framework/Clear All RuntimeObjects")]
		public static void ClearAllMenuItem ()
		{
			RuntimeObjectManager.ClearObjectsOfType<RuntimeObject> ();
		}
	}
}