using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A component which listens to a BoundsEvent.
	/// In the inspector, drag and drop in the list of responses to set up which
	/// funtions will be called when the event is raised.
	/// Due to limitations in serializing generic types, public references for both events
	/// and responses need to be explicitly written when creating a BoundsEventListener
	/// </summary>
	[DefaultExecutionOrder (-1000)]
	[AddComponentMenu ("Scriptable Framework/Event Listeners/Bounds Event Listener")]
    public class BoundsEventListener : AppEventListener<Bounds>
    {
        /// <summary>
		/// The event reference to be set in the inspector.
		/// </summary>
        public BoundsEvent boundsEvent;

		/// <summary>
		/// The response to be set in the inspector.
		/// </summary>
        public BoundsResponse boundsResponse;

		/// <summary>
		/// Initialisation of the component must happen on awake so that the event and response 
		/// can be set before the inherited OnEnable function
		/// </summary>
		private void Awake ()
        {
            Event = boundsEvent;
            Response = boundsResponse;
        }

		/// <summary>
		/// After asigning the public event and response, use this to apply those references internally.
		/// </summary>
        public override void SetInternalEventAndResponse ()
        {
            Event = boundsEvent;
            Response = boundsResponse;
        }
    }
}