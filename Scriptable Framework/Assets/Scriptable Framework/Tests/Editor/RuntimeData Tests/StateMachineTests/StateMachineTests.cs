using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ScriptableFramework;

namespace ScriptableFramework.Tests
{
	public class StateMachineTests
	{
		public class UpdateStateForIndex
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
				AddToList (3);
			}

			public void AddToList (int instances)
			{
				gameObjects.Add (new GameObject ());
				for (int i = 1; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
					gameObjects[i].SetActive (false);
				}

				stateMachine.gameObjects = gameObjects;
			}

			[Test]
			public void UpdateStateSuccess ()
			{
				stateMachine.UpdateState (1);
				Assert.True (!gameObjects[0].activeSelf && gameObjects[1].activeSelf && !gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateActiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1);
				Assert.True (gameObjects[1].activeSelf);
			}

			[Test]
			public void UpdateStateInactiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1);
				Assert.False (gameObjects[0].activeSelf);
			}

			[Test]
			public void UpdateStateTwiceSuccess ()
			{
				stateMachine.UpdateState (1);
				stateMachine.UpdateState (2);
				Assert.AreEqual (stateMachine.selectionIndex, 2);
			}

			[Test]
			public void UpdateStateWithNegative ()
			{
				stateMachine.UpdateState (-1);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", -1, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithOutOfRangeIndex ()
			{
				stateMachine.UpdateState (5);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", 5, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithSameIndex ()
			{
				stateMachine.UpdateState (0);
				Assert.True (gameObjects[0].activeSelf && !gameObjects[1].activeSelf && !gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateWithNullList ()
			{
				stateMachine.gameObjects = null;

				stateMachine.UpdateState (2);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null list. State update failed.", stateMachine.name));
			}

			[Test]
			public void UpdateStateWithNullItemInList ()
			{
				gameObjects.Add (null);
				stateMachine.UpdateState (2);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null item in its list. State update failed.", stateMachine.name));
			}
		}

		public class UpdateStateForAll
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
				AddToList (3);
			}

			public void AddToList (int instances)
			{
				gameObjects.Add (new GameObject ());
				for (int i = 1; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
					gameObjects[i].SetActive (false);
				}

				stateMachine.gameObjects = gameObjects;
			}

			[Test]
			public void UpdateStateSuccess ()
			{
				stateMachine.UpdateState (true);
				Assert.True (gameObjects[0].activeSelf && gameObjects[1].activeSelf && gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateActiveGameObjectsSuccess ()
			{
				stateMachine.UpdateState (true);
				bool result = gameObjects[0].activeSelf && gameObjects[1].activeSelf && gameObjects[2].activeSelf;
				Assert.True (result);
			}

			[Test]
			public void UpdateStateInactiveGameObjectsSuccess ()
			{
				stateMachine.UpdateState (false);
				bool result = gameObjects[0].activeSelf && gameObjects[1].activeSelf && gameObjects[2].activeSelf;
				Assert.False (result);
			}

			[Test]
			public void UpdateStateWithNullList ()
			{
				stateMachine.gameObjects = null;

				stateMachine.UpdateState (true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null list. State update failed.", stateMachine.name));
			}

			[Test]
			public void UpdateStateWithNullItemInList ()
			{
				gameObjects.Add (null);
				stateMachine.UpdateState (true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null item in its list. State update failed.", stateMachine.name));
			}
		}

		public class UpdateStateForSingle
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
				AddToList (3);
			}

			public void AddToList (int instances)
			{
				gameObjects.Add (new GameObject ());
				for (int i = 1; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
					gameObjects[i].SetActive (false);
				}

				stateMachine.gameObjects = gameObjects;
			}

			[Test]
			public void UpdateStateSuccess ()
			{
				stateMachine.UpdateState (1, true);
				Assert.True (gameObjects[0].activeSelf && gameObjects[1].activeSelf && !gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateActiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1, true);
				Assert.True (gameObjects[1].activeSelf);
			}

			[Test]
			public void UpdateStateInactiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1);
				Assert.False (gameObjects[0].activeSelf);
			}

			[Test]
			public void UpdateStateTwiceSuccess ()
			{
				stateMachine.UpdateState (1, true);
				stateMachine.UpdateState (2, true);
				Assert.True (gameObjects[1].activeSelf && gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateToggle ()
			{
				stateMachine.UpdateState (1, true);
				stateMachine.UpdateState (1, false);
				Assert.False (gameObjects[1].activeSelf);
			}

			[Test]
			public void UpdateStateWithSameIndex ()
			{
				stateMachine.UpdateState (0, true);
				Assert.True (gameObjects[0].activeSelf && !gameObjects[1].activeSelf && !gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateWithNegative ()
			{
				stateMachine.UpdateState (-1, true);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", -1, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithOutOfRangeIndex ()
			{
				stateMachine.UpdateState (5, true);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", 5, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithNullList ()
			{
				stateMachine.gameObjects = null;
				stateMachine.UpdateState (2, true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null list. State update failed.", stateMachine.name));
			}

			[Test]
			public void UpdateStateWithNullItemInList ()
			{
				gameObjects.Add (null);
				stateMachine.UpdateState (2, true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null item in its list. State update failed.", stateMachine.name));
			}
		}

		public class UpdateStateForRange
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
				AddToList (3);
			}

			public void AddToList (int instances)
			{
				gameObjects.Add (new GameObject ());
				for (int i = 1; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
					gameObjects[i].SetActive (false);
				}

				stateMachine.gameObjects = gameObjects;
			}

			[Test]
			public void UpdateStateSuccess ()
			{
				stateMachine.UpdateState (1, 2, true);
				Assert.True (!gameObjects[0].activeSelf && gameObjects[1].activeSelf && gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateActiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1, 2, true);
				Assert.True (gameObjects[1].activeSelf && gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateInactiveGameObjectSuccess ()
			{
				stateMachine.UpdateState (1, 2, true);
				Assert.False (gameObjects[0].activeSelf);
			}

			[Test]
			public void UpdateStateTwiceSuccess ()
			{
				stateMachine.UpdateState (1, 2, true);
				stateMachine.UpdateState (0, 2, true);
				Assert.True (gameObjects[0].activeSelf && gameObjects[1].activeSelf);
			}

			[Test]
			public void UpdateStateMiddleFalse ()
			{
				stateMachine.UpdateState (1, 1, false);
				Assert.True (gameObjects[0].activeSelf && !gameObjects[1].activeSelf && gameObjects[2].activeSelf);
			}

			[Test]
			public void UpdateStateWithNegative ()
			{
				stateMachine.UpdateState (-1, true);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", -1, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithOutOfRangeIndex ()
			{
				stateMachine.UpdateState (5, true);
				LogAssert.Expect (LogType.Error, string.Format ("Provided index {0} to '{1}' but the list count is {2}", 5, stateMachine.name, gameObjects.Count));
			}

			[Test]
			public void UpdateStateWithNullList ()
			{
				stateMachine.gameObjects = null;
				stateMachine.UpdateState (2, true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null list. State update failed.", stateMachine.name));
			}

			[Test]
			public void UpdateStateWithNullItemInList ()
			{
				gameObjects.Add (null);
				stateMachine.UpdateState (2, true);
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null item in its list. State update failed.", stateMachine.name));
			}
		}

		public class ReapplyState
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine>();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList>();
				AddToList(3);
			}

			public void AddToList(int instances)
			{
				gameObjects.Add(new GameObject());
				for (int i = 1; i < instances; i++)
				{
					gameObjects.Add(new GameObject());
					gameObjects[i].SetActive(false);
				}

				stateMachine.gameObjects = gameObjects;
			}
		}

		public class ClearData
		{
			StateMachine stateMachine;
			GameObjectList gameObjects;

			[SetUp]
			public void CreateRuntimeObjects ()
			{
				stateMachine = ScriptableObject.CreateInstance<StateMachine> ();
				gameObjects = ScriptableObject.CreateInstance<GameObjectList> ();
			}

			public void AddToList (int instances)
			{
				for (int i = 0; i < instances; i++)
				{
					gameObjects.Add (new GameObject ());
					gameObjects[i].SetActive(false);
				}

				stateMachine.gameObjects = gameObjects;
			}

			[Test]
			public void ClearWithNullList ()
			{
				stateMachine.gameObjects = null;
				stateMachine.selectionIndex = -1;
				stateMachine.Clear ();
				Assert.AreEqual (stateMachine.selectionIndex, -1);
			}

			[Test]
			public void ClearWithEmptyList ()
			{
				stateMachine.selectionIndex = -1;
				stateMachine.Clear ();
				Assert.AreEqual (stateMachine.selectionIndex, -1);
			}

			[Test]
			public void ClearWithNullItemInList ()
			{
				stateMachine.selectionIndex = -1;
				AddToList (1);
				gameObjects.Add (null);
				stateMachine.gameObjects = gameObjects;
				stateMachine.Clear ();
				LogAssert.Expect (LogType.Error, string.Format ("'{0}' has a null item in its list. State update failed.", stateMachine.name));
			}

			[Test]
			public void ClearSuccess()
			{
				stateMachine.selectionIndex = 0;
				AddToList (2);
				stateMachine.UpdateState (1);
				stateMachine.Clear ();
				Assert.AreEqual (stateMachine.selectionIndex, 0);
			}

			[Test]
			public void ClearActiveGameObjectSuccess ()
			{
				stateMachine.selectionIndex = 0;
				AddToList (2);
				stateMachine.UpdateState (1);
				stateMachine.Clear ();
				Assert.True (gameObjects[0].activeSelf);
			}

			[Test]
			public void ClearInactiveGameObjectSuccess ()
			{
				stateMachine.selectionIndex = 0;
				AddToList (2);
				stateMachine.UpdateState (1);
				stateMachine.Clear ();
				Assert.False (gameObjects[1].activeSelf);
			}

			[Test]
			public void ClearWithAllActiveDefault ()
			{
				stateMachine.defaultState = DefaultState.AllActive;
				AddToList (2);
				stateMachine.UpdateState (false);
				stateMachine.Clear ();
				Assert.True (gameObjects[0].activeSelf && gameObjects[1].activeSelf);
			}

			[Test]
			public void ClearWithNoneActiveDefault ()
			{
				stateMachine.defaultState = DefaultState.NoneActive;
				AddToList (2);
				stateMachine.UpdateState (true);
				stateMachine.Clear ();
				Assert.False (gameObjects[0].activeSelf && gameObjects[1].activeSelf);
			}

			[Test]
			public void ResetSuccess ()
			{
				stateMachine.selectionIndex = 0;
				AddToList (2);
				stateMachine.UpdateState (1);
				stateMachine.Reset ();
				Assert.AreEqual (stateMachine.selectionIndex, 0);
			}
		}
	}
}
