using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableFramework.CustomEditors
{
	[CustomPropertyDrawer (typeof (DataString))]
	public class DataStringEditor : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty (position, label, property);
			position = EditorGUI.PrefixLabel (position, label);

			EditorGUI.PropertyField (position, property.FindPropertyRelative ("text"), GUIContent.none);

			EditorGUI.EndProperty ();
		}
	}
}