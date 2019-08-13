using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ScriptableFramework.CustomEditors
{
    [CustomEditor (typeof (AppEventBase), true)]
    public class AppEventEditor : RuntimeObjectEditor
    {
        AppEventBase appEvent;

        public override void OnEnable ()
        {
            base.OnEnable ();
            appEvent = (AppEventBase)target;
        }

        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();
            if (GUILayout.Button ("Raise this event"))
            {
                appEvent.RaiseEvent ();
            }
        }
    }
}