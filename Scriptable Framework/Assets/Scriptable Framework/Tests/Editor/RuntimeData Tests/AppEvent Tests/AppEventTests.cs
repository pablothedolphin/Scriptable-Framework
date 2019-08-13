using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class AppEventTests
    {
        public class RegisterListener
        {
            AppEvent appEvent;

            [SetUp]
            public void CreateAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
            }

            public AppEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void RegersterOneListener ()
            {
                Assert.True (appEvent.RegisterListener (CreateListener ()));
            }

            [Test]
            public void RegersterTwoDifferentListeners ()
            {
                appEvent.RegisterListener (CreateListener ());
                appEvent.RegisterListener (CreateListener ());

                Assert.AreEqual (appEvent.ListenerCount, 2);
            }

            [Test]
            public void RegersterTheSameListenerTwice ()
            {
                AppEventListener listener = CreateListener ();

                appEvent.RegisterListener (listener);
                appEvent.RegisterListener (listener);

                Assert.AreEqual (appEvent.ListenerCount, 1);
            }

            [Test]
            public void RegersterNullListener ()
            {
                Assert.False (appEvent.RegisterListener (null));
            }
        }

        public class UnregisterListener
        {
            AppEvent appEvent;

            [SetUp]
            public void CreateAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
            }

            public AppEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void UnregersterOneListener ()
            {
                AppEventListener listener = CreateListener ();

                appEvent.RegisterListener (listener);

                Assert.True (appEvent.UnregisterListener (listener));
            }

            [Test]
            public void UnregersterTwoDifferentListeners ()
            {
                AppEventListener listener1 = CreateListener ();
                AppEventListener listener2 = CreateListener ();

                appEvent.RegisterListener (listener1);
                appEvent.RegisterListener (listener2);

                appEvent.UnregisterListener (listener1);
                appEvent.UnregisterListener (listener2);

                Assert.AreEqual (appEvent.ListenerCount, 0);
            }

            [Test]
            public void UnregersterTheSameListenerTwice ()
            {
                AppEventListener listener = CreateListener ();

                appEvent.RegisterListener (listener);
                appEvent.RegisterListener (CreateListener ());

                appEvent.UnregisterListener (listener);
                appEvent.UnregisterListener (listener);

                Assert.AreEqual (appEvent.ListenerCount, 1);
            }

            [Test]
            public void UnregersterNullListener ()
            {
                appEvent.RegisterListener (CreateListener ());

                Assert.False (appEvent.UnregisterListener (null));
            }
        }

        public class RaiseEvent
        {
            AppEvent appEvent;

            [SetUp]
            public void CreateAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
            }

            public AppEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void RaiseEventWithZeroListeners ()
            {
                Assert.False (appEvent.RaiseEvent ());
            }

            [Test]
            public void RaiseEventWithListener ()
            {
                appEvent.RegisterListener (CreateListener ());

                Assert.True (appEvent.RaiseEvent ());
            }

            [Test]
            public void RaiseEventWithNullListener ()
            {
                appEvent.RegisterListener (null);

                Assert.False (appEvent.RaiseEvent ());
            }
        }

        public class ClearData
        {
            AppEvent appEvent;

            [SetUp]
            public void CreateAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
            }

            public AppEventListener CreateListener ()
            {
                return new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void Clear ()
            {
                appEvent.RegisterListener (CreateListener ());

                appEvent.Clear ();

                Assert.AreEqual (appEvent.ListenerCount, 0);
            }

            [Test]
            public void Reset ()
            {
                appEvent.RegisterListener (CreateListener ());

                appEvent.Reset ();

                Assert.AreEqual (appEvent.ListenerCount, 0);
            }
        }        
    }
}
