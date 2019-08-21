using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class ValueItemTests
    {
        public class ClearData
        {
            FloatValue floatValue;

            [SetUp]
            public void CreateFloatValue ()
            {
                floatValue = ScriptableObject.CreateInstance<FloatValue> ();
            }

            [Test]
            public void ResetWithDefault ()
            {
                floatValue.customDefaultValue = 12;
                floatValue.UseCustomDefault = true;

                floatValue.Reset ();

                Assert.AreEqual (floatValue.value, floatValue.customDefaultValue);
            }

            [Test]
            public void ResetWithoutDefault ()
            {
                floatValue.customDefaultValue = 12;

                floatValue.Reset ();

                Assert.AreEqual (floatValue.value, 0.0f);
            }

            [Test]
            public void Clear ()
            {
                floatValue.value = 12f;

                floatValue.Clear ();

                Assert.AreEqual (floatValue.value, 0.0f);
            }
        }
    }
}
