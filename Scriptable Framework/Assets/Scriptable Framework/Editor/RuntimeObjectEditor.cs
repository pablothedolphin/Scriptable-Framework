using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ScriptableFramework;

namespace ScriptableFramework.CustomEditors
{
    [CustomEditor (typeof (RuntimeObject), true)]
    public class RuntimeObjectEditor : EditorOverride
    {
        RuntimeObject runtimeObject;
        RuntimeObject[] objects;
        string error = "RuntimeObject found outside of resources. Please ensure this asset is stored under a 'Resources' folder.";

        public override void OnEnable ()
        {
            base.OnEnable ();
            runtimeObject = (RuntimeObject)target;

        }

        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            DisplayError ();
        }

        private void DisplayError ()
        {
			string path = AssetDatabase.GetAssetPath (runtimeObject);

			if (!string.IsNullOrEmpty (path))
			{
				if (!path.Contains ("Resources"))
				{
					EditorGUILayout.HelpBox (error, MessageType.Error, true);
					Debug.LogError (error);
				}
			}
		}
	}
}