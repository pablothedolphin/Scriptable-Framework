# State Machines

The StateMachine objects in Scriptable Framework allow you to control the active state of all GameObjects in a GameObjectList with a single line of code. This can be used for quickly prototying the active state of 3D objects in your scene and is especially useful when writing code to control the state of your UI because more often than not, you would need to write code to turn off and on various sets of objects just to change your UI into a new state. You can create StateMachines under "Create > Runtime Objects > State Machines > State Machine".

StateMachines were created because it's quite easy to take for granted just how much of your code is dedicated purely to turning objects off and on. With Scriptable Framework, you can just let the StateMachine handle that all for you. Obviously more developed UIs would use animations instead of turning objects off via code but for rapid prototyping the Scriptable Framework `StateMachine` is ideal.

![Figure1](~/images/stateMachines1.png)

When selected, a StateMachine's inspector will reveal the following properties:

1. A Default State for what the GameObjects will revert to when the StateMachine is reset
2. A Selection Index for which GameObject is currently being kept active
3. A GameObjectList of the GameObjects that will be controlled by the StateMachine