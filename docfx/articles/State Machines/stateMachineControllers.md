# State Machine Controllers

The StateMachineController is a special type of state machine which functions almost identially to regular StateMachine objects with the only major difference being that instead of controlling the states of a list of GameObjects it controlls the states of other StateMachines. In other words, it allows you to make nested StateMachines. With a StateMachineController you will be able to exercise an even greater level of control over the GameObjects in your scene using an even higher level API. You can create StateMachineControllers under "Create > Runtime Objects > State Machines > State Machine Controller".

![Figure1](~/images/stateMachineControllers1.png)

What's more is, a StateMachineController can also control other StateMachineControllers which allows you to easily manipulate even the most complex object heirarchies (to an extent).