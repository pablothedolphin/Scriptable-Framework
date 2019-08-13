# Using State Machine Controllers

The API for using a StateMachineController is pretty much identical to its counter part. You still have access to an `UpdateState` method but this time, because it controls a list of StateMachines, your StateMachineController will call `StateMachine.UpdateState (true)` for the StateMachines you are making "active" and pass false for the others.

**NOTE**: StateMachineControllers also require an instance of a `StateMachineReset` in the scene to help with initialisation in each of your scenes. Though, even if you're using both StateMachines and StateMachineControllers, just one instance of a reset object will be enough.