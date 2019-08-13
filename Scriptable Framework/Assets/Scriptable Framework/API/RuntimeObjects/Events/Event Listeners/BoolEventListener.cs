using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A component which listens to a BoolEvent.
	/// In the inspector, drag and drop in the list of responses to set up which
	/// funtions will be called when the event is raised.
	/// Due to limitations in serializing generic types, public references for both events
	/// and responses need to be explicitly written when creating a BoolEventListener
	/// </summary>
	[AddComponentMenu ("Scriptable Framework/Event Listeners/Bool Event Listener")]
    public class BoolEventListener : AppEventListener<bool>
    {
        /// <summary>
		/// The event reference to be set in the inspector.
		/// </summary>
        public BoolEvent boolEvent;

		/// <summary>
		/// The response to be set in the inspector.
		/// </summary>
        public BoolResponse boolResponse;

		/// <summary>
		/// Initialisation of the component must happen on awake so that the event and response 
		/// can be set before the inherited OnEnable function
		/// </summary>
		private void Awake ()
        {
            Event = boolEvent;
            Response = boolResponse;
        }

		/// <summary>
		/// After asigning the public event and response, use this to apply those references internally.
		/// </summary>
        public override void SetInternalEventAndResponse ()
        {
            Event = boolEvent;
            Response = boolResponse;
        }
    }
}