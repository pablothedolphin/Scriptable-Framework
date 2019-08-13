using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine.TestTools;

namespace ScriptableFramework.Tests
{
    public class AppEventListenerGenericTests
    {
        public class RegisterSelf
        {
            IntEvent intEvent;
            IntEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
                listener = new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void RegisterSelfWithEvent ()
            {
                listener.intEvent = intEvent;
				listener.SetInternalEventAndResponse ();

                Assert.True (listener.RegisterSelf ());
            }

            [Test]
            public void RegisterSelfWithEventTwice ()
            {
				listener.intEvent = intEvent;
				listener.SetInternalEventAndResponse ();

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
            IntEvent intEvent;
            IntEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
                listener = new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void UnregisterSelfWithEvent ()
            {
				listener.intEvent = intEvent;
				listener.SetInternalEventAndResponse ();

				listener.RegisterSelf ();

                Assert.True (listener.UnregisterSelf ());
            }

            [Test]
            public void UnregisterSelfWithEventTwice ()
            {
				listener.intEvent = intEvent;
				listener.SetInternalEventAndResponse ();

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
            IntEvent intEvent;
            IntEventListener listener;

            [SetUp]
            public void CreateAppEventListenerAndAppEvent ()
            {
                intEvent = ScriptableObject.CreateInstance<IntEvent> ();
                listener = new GameObject ().AddComponent<IntEventListener> ();
            }

            [Test]
            public void RespondToEventWithNullResponse ()
            {
                Assert.False (listener.OnEventRaised (10));
            }

            [Test]
            public void RespondToEventWithResponseWithNoDelegates ()
            {
                listener.intResponse = new IntResponse ();
				listener.SetInternalEventAndResponse ();

				Assert.True (listener.OnEventRaised (10));
            }

            [Test]
            public void RespondToEvent ()
            {
                listener.intEvent = intEvent;
				listener.intResponse = new IntResponse ();
				listener.SetInternalEventAndResponse ();

				ListenerResponder responder = ScriptableObject.CreateInstance<ListenerResponder> ();

                listener.intResponse.AddListener (responder.FunctionToDelegate);

                listener.OnEventRaised (10);

                Assert.AreEqual (10, responder.responseCount);
            }

            [Test]
            public void RespondToEventWithTwoDelegates ()
            {
				listener.intEvent = intEvent;
				listener.intResponse = new IntResponse ();
				listener.SetInternalEventAndResponse ();

				ListenerResponder responder = ScriptableObject.CreateInstance<ListenerResponder> ();

                listener.intResponse.AddListener (responder.FunctionToDelegate);
                listener.intResponse.AddListener (responder.FunctionToDelegate);

                listener.OnEventRaised (10);

                Assert.AreEqual (20, responder.responseCount);
            }

            [Test]
            public void RespondToEventWithNoParameter ()
            {
				listener.intEvent = intEvent;
				listener.intResponse = new IntResponse ();
				listener.SetInternalEventAndResponse ();

				ListenerResponder responder = ScriptableObject.CreateInstance<ListenerResponder> ();

                listener.intResponse.AddListener (responder.FunctionToDelegate);

                listener.OnEventRaised ();

                Assert.AreEqual (0, responder.responseCount);
            }
        }
    }
}
