using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableFramework
{
	/// <summary>
	/// A component which listens to an AppEvent.
	/// In the inspector, drag and drop in the list of responses to set up which
	/// funtions will be called when the event is raised.
	/// </summary>
	[DefaultExecutionOrder (-1000)]
	[AddComponentMenu ("Scriptable Framework/Event Listeners/App Event Listener")]
    public class AppEventListener : AppEventListenerBase
    {
        /// <summary>
        /// The event that is being listenned to.
        /// </summary>
        public AppEvent Event;

        /// <summary>
        /// The UnityEvent that can have delegates assigned to in the inspector. These delegates will
        /// be invoked when the event is raised.
        /// </summary>
        public UnityEvent Response;

        // Register this listener when the component or GameObject becomes active.
        private void OnEnable ()
        {
            RegisterSelf ();
        }

        // Unregister this listener when this component turns off, this GameObject turns off or
        // when the scene changes.
        private void OnDisable ()
        {
            UnregisterSelf ();
        }

        /// <summary>
        /// If <c>Event</c> is not null, register this object to it.
        /// </summary>
        /// <returns>Returns whether the registration was successful or not.</returns>
        public override bool RegisterSelf ()
        {
            if (Event != null) return Event.RegisterListener (this);
            else return false;
        }

        /// <summary>
        /// If <c>Event</c> is not null, unregister this object from it.
        /// </summary>
        /// <returns>Returns whether the unregistration was successful or not.</returns>
        public override bool UnregisterSelf ()
        {
            if (Event != null) return Event.UnregisterListener (this);
            else return false;
        }        

        /// <summary>
        /// Invokes all delegates asigned to this response in the inspector.
        /// </summary>
        /// <returns>Returns whether the event response was successful or not.</returns>
        public override bool OnEventRaised ()
        {
            if (Response == null)
            {
                Debug.LogWarning (string.Format ("The response on '{0}' is currently null. Therefore, no response will be triggered.", name));
                return false;
            }

            if (Response.GetPersistentEventCount () == 0)
            {
                Debug.LogWarning (string.Format ("The response on '{0}' was triggered but it has no delegates! Please assign functions in the inspector to be triggered.", name));
            }

			Response.Invoke ();
			return true;
		}
    }

    /// <summary>
    /// A generic component which listens to an AppEvent of the same type.
    /// Inherit from this class to create your own AppEventListener sub class.
    /// In the inspector, drag and drop in the list of responses to set up which
    /// funtions will be called when the event is raised.
    /// </summary>
    /// <typeparam name="T">The type for this listener to receive from the event when it
    /// is raised.</typeparam>
    public abstract class AppEventListener<T> : AppEventListenerBase
    {
        /// <summary>
        /// A default input value for OnEventRaised ().
        /// </summary>
        public T valueForManualTrigger;

        /// <summary>
        /// The generic event that is being listened to.
        /// </summary>
        protected AppEvent<T> Event;

		/// <summary>
		/// The generic UnityEvent that can have delegates assigned to in the inspector. These delegates will
		/// be invoked when the event is raised and have an object of type T passed to them from the event.
		/// </summary>
		protected UnityEvent<T> Response;

        // Register this listener when the component or GameObject becomes active.
        private void OnEnable ()
        {
           RegisterSelf ();
        }
        
        // Unregister this listener when this component turns off, this GameObject turns off or
        // when the scene changes.
        private void OnDisable ()
        {
            UnregisterSelf ();
        }

        /// <summary>
        /// If <c>Event</c> is not null, register this object to it.
        /// </summary>
        /// <returns>Returns whether the registration was successful or not.</returns>
        public override bool RegisterSelf ()
        {
            if (Event != null) return Event.RegisterListener (this);
            else return false;
        }

        /// <summary>
        /// If <c>Event</c> is not null, unregister this object from it.
        /// </summary>
        /// <returns>Returns whether the unregistration was successful or not.</returns>
        public override bool UnregisterSelf ()
        {
            if (Event != null) return Event.UnregisterListener (this);
            else return false;
        }

        /// <summary>
        /// Invokes all delegates asigned to this response in the inspector using a default input.
        /// </summary>
        /// <returns>Returns whether the event response was successful or not.</returns>
        public override bool OnEventRaised ()
        {
            if (valueForManualTrigger == null)
                return OnEventRaised (Activator.CreateInstance<T> ());
            else
                return OnEventRaised (valueForManualTrigger);
        }

        /// <summary>
        /// Invokes all delegates asigned to this response in the inspector using an input provided by the event.
        /// </summary>
        /// <returns>Returns whether the event response was successful or not.</returns>
        public bool OnEventRaised (T value)
        {
            if (Response == null)
            {
                Debug.LogWarning (string.Format ("The response on '{0}' is currently null. Therefore, no response will be triggered.", name));
                return false;
            }

            if (Response.GetPersistentEventCount () == 0)
            {
                Debug.LogWarning (string.Format ("The response on '{0}' was triggered but it has no delegates! Please assign functions in the inspector to be triggered.", name));
            }

			Response.Invoke (value);
			return true;
        }

        public abstract void SetInternalEventAndResponse ();
    }

    /// <summary>
    /// Base class for all AppEventListener components.
    /// </summary>
    public abstract class AppEventListenerBase : MonoBehaviour
    {
        /// <summary>
        /// Invokes all delegates asigned to this response in the inspector.
        /// </summary>
        /// <returns>Returns whether the event response was successful or not.</returns>
        public abstract bool OnEventRaised ();

        /// <summary>
        /// If <c>Event</c> is not null, register this object to it.
        /// </summary>
        /// <returns>Returns whether the registration was successful or not.</returns>
        public abstract bool RegisterSelf ();

        /// <summary>
        /// If <c>Event</c> is not null, unregister this object from it.
        /// </summary>
        /// <returns>Returns whether the unregistration was successful or not.</returns>
        public abstract bool UnregisterSelf ();
    }
}