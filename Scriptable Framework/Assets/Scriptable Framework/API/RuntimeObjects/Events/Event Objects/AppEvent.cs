using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScriptableFramework
{
    /// <summary>
    /// An RuntimeObject which acts as an event handle.
    /// </summary>
    [CreateAssetMenu (menuName = "Runtime Objects/Events/App Event")]
    public class AppEvent : AppEventBase
    {
        /// <summary>
        /// A list of listeners that will have their reponses triggered when this event is raised.
        /// </summary>
        [Space]
        [SerializeField] private List<AppEventListener> listeners = new List<AppEventListener> ();

        /// <summary>
        /// Returns the count of all listeners on this event.
        /// </summary>
        public new int ListenerCount => listeners.Count;

		/// <summary>
		/// Invoke every function callback that is delegated to every event listener that is listenning 
		/// to this event.
		/// </summary>
		/// <param name="fileName">Name of the .cs file the event was raised from (assigned automatically)</param>
		/// <param name="methodName">Name of the method the event was raised from (assigned automatically)</param>
		/// <param name="callerLineNumber">Line number the event was raised from (assigned automatically)</param>
		/// <returns>Returns whether or not the event was raised successfully.</returns>
		public override bool RaiseEvent ([CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
#if UNITY_EDITOR
			if (ScriptableFrameworkSettings.EditorEventLogging)
#endif
				Debug.Log (string.Format ("[EVENT] '{0}' was raised from {1}.{2}() at line {3}", name, Path.GetFileNameWithoutExtension (fileName),  methodName, callerLineNumber));

            if (listeners.Count == 0)
            {
                Debug.LogWarning (string.Format ("[EVENT] '{0}' was raised but has no listeners", name));
                return false;
            }

			try
			{
				for (int i = listeners.Count - 1; i >= 0; i--)
				{
					listeners[i].OnEventRaised ();
				}
				return true;
			}
			catch (Exception e)
			{
				Debug.LogError (string.Format ("[EVENT] '{0}' threw '{1}'\n{2}", name, e.Message, e.StackTrace));
				return false;
			}
		}

        /// <summary>
        /// If not already registered, add an app event listener to this event's list of listeners.
        /// </summary>
        /// <param name="listener">An instance of a listener component in the current scene.</param>
        /// <returns>Returns whether or not the listener was registered successfully.</returns>
        public bool RegisterListener (AppEventListener listener)
        {
            if (listener == null) return false;

            if (!listeners.Contains (listener))
            {
                listeners.Add (listener);
                return true;
            }

			return false;
        }

        /// <summary>
        /// If already registered, remove an app event listener from this event's list of listeners.
        /// </summary>
        /// <param name="listener">An instance of a listener component in the current scene.</param>
        /// <returns>Returns whether or not the listener was unregistered successfully.</returns>
        public bool UnregisterListener (AppEventListener listener)
        {
            if (listener == null) return false;

            if (listeners.Contains (listener))
            {
                return listeners.Remove (listener);
            }

			return false;
        }

        /// <summary>
        /// Clear this event of all it's listeners
        /// </summary>
        public override void Clear () => listeners.Clear ();

        /// <summary>
        /// Calls Clear ()
        /// </summary>
        public override void Reset () => Clear ();
    }

    /// <summary>
    /// An abstract generic RuntimeObject which acts as an event handle.
    /// Inherit from this class to create your own event.
    /// Give your class the CreateAssetMenu attribute to serialize an instance of it.
    /// </summary>
    /// <typeparam name="T">The type of the object that will will be passed when raising an event</typeparam>
    public abstract class AppEvent<T> : AppEventBase
    {
        /// <summary>
        /// When testing your generic event in the editor, this value will be passed to each listener.
        /// </summary>
		[Space]
        public T valueForManualTrigger;

        #if UNITY_EDITOR
        /// <summary>
        /// Display a list of strings in editor which are the names of all current listeners.
        /// This is a workaround for Unity not serializing the listener list for viewing in the inspector.
        /// </summary>
        [Space]
        [SerializeField] private List<string> listenerNames = new List<string> ();
        #endif

        /// <summary>
        /// A list of listeners that will have their reponses triggered when this event is raised.
        /// </summary>
        private List<AppEventListener<T>> listeners = new List<AppEventListener<T>> ();

        /// <summary>
        /// Returns the count of all listeners on this event.
        /// </summary>
        public new int ListenerCount => listeners.Count;

		/// <summary>
		/// Invoke every function callback that is delegated to every event listener that is listenning 
		/// to this event using <c>valueForManualTrigger</c> or an empty instance of T depending on.
		/// </summary>
		/// <param name="fileName">Name of the .cs file the event was raised from (assigned automatically)</param>
		/// <param name="methodName">Name of the method the event was raised from (assigned automatically)</param>
		/// <param name="callerLineNumber">Line number the event was raised from (assigned automatically)</param>
		/// <returns>Returns whether or not the event was raised successfully.</returns>
		public override bool RaiseEvent ([CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            if (valueForManualTrigger == null)
                return RaiseEvent (Activator.CreateInstance<T> (), fileName, methodName, callerLineNumber);
            else
                return RaiseEvent (valueForManualTrigger, fileName, methodName, callerLineNumber);
        }

		/// <summary>
		/// Invoke every function callback that is delegated to every event listener that is listenning 
		/// to this event.
		/// If there are no listeners, a warning will be given.
		/// </summary>
		/// <param name="value">The value that will be passed to all current listeners which will in
		/// turn pass the value to each delegated function in each listener.</param>
		/// <param name="fileName">Name of the .cs file the event was raised from (assigned automatically)</param>
		/// <param name="methodName">Name of the method the event was raised from (assigned automatically)</param>
		/// <param name="callerLineNumber">Line number the event was raised from (assigned automatically)</param>
		/// <returns>Returns whether or not the event was raised successfully.</returns>
		public bool RaiseEvent (T value, [CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
#if UNITY_EDITOR
			if (ScriptableFrameworkSettings.EditorEventLogging)
#endif
				Debug.Log (string.Format ("[EVENT] '{0}' was raised from {1}.{2}() at line {3} with the value '{4}'", name, Path.GetFileNameWithoutExtension (fileName), methodName, callerLineNumber, value));

			if (listeners.Count == 0)
            {
				Debug.LogWarning (string.Format ("[EVENT] '{0}' was raised but has no listeners", name));
				return false;
            }

            try
            {
                for (int i = listeners.Count - 1; i >= 0; i--)
                {
                    listeners[i].OnEventRaised (value);
                }
				return true;
			}
			catch (Exception e)
            {
				Debug.LogError (string.Format ("[EVENT] '{0}' threw '{1}'\n{2}", name, e.Message, e.StackTrace));
				return false;
            }

        }

        /// <summary>
        /// If not already registered, add an app event listener to this event's list of listeners.
        /// </summary>
        /// <param name="listener">An instance of a listener component in the current scene.</param>
        /// <returns>Returns whether or not the listener was registered successfully.</returns>
        public bool RegisterListener (AppEventListener<T> listener)
        {
            if (listener == null) return false;

#if UNITY_EDITOR
            if (!listenerNames.Contains (listener.name)) listenerNames.Add (listener.name);
#endif

            if (!listeners.Contains (listener))
            {
                listeners.Add (listener);
                return true;
            }

			return false;
        }

        /// <summary>
        /// If already registered, remove an app event listener from this event's list of listeners.
        /// </summary>
        /// <param name="listener">An instance of a listener component in the current scene.</param>
        /// <returns>Returns whether or not the listener was unregistered successfully.</returns>
        public bool UnregisterListener (AppEventListener<T> listener)
        {
            if (listener == null) return false;

#if UNITY_EDITOR
            if (listenerNames.Contains (listener.name)) listenerNames.Remove (listener.name);
#endif

            if (listeners.Contains (listener))
            {
                return listeners.Remove (listener);
            }

			return false;
        }

        /// <summary>
        /// Clear this event of all it's listeners
        /// </summary>
        public override void Clear ()
        {
            listeners.Clear ();

            #if UNITY_EDITOR
            listenerNames.Clear ();
            #endif
        }

        /// <summary>
        /// Calls Clear ()
        /// </summary>
        public override void Reset () => Clear ();
    }

    /// <summary>
    /// Base class for generic and non generic AppEvents
    /// </summary>
    public abstract class AppEventBase : RuntimeObject
    {
		public int ListenerCount { get; }

		/*private void Awake ()
		{
			Resources.LoadAll<RuntimeObjectDatabase> ("/")[0].RegisterEvent (this);
		}*/

		/// <summary>
		/// Invoke every function callback that is delegated to every event listener that is listenning 
		/// to this event.
		/// </summary>
		/// <param name="fileName">Name of the .cs file the event was raised from (assigned automatically)</param>
		/// <param name="methodName">Name of the method the event was raised from (assigned automatically)</param>
		/// <param name="callerLineNumber">Line number the event was raised from (assigned automatically)</param>
		/// <returns>Returns whether or not the event was raised successfully.</returns>
		public abstract bool RaiseEvent ([CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int callerLineNumber = 0);
    }
}