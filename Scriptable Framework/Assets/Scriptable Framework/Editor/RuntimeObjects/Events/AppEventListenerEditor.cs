using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableFramework.CustomEditors
{
    [CustomEditor (typeof (AppEventListenerBase), true)]
    public class AppEventListenerEditor : Editor
    {

        AppEventListenerBase listener;

        public void OnEnable ()
        {
            listener = (AppEventListenerBase)target;
        }

        public override void OnInspectorGUI ()
        {
            DrawDefaultInspector ();
            if (GUILayout.Button ("Trigger this response"))
            {
                listener.OnEventRaised ();
            }
        }
    }
}
