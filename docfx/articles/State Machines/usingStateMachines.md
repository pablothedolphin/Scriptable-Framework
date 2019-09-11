# Using State Machines

The API for using a StateMachine is extremely simple. In most cases you only ever need to call the `UpdateState` method You can either pass in an integer like this `StateMachine.UpdateState (0)` or a boolean `StateMachine.UpdateState (true)`. An integer will turn off all GameObjects in the GameObjectList but keep the one at that index on and a boolean will apply that state to all the GameObjects regardless of what their current state is. There are also other variations which you can read more about under `StateMachineBase` in the Scripting API [here](~/api/ScriptableFramework.StateMachineBase.html#ScriptableFramework_StateMachineBase_UpdateState_System_Boolean_).

## Initialising StateMachines

Because of the execution order of what goes on with Scriptable Framework behind the scenes, you will usually need a GameObject with a `StateMachineReset` component on it for any scenes that make use of StateMachines. This component needs absolutely no extra references or values set for it. It just works automatically once placed in the scene. You can compare needing a StateMachineReset in your scene to let StateMachines work to how Unity's Canvases need an EventSystem object in the scene to allow things to work properly. It's just a small thing you need to keep in mind.

![Figure2](~/images/stateMachines2.png)

**NOTE**: It is much quicker to use a populator to set the references in your GameObjectList automatically rather than to write your own code for it. See the Populators manual for further details.

## UpdateState via UI Components

Traditionally, a UI component like a button or a dropdown would have an instance of a MonoBehaviour dragged into them so that one of its methods could be assigned for the UI object to invoke. What most people don't know is, you can also do this with ScriptableObjects!

![Figure3](~/images/stateMachines3.png)

The image above shows an example of how a dropdown component has a StateMachine assigned to its object reference. By doing this, you can call the `UpdateState` method directly from the UI and not write any code at all for controlling objects in your scene.