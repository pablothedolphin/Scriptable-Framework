using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class AppEventListenerTests
    {
        public class RegisterSelf
        {
            AppEvent appEvent;
            AppEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
                listener = new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void RegisterSelfWithEvent ()
            {
                listener.Event = appEvent;

                Assert.True (listener.RegisterSelf ());
            }

            [Test]
            public void RegisterSelfWithEventTwice ()
            {
                listener.Event = appEvent;

                listener.RegisterSelf ();

                Assert.False (listener.RegisterSelf ());
            }

            [Test]
            public void RegisterSelfWithNullEvent ()
            {
                Assert.False (listener.RegisterSelf ());
            }
        }

        public class UnregisterSelf
        {
            AppEvent appEvent;
            AppEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
                listener = new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void UnregisterSelfWithEvent ()
            {
                listener.Event = appEvent;

                listener.RegisterSelf ();

                Assert.True (listener.UnregisterSelf ());
            }

            [Test]
            public void UnregisterSelfWithEventTwice ()
            {
                listener.Event = appEvent;

                listener.RegisterSelf ();
                listener.UnregisterSelf ();

                Assert.False (listener.UnregisterSelf ());
            }

            [Test]
            public void UnregisterSelfWithNullEvent ()
            {
                Assert.False (listener.UnregisterSelf ());
            }
        }

        public class OnEventRaised
        {
            AppEvent appEvent;
            AppEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                appEvent = ScriptableObject.CreateInstance<AppEvent> ();
                listener = new GameObject ().AddComponent<AppEventListener> ();
            }

            [Test]
            public void RespondToEventWithNullResponse ()
            {
                Assert.False (listener.OnEventRaised ());
            }

            [Test]
            public void RespondToEventWithResponseWithNoDelegates ()
            {
                listener.Response = new UnityEvent ();

                Assert.True (listener.OnEventRaised ());
            }

            [Test]
            public void RespondToEvent ()
            {
                listener.Event = appEvent;
                listener.Response = new UnityEvent ();
                ListenerResponder responder = ScriptableObject.CreateInstance<ListenerResponder> ();

                listener.Response.AddListener (responder.FunctionToDelegate);

                listener.OnEventRaised ();

                Assert.AreEqual (1, responder.responseCount);
            }

            [Test]
            public void RespondToEventWithTwoDelegates ()
            {
                listener.Event = appEvent;
                listener.Response = new UnityEvent ();
                ListenerResponder responder = ScriptableObject.CreateInstance<ListenerResponder> ();

                listener.Response.AddListener (responder.FunctionToDelegate);
                listener.Response.AddListener (responder.FunctionToDelegate);

                listener.OnEventRaised ();

                Assert.AreEqual (2, responder.responseCount);
            }
        }
    }
}
