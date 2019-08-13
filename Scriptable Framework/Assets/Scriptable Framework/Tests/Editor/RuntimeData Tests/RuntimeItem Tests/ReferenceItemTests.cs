using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ReferenceItemTests
    {
        public class ClearData
        {
            GameObjectReference gameObjectReference;

            [SetUp]
            public void CreateGameObjectReference ()
            {
                gameObjectReference = ScriptableObject.CreateInstance<GameObjectReference> ();
            }

            [Test]
            public void Reset ()
            {
                gameObjectReference.reference = new GameObject ();

                gameObjectReference.Reset ();

                Assert.AreEqual (gameObjectReference.reference, null);
            }

            [Test]
            public void Clear ()
            {
                gameObjectReference.reference = new GameObject ();

                gameObjectReference.Clear ();

                Assert.AreEqual (gameObjectReference.reference, null);
            }
        }
    }
}
