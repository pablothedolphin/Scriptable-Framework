using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A component which listens to a FloatEvent.
	/// In the inspector, drag and drop in the list of responses to set up which
	/// funtions will be called when the event is raised.
	/// Due to limitations in serializing generic types, public references for both events
	/// and responses need to be explicitly written when creating a FloatEventListener
	/// </summary>
	[DefaultExecutionOrder (-1000)]
	[AddComponentMenu ("Scriptable Framework/Event Listeners/Float Event Listener")]
    public class FloatEventListener : AppEventListener<float>
    {
		/// <summary>
		/// The event reference to be set in the inspector.
		/// </summary>
		public FloatEvent floatEvent;

		/// <summary>
		/// The response to be set in the inspector.
		/// </summary>
		public FloatResponse floatResponse;

		/// <summary>
		/// Initialisation of the component must happen on awake so that the event and response 
		/// can be set before the inherited OnEnable function
		/// </summary>
		private void Awake ()
        {
            SetInternalEventAndResponse ();
        }

		/// <summary>
		/// After asigning the public event and response, use this to apply those references internally.
		/// </summary>
		public override void SetInternalEventAndResponse ()
        {
            Event = floatEvent;
            Response = floatResponse;
        }
    }
}