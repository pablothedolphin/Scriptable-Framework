using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ReferenceListTests
    {
		public class ClearWithForAssetReferencingOnly
		{
			GameObjectList gameObjectList;

			[SetUp]
			public void CreateGameObjectList ()
			{
				gameObjectList = ScriptableObject.CreateInstance<GameObjectList> ();
				gameObjectList.Add (new GameObject ());
				gameObjectList.ForAssetReferencingOnly = true;
			}

			[Test]
			public void Reset ()
			{
				gameObjectList.Reset ();
				Assert.AreEqual (gameObjectList.Count, 1);
			}

			[Test]
			public void Clear ()
			{
				gameObjectList.Clear ();
				Assert.AreEqual (gameObjectList.Count, 1);
			}
		}

        public class ClearData
        {
            GameObjectList gameObjectList;

            [SetUp]
            public void CreateGameObjectList ()
            {
                gameObjectList = ScriptableObject.CreateInstance<GameObjectList> ();
				gameObjectList.Add (new GameObject ());
			}

			[Test]
            public void Reset ()
            {
                gameObjectList.Reset ();
                Assert.AreEqual (gameObjectList.Count, 0);
            }

            [Test]
            public void Clear ()
            {
                gameObjectList.Clear ();
                Assert.AreEqual (gameObjectList.Count, 0);
            }
        }
    }
}
