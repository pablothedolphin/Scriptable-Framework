using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
	public class StateToggleTests
	{
		public class UpdateStateMachine
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
				AddToList (3);
				stateMachine.gameObjects = gameObjects;
			}

			public void AddToList (int instances)
			{
				for (int i = 0; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
				}
			}
		}

		public class RespondToStateMachineChange
		{

		}
	}
}