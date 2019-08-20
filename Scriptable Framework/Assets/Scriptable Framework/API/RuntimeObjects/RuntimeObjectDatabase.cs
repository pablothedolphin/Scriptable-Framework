/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableFramework
{
	
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "RuntimeObjectDatabase")]
	public class RuntimeObjectDatabase : ScriptableObject
	{
		[SerializeField] private List<AppEventBase> events;
		[SerializeField] private List<StateMachineBase> stateMachines;
		[SerializeField] private List<ValueList> valueLists;
		[SerializeField] private List<RuntimeObject> runtimeObjects;

#if UNITY_EDITOR
		private void Awake ()
		{
			events = FindAssetsByType<AppEventBase> ();
			stateMachines = FindAssetsByType<StateMachineBase> ();
			runtimeObjects = FindAssetsByType<RuntimeObject> ();
		}

		private List<T> FindAssetsByType<T> () where T : UnityEngine.Object
		{
			List<T> assets = new List<T> ();
			string[] guids = AssetDatabase.FindAssets (string.Format ("t:{0}", typeof (T)));
			for (int i = 0; i < guids.Length; i++)
			{
				string assetPath = AssetDatabase.GUIDToAssetPath (guids[i]);
				T asset = AssetDatabase.LoadAssetAtPath<T> (assetPath);
				if (asset != null)
				{
					assets.Add (asset);
				}
			}
			return assets;
		}
#endif
		public void RegisterEvent<T> (T runtimeObject) where T : AppEventBase
		{
			if (!events.Contains (runtimeObject)) events.Add (runtimeObject);
			if (!runtimeObjects.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}

		public void RegisterStateMachine<T> (T runtimeObject) where T : StateMachineBase
		{
			if (!stateMachines.Contains (runtimeObject)) stateMachines.Add (runtimeObject);
			if (!runtimeObjects.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}

		public void RegisterValueList<T> (T runtimeObject) where T : AppEventBase
		{
			if (!events.Contains (runtimeObject)) events.Add (runtimeObject);
			if (!events.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}

		public void RegisterValueItem<T> (T runtimeObject) where T : AppEventBase
		{
			if (!events.Contains (runtimeObject)) events.Add (runtimeObject);
			if (!events.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}

		public void RegisterReferenceList<T> (T runtimeObject) where T : AppEventBase
		{
			if (!events.Contains (runtimeObject)) events.Add (runtimeObject);
			if (!events.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}

		public void RegisterReferenceItem<T> (T runtimeObject) where T : AppEventBase
		{
			if (!events.Contains (runtimeObject)) events.Add (runtimeObject);
			if (!events.Contains (runtimeObject)) runtimeObjects.Add (runtimeObject);
		}
	}

}*/