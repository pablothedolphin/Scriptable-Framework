using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class AppEventGenericTests
    {
		public class RegisterListener
        {
            IntEvent intEvent;

            [SetUp]
            public void CreateIntEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
            }

            public IntEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void RegersterOneListener ()
            {
                Assert.True (intEvent.RegisterListener (CreateListener ()));
            }

            [Test]
            public void RegersterTwoDifferentListeners ()
            {
                intEvent.RegisterListener (CreateListener ());
                intEvent.RegisterListener (CreateListener ());

                Assert.AreEqual (intEvent.ListenerCount, 2);
            }

            [Test]
            public void RegersterTheSameListenerTwice ()
            {
                IntEventListener listener = CreateListener ();

                intEvent.RegisterListener (listener);
                intEvent.RegisterListener (listener);

                Assert.AreEqual (intEvent.ListenerCount, 1);
            }

            [Test]
            public void RegersterNullListener ()
            {
                Assert.False (intEvent.RegisterListener (null));
            }
        }

        public class UnregisterListener
        {
            IntEvent intEvent;

            [SetUp]
            public void CreateIntEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
            }

            public IntEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void UnregersterOneListener ()
            {
                IntEventListener listener = CreateListener ();

                intEvent.RegisterListener (listener);

                Assert.True (intEvent.UnregisterListener (listener));
            }

            [Test]
            public void UnregersterTwoDifferentListeners ()
            {
                IntEventListener listener1 = CreateListener ();
                IntEventListener listener2 = CreateListener ();

                intEvent.RegisterListener (listener1);
                intEvent.RegisterListener (listener2);

                intEvent.UnregisterListener (listener1);
                intEvent.UnregisterListener (listener2);

                Assert.AreEqual (intEvent.ListenerCount, 0);
            }

            [Test]
            public void UnregersterTheSameListenerTwice ()
            {
                IntEventListener listener = CreateListener ();

                intEvent.RegisterListener (listener);
                intEvent.RegisterListener (CreateListener ());

                intEvent.UnregisterListener (listener);
                intEvent.UnregisterListener (listener);

                Assert.AreEqual (intEvent.ListenerCount, 1);
            }

            [Test]
            public void UnregersterNullListener ()
            {
                intEvent.RegisterListener (CreateListener ());

                Assert.False (intEvent.UnregisterListener (null));
            }
        }

        public class RaiseEvent
        {
            IntEvent intEvent;

            [SetUp]
            public void CreateIntEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
            }

            public IntEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void RaiseEventWithZeroListeners ()
            {
                Assert.False (intEvent.RaiseEvent (5));
            }

            [Test]
            public void RaiseEventWithListener ()
            {
                intEvent.RegisterListener (CreateListener ());

                Assert.True (intEvent.RaiseEvent (5));
            }

            [Test]
            public void RaiseEventWithNullListener ()
            {
                intEvent.RegisterListener (null);

                Assert.False (intEvent.RaiseEvent (5));
            }

            [Test]
            public void RaiseEventWithListenerAndDefaultParameter ()
            {
                intEvent.RegisterListener (CreateListener ());

                Assert.True (intEvent.RaiseEvent ());
            }

            
        }

        public class ClearData
        {
            IntEvent intEvent;

            [SetUp]
            public void CreateIntEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
            }

            public IntEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void Clear ()
            {
                intEvent.RegisterListener (CreateListener ());

                intEvent.Clear ();

                Assert.AreEqual (intEvent.ListenerCount, 0);
            }

            [Test]
            public void Reset ()
            {
                intEvent.RegisterListener (CreateListener ());

                intEvent.Reset ();

                Assert.AreEqual (intEvent.ListenerCount, 0);
            }
        }
    }
}
