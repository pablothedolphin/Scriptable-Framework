# Event Objects

An event, in the context of Scriptable Framework, is a special type of RuntimeObject. You can create these assets inside Resources folders in your project by simply right clicking and going to "Create > Runtime Objects > Events" to see all available event types in your current version of Scriptable Framework.

## App Events

AppEvents are the simplest and most basic types of events you will use. When selected, the inspector will expose the object's description, a list of all the current listeners and a button to raise the event.

![Figure1](~/images/eventObjects1.png)

Events can be raised by either calling their `RaiseEvent ()` method in your own code or, if you haven't written that code yet, you can simulate the method call by clicking the button shown above while in play mode. Raising an event via code or manually with the provided button will call the responses of each listener to the event.

Manually raising an event with the button in the inspector allows you to test your code without having all of it completely written. It also gives you the freedom to experiment with what would happen if an event were to be raised during a certain unexpected usecase without writing the code for it first.

App events are very useful tools in your development. But more often than not, you'll want your events to pass along some data for your response functions to use. This is where the other event types come into play.

## Generic Events

When creating an event object, every other option you see that isn't an AppEvent is a generic event. You can read more about C# generics [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/). 

In short, these other event objects still behave like an AppEvent does but with some added quirks that also allow them to pass along some value to the listening scripts in your scene. The name of the object type is a hint at what data type it is made to pass along. For example, a FloatEvent can pass a single float value along to its listeners.

Generic events like the FloatEvent can be raised by either calling `RaiseEvent (myFloatVariable)` or with just `RaiseEvent ()` which will assume some default value. In the case of a FloatEvent, a 0 would be passed.

![Figure2](~/images/eventObjects2.png)

In the inspector you will find, in addition to the things found on an AppEvent, a "Value For Manual Trigger". You can adjust this value so that when pressing the "Raise this Event" button, your specified value will be what's passed to the listeners. The value for manual trigger is only ever used for this purposed and has no other effect on the event itself.

## Limitations

The main limitation with all event objects in Scriptable Framework is that you should avoid raising them on Awake. This is because listenners register themselves in OnEnable which runs after Awake. The safest time to raise an event would on Start.