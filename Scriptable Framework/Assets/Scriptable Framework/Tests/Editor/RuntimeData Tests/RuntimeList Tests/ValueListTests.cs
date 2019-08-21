using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ValueListTests
    {
        public class ClearData
        {
            Vector3List vector3List;

            [SetUp]
            public void CreateGameObjectList ()
            {
                vector3List = ScriptableObject.CreateInstance<Vector3List> ();
            }

            [Test]
            public void ResetWithDefault ()
            {
                vector3List.customDefaultValues = new List<Vector3> ();

                for (int i = 0; i < 10; i++)
                {
                    vector3List.customDefaultValues.Add (Vector3.zero);
                }

                vector3List.UseCustomDefault = true;

                vector3List.Reset ();

                Assert.AreEqual (vector3List.Count, 10);
            }

            [Test]
            public void ResetWithoutDefault ()
            {
                vector3List.customDefaultValues = new List<Vector3> ();

                for (int i = 0; i < 10; i++)
                {
                    vector3List.customDefaultValues.Add (Vector3.zero);
                }

                vector3List.Reset ();

                Assert.AreEqual (vector3List.Count, 0);
            }

            [Test]
            public void Clear ()
            {
                for (int i = 0; i < 10; i++)
                {
                    vector3List.Add (Vector3.zero);
                }

                vector3List.Clear ();

                Assert.AreEqual (vector3List.Count, 0);
            }
        }
    }
}
