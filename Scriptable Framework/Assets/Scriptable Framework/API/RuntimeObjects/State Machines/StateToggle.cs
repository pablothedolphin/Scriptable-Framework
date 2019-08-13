using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableFramework
{
    /// <summary>
    /// A helper component designed for quickly allowing control over a StateMachine by hooking it up to Toggles through
    /// dynamic function assignment. The Toggle would also respond to changes made to the StateMachine.
    /// </summary>
    [AddComponentMenu("Scriptable Framework/Misc/State Toggle")]
    [RequireComponent(typeof(Toggle))]
    public class StateToggle : MonoBehaviour
    {
        #region Variables
        /// <summary>
        /// The StateMachine being controlled.
        /// </summary>
        public StateMachine stateMachine;

        /// <summary>
        /// An array of events to collectively run when the toggle is fired.
        /// </summary>
        public AppEvent[] events;

        /// <summary>
        /// The Toggle on this GameObject.
        /// </summary>
        private Toggle toggle;
        #endregion
        
        /// <summary>
        /// Gets the Toggle reference.
        /// </summary>
        private void Start()
        {
            toggle = GetComponent<Toggle>();
        }

        /// <summary>
        /// The Toggle calls this function to update the StateMachine state according to its sibling index.
        /// </summary>
        /// <param name="value"></param>
        public void UpdateStateMachine(bool value)
        {
            if (value)
            {
                // Update sidebar state at toggle index
                stateMachine.UpdateState(transform.GetSiblingIndex());

                // Raise all associated events
                for (int i = 0; i < events.Length; i++)
                {
                    events[i].RaiseEvent();
                }
            }
        }

        /// <summary>
        /// If the StateMachine were to be updated through some other means, use this function as a response to an int event
        /// and pass that value here to make the Toggle reflect the state of the StateMachine.
        /// </summary>
        /// <param name="activeIndex"></param>
        public void RespondToStateMachineChange(int activeIndex)
        {
            toggle.isOn = activeIndex == transform.GetSiblingIndex();
        }
    }
}