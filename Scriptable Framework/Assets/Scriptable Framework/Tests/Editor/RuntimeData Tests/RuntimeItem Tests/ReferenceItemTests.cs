using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ReferenceItemTests
    {
		public class ClearWithForAssetReferencingOnly
		{
			GameObjectReference gameObjectReference;
			GameObject newObject;

			[SetUp]
			public void CreateGameObjectList ()
			{
				gameObjectReference = ScriptableObject.CreateInstance<GameObjectReference> ();
				newObject = new GameObject ();
				gameObjectReference.reference = newObject;
				gameObjectReference.ForAssetReferencingOnly = true;
			}

			[Test]
			public void Reset ()
			{
				gameObjectReference.Reset ();
				Assert.AreSame (gameObjectReference.reference, newObject);
			}

			[Test]
			public void Clear ()
			{
				gameObjectReference.Clear ();
				Assert.AreSame (gameObjectReference.reference, newObject);
			}
		}

		public class ClearData
        {
            GameObjectReference gameObjectReference;

            [SetUp]
            public void CreateGameObjectReference ()
            {
                gameObjectReference = ScriptableObject.CreateInstance<GameObjectReference> ();
                gameObjectReference.reference = new GameObject ();
			}

			[Test]
            public void Reset ()
            {
                gameObjectReference.Reset ();
                Assert.AreSame (gameObjectReference.reference, null);
            }

            [Test]
            public void Clear ()
            {
                gameObjectReference.Clear ();
                Assert.AreSame (gameObjectReference.reference, null);
            }
        }
    }
}
