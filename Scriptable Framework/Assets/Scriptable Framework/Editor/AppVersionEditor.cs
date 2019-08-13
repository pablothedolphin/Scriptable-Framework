using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableFramework.CustomEditors
{
	[CustomEditor (typeof (AppVersion))]
	public class AppVersionEditor : Editor
	{
		AppVersion instance;

		public void OnEnable ()
		{
			instance = (AppVersion)target;
			PlayerSettings.bundleVersion = instance;
		}

		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();

			if (GUI.changed)
			{
				PlayerSettings.bundleVersion = instance;
			}
		}
	}
}
