using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ReferenceListTests
    {
        public class ClearData
        {
            GameObjectList gameObjectList;

            [SetUp]
            public void CreateGameObjectList ()
            {
                gameObjectList = ScriptableObject.CreateInstance<GameObjectList> ();
            }

            [Test]
            public void Reset ()
            {
                gameObjectList.Add (new GameObject ());

                gameObjectList.Reset ();

                Assert.AreEqual (gameObjectList.Count, 0);
            }

            [Test]
            public void Clear ()
            {
                gameObjectList.Add (new GameObject ());

                gameObjectList.Clear ();

                Assert.AreEqual (gameObjectList.Count, 0);
            }
        }
    }
}
